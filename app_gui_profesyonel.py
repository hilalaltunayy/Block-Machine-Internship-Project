# app_gui_profesyonel.py — Hilal Yeşim Staj Projesi Uygulaması (SON VERSİYON)

import os
import sys
import glob
import time
import sqlite3
import threading
import subprocess
import shutil
from pathlib import Path
from datetime import datetime, timedelta
import math
import matplotlib
matplotlib.use("TkAgg")


# CustomTkinter importu
import customtkinter as ctk
from tkinter import messagebox
import tkinter.ttk as ttk # Standart ttk importu (Treeview stilizasyonu için)

# Ses çalma için winsound (Windows)
try:
    import winsound
    WINSOUND_OK = True
except ImportError:
    WINSOUND_OK = False
    print("winsound bulunamadı. Sesli alarm pasif.")

import pandas as pd
import matplotlib.pyplot as plt
import matplotlib.dates as mdates
from matplotlib.animation import FuncAnimation
from matplotlib.backends.backend_tkagg import FigureCanvasTkAgg
from matplotlib.backends.backend_pdf import PdfPages
import seaborn as sns
sns.set_style('darkgrid')

#--- YOL ve KAYNAKLAR ---
def find_project_root() -> Path:
    """Python dosyasından yola çıkarak 'Staj Proje - Kopya' kök klasörünü bulur."""
    p = Path(__file__).resolve() # app_gui_profesyonel.py yolu
    
    # Kök klasörü bulana kadar yukarı çık
    while p != p.parent:
        # Eğer kökte src klasörü varsa ve içinde csharp/python varsa (Sizin yapınız)
        if (p / "src" / "csharp").exists(): 
            return p
        # Eğer doğrudan csharp klasörü varsa (eğer src yoksa)
        if (p / "csharp").exists(): 
            return p
        p = p.parent
        
    return Path(__file__).resolve().parents[3] # Fallback


PROJECT_ROOT = Path("C:/Users/Hilal Yeşim/Desktop/Staj Proje - Kopya") #find_project_root()

# C# klasör yolunu sizin yapınıza göre kesin olarak ayarlıyoruz
# Sizin yapınız: .../Staj Proje - Kopya/src/csharp/SensorSimulator
CSHARP_SIM_DIR = PROJECT_ROOT / "src" / "csharp" / "SensorSimulator"
# Eğer kod bu klasörü bulmakta sorun yaşarsa, /src klasörünü çıkarıp deneyebilirsiniz:
# CSHARP_SIM_DIR = PROJECT_ROOT / "csharp" / "SensorSimulator" 

DB_PATH = CSHARP_SIM_DIR / "sensor_data.db"

RES_DIR = PROJECT_ROOT / "resources" 
RES_DIR.mkdir(parents=True, exist_ok=True)

OUT_DIR = PROJECT_ROOT / "python" / "analytics" / "outputs" / "reports"
OUT_DIR.mkdir(parents=True, exist_ok=True)

LOGS_DIR = PROJECT_ROOT / "logs"
LOGS_DIR.mkdir(parents=True, exist_ok=True)

# --- Simülatör Başlat/Durdur (C#) ---
def _find_simulator_exe() -> Path | None:
    """Derlenmiş SensorSimulator.exe dosyasını en güncel .NET sürümü altında bulur."""
    
    # !!! HATA BURADAYDI: publish_base'in tanımlanması gerekiyordu !!!
    publish_base = CSHARP_SIM_DIR / "bin" / "Release" 
    
    # 1. Adım: Eğer publish klasörü yoksa, doğrudan çık
    if not publish_base.exists():
        return None
        
    # 2. Adım: Çoğu modern .NET sürümünü kontrol ediyoruz
    for version in ["net8.0", "net7.0", "net6.0"]:
        # publish_base değişkenini kullanıyoruz
        exe_path = publish_base / version / "win-x64" / "publish" / "SensorSimulator.exe"
        if exe_path.exists():
            print(f"C# Simülatörü EXE yolu bulundu: {exe_path}")
            return exe_path
    
    # 3. Adım: Hiçbiri bulunamazsa
    return None

# KODUN KALANI BURADAN İTİBAREN DEVAM EDER

def start_simulator_process():
    logfile = LOGS_DIR / "simulator.log"
    # Log dosyasını yazma modunda aç
    try:
        log = open(logfile, "a", encoding="utf-8")
    except Exception as e:
        print(f"Log dosyası açılamadı: {e}")
        log = subprocess.DEVNULL # Log yazılamazsa boşluğa yaz

    exe = _find_simulator_exe()
    
    if exe and exe.exists():
        print(f"C# Simülatörü EXE yolu: {exe}")
        # cwd: DB dosyasının oluşacağı C# proje klasörü
        return subprocess.Popen([str(exe)], cwd=str(CSHARP_SIM_DIR), stdout=log, stderr=subprocess.STDOUT)
    else:
        print(f"C# Simülatörü EXE bulunamadı. '{CSHARP_SIM_DIR}' içinde 'dotnet run' ile başlatılıyor.")
        # dotnet run komutu için cwd yine C# proje klasörü olmalı.
        try:
            return subprocess.Popen(["dotnet", "run"], cwd=str(CSHARP_SIM_DIR), stdout=log, stderr=subprocess.STDOUT)
        except FileNotFoundError:
            raise RuntimeError("dotnet komutu bulunamadı. Lütfen .NET SDK'nın kurulu olduğundan emin olun.")

def stop_process(p: subprocess.Popen | None):
    if not p: return
    try:
        p.terminate()
        p.wait(timeout=3)
    except Exception:
        try:
            p.kill()
        except Exception:
            pass

# --- Yardımcılar: Veritabanı Okuma ve PDF Oluşturma ---
def read_latest_df(limit: int = 200, hours_back: int = None) -> pd.DataFrame:
    """DB’den ya son 'limit' kaydı ya da son 'hours_back' saatteki kayıtları alır."""
    if not DB_PATH.exists():
        return pd.DataFrame(columns=["Id", "Tarih", "Sicaklik"])

    query = "SELECT Id, Tarih, Sicaklik FROM SensorData "
    params = []
    
    if hours_back is not None:
        cutoff = datetime.now() - timedelta(hours=hours_back)
        cutoff_str = cutoff.strftime("%Y-%m-%d %H:%M:%S")
        query += "WHERE Tarih >= ? "
        params.append(cutoff_str)

    query += "ORDER BY Id DESC "
    if hours_back is None:
        query += f"LIMIT {int(limit)}"

    conn = None
    try:
        #conn = sqlite3.connect(f"file:{DB_PATH}?mode=ro", uri=True, check_same_thread=False, isolation_level=None)
        conn = sqlite3.connect(DB_PATH, check_same_thread=False, isolation_level=None)

        conn.execute("PRAGMA journal_mode=WAL;")
        conn.execute("PRAGMA busy_timeout = 3000;")
        df = pd.read_sql_query(query, conn, params=params)
    except sqlite3.OperationalError as e:
        print(f"Veritabanı bağlantı/okuma hatası: {e}")
        return pd.DataFrame(columns=["Id", "Tarih", "Sicaklik"])
    finally:
        if conn:
             conn.close()
    
    if not df.empty:
        df = df.sort_values("Id").reset_index(drop=True)
        df["Tarih"] = pd.to_datetime(df["Tarih"], errors="coerce")
        df["Anomali"] = (df["Sicaklik"] < 15) | (df["Sicaklik"] > 35)
        df = df.dropna(subset=["Tarih", "Sicaklik"])
    return df

def compute_summary(df: pd.DataFrame) -> dict:
    """Özet metrikleri hesapla."""
    if df.empty:
        return {"kayıt_sayısı": 0, "min": None, "max": None, "ortalama": None, "anomali_sayısı": 0, "anomali_oranı": "0%"}
    
    summary = {}
    summary["kayıt_sayısı"] = len(df)
    summary["min"] = float(df["Sicaklik"].min()) if not df["Sicaklik"].empty else None
    summary["max"] = float(df["Sicaklik"].max()) if not df["Sicaklik"].empty else None
    summary["ortalama"] = float(df["Sicaklik"].mean()) if not df["Sicaklik"].empty else None
    anom_count = int(df["Anomali"].sum())
    summary["anomali_sayısı"] = anom_count
    ratio = 100.0 * anom_count / len(df) if len(df) > 0 else 0.0
    summary["anomali_oranı"] = f"{ratio:.1f}%"
    return summary

def create_pdf_report_task(df: pd.DataFrame, summary: dict, out: Path):
    """PDF oluşturma işlemini bir fonksiyonda toplar."""
    with PdfPages(out) as pdf:
        
        # Grafik renklerini tema bağımsız siyah/beyaz yapalım (PDF için)
        plt.rcParams.update({
            "figure.facecolor": "white", 
            "axes.facecolor": "white",
            "text.color": "black",
            "axes.labelcolor": "black",
            "xtick.color": "black",
            "ytick.color": "black"
        })
        
        # --- Sayfa 1: Zaman Serisi Grafiği + Anomaliler ---
        fig1, ax1 = plt.subplots(figsize=(10, 6))
        ax1.plot(df["Tarih"], df["Sicaklik"], label="Sıcaklık", linewidth=1.2, color='#007acc')
        anomalies = df[df["Anomali"] == True]
        if not anomalies.empty:
            ax1.scatter(anomalies["Tarih"], anomalies["Sicaklik"], label="Anomali", color="red", s=30, zorder=5)

        ax1.set_title(f"Sıcaklık Zaman Serisi (Toplam Kayıt: {len(df)})", fontsize=14)
        ax1.set_xlabel("Zaman", fontsize=10)
        ax1.set_ylabel("Sıcaklık (°C)", fontsize=10)
        ax1.legend(loc="upper left")
        ax1.xaxis.set_major_formatter(mdates.DateFormatter('%d-%m %H:%M'))
        fig1.autofmt_xdate()
        pdf.savefig(fig1, bbox_inches="tight")
        plt.close(fig1)

        # --- Sayfa 2: Histogram (Dağılım) ---
        fig2, ax2 = plt.subplots(figsize=(10, 6))
        ax2.hist(df["Sicaklik"], bins=25, alpha=0.8, color='#007acc', edgecolor='black')
        ax2.axvline(summary['ortalama'], color='red', linestyle='dashed', linewidth=1, label=f"Ort: {summary['ortalama']:.2f}°C")
        ax2.set_title("Sıcaklık Değerleri Dağılımı (Histogram)", fontsize=14)
        ax2.set_xlabel("Sıcaklık (°C)", fontsize=10)
        ax2.set_ylabel("Frekans", fontsize=10)
        ax2.legend()
        pdf.savefig(fig2, bbox_inches="tight")
        plt.close(fig2)

        # --- Sayfa 3: Özet Metrikler Tablosu ---
        fig3, ax3 = plt.subplots(figsize=(10, 6))
        ax3.axis('off')

        title = f"Analiz Raporu Özeti – {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}"
        ax3.text(0.5, 0.95, title, ha="center", va="top", fontsize=16, fontweight="bold")
        
        rows = [
            ["Metrik", "Değer"],
            ["Kayıt Sayısı", summary["kayıt_sayısı"]],
            ["Min. Sıcaklık (°C)", f"{summary['min']:.2f}" if summary["min"] is not None else "N/A"],
            ["Maks. Sıcaklık (°C)", f"{summary['max']:.2f}" if summary["max"] is not None else "N/A"],
            ["Ortalama Sıcaklık (°C)", f"{summary['ortalama']:.2f}" if summary["ortalama"] is not None else "N/A"],
            ["Anomali Sayısı (15°C altı / 35°C üstü)", summary["anomali_sayısı"]],
            ["Anomali Oranı", summary["anomali_oranı"]],
        ]
        
        table = ax3.table(cellText=rows[1:], colLabels=rows[0], loc="center", cellLoc="center", 
                          colColours=["#f2f2f2", "#f2f2f2"])
        table.auto_set_font_size(False)
        table.set_fontsize(10)
        table.scale(1, 2)
        pdf.savefig(fig3, bbox_inches="tight")
        plt.close(fig3)

    try:
        os.startfile(str(out))
    except Exception as e:
        print(f"PDF açma hatası: {e}")
    return out

# --- UI — CustomTkinter Uygulaması ---

class App(ctk.CTk):
    def __init__(self):
        super().__init__()

        self.title("Sıcaklık Veri Analiz Sistemi")
        self.geometry("1000x700")
        self.minsize(800, 600)
        self.grid_columnconfigure(1, weight=1)
        self.grid_rowconfigure(0, weight=1)
        
        # Login ekranı için placeholder (bu versiyonda login atlanmıştır)
        # Eğer login ekranı isterseniz, bu kısmı silip bir LoginWindow ekleyebilirsiniz.

        # --- Sidebar ---
        self.sidebar_frame = ctk.CTkFrame(self, width=170, corner_radius=0)
        self.sidebar_frame.grid(row=0, column=0, rowspan=4, sticky="nsew")
        self.sidebar_frame.grid_rowconfigure(4, weight=1)

        self.logo_label = ctk.CTkLabel(self.sidebar_frame, text="📈 Analiz Sistemi", 
                                       font=ctk.CTkFont(size=20, weight="bold"))
        self.logo_label.grid(row=0, column=0, padx=20, pady=20)

        self.data_button = ctk.CTkButton(self.sidebar_frame, text="Veri Tablosu", command=self.show_data_frame,
                                          font=ctk.CTkFont(size=13, weight="bold"))
        self.data_button.grid(row=1, column=0, padx=20, pady=10)

        self.live_graph_button = ctk.CTkButton(self.sidebar_frame, text="Canlı Grafik", command=self.show_live_graph_frame,
                                                font=ctk.CTkFont(size=13, weight="bold"))
        self.live_graph_button.grid(row=2, column=0, padx=20, pady=10)

        self.report_button = ctk.CTkButton(self.sidebar_frame, text="PDF Raporu Oluştur", command=self.generate_report,
                                            font=ctk.CTkFont(size=13, weight="bold"))
        self.report_button.grid(row=3, column=0, padx=20, pady=10)

        self.appearance_mode_label = ctk.CTkLabel(self.sidebar_frame, text="Tema:", anchor="w")
        self.appearance_mode_label.grid(row=5, column=0, padx=20, pady=(10, 0))
        self.appearance_mode_optionemenu = ctk.CTkOptionMenu(self.sidebar_frame, 
                                                            values=["Dark", "Light", "System"],
                                                            command=self.change_appearance_mode_event)
        self.appearance_mode_optionemenu.grid(row=6, column=0, padx=20, pady=(10, 20))
        self.appearance_mode_optionemenu.set("Dark") 


        # --- Main Frame for Content ---
        self.main_frame = ctk.CTkFrame(self, corner_radius=0)
        self.main_frame.grid(row=0, column=1, sticky="nsew", padx=10, pady=10)
        self.main_frame.grid_rowconfigure(0, weight=1)
        self.main_frame.grid_columnconfigure(0, weight=1)

        self.frames = {}
        
        # Data Table Frame
        self.data_frame = DataTableFrame(self.main_frame, self)
        self.frames["data"] = self.data_frame
        
        # Live Graph Frame
        self.live_graph_frame = LiveGraphFrame(self.main_frame, self)
        self.frames["live_graph"] = self.live_graph_frame

        self.show_frame("live_graph") 

        self.protocol("WM_DELETE_WINDOW", self.on_closing)

    def show_frame(self, frame_name):
        frame = self.frames[frame_name]
        # Önce tüm frameleri sakla
        for name, f in self.frames.items():
            f.grid_remove()
        
        # İstenen frame'i göster
        frame.grid(row=0, column=0, sticky="nsew", padx=10, pady=10)

    def show_data_frame(self):
        self.data_frame.refresh_data()
        self.show_frame("data")

    def show_live_graph_frame(self):
        self.show_frame("live_graph")

    def generate_report(self):
        df_24h = read_latest_df(hours_back=24)
        if df_24h.empty:
            messagebox.showinfo("Bilgi", "Son 24 saatte rapor oluşturulacak veri yok.")
            return

        summary = compute_summary(df_24h)
        try:
            report_path = OUT_DIR / f"report_{time.strftime('%Y%m%d_%H%M%S')}.pdf"
            create_pdf_report_task(df_24h, summary, report_path)
            messagebox.showinfo("Başarılı", f"PDF raporu oluşturuldu:\n{report_path}")
        except Exception as e:
            messagebox.showerror("Hata", f"PDF raporu oluşturulamadı: {e}")

    def change_appearance_mode_event(self, new_appearance_mode: str):
        ctk.set_appearance_mode(new_appearance_mode)

    def on_closing(self):
        if messagebox.askokcancel("Çıkış", "Uygulamayı kapatmak istediğinizden emin misiniz?"):
            self.live_graph_frame.stop_sim()
            self.destroy()
            sys.exit(0)


class DataTableFrame(ctk.CTkFrame):
    def __init__(self, parent_frame, app_instance):
        super().__init__(parent_frame, corner_radius=0)
        self.app = app_instance
        self.grid_rowconfigure(1, weight=1)
        self.grid_columnconfigure(0, weight=1)

        self.title_label = ctk.CTkLabel(self, text="Gerçek Zamanlı Veri Tablosu", 
                                        font=ctk.CTkFont(size=18, weight="bold"))
        self.title_label.grid(row=0, column=0, padx=10, pady=10, sticky="w")

        self.refresh_button = ctk.CTkButton(self, text="⟳ Yenile", command=self.refresh_data, 
                                            width=100, font=ctk.CTkFont(size=12, weight="bold"))
        self.refresh_button.grid(row=0, column=0, padx=10, pady=10, sticky="e")
        
        self.tree_frame = ctk.CTkFrame(self)
        self.tree_frame.grid(row=1, column=0, sticky="nsew", padx=10, pady=10)
        self.tree_frame.grid_columnconfigure(0, weight=1)
        self.tree_frame.grid_rowconfigure(0, weight=1)

        # Standart ttk.Style kullanarak Treeview stilizasyonu (CTkStyle hatası düzeltildi)
        style = ttk.Style(self)
        style.theme_use("clam")
        
        # CTk tema renklerini kullanarak ttk stilini özelleştirme
        style.configure("Treeview", 
                        background=self.cget("fg_color")[0], 
                        fieldbackground=self.cget("fg_color")[0], 
                        foreground=ctk.ThemeManager.theme["CTkLabel"]["text_color"][0],
                        rowheight=25)
        style.map('Treeview', background=[('selected', ctk.ThemeManager.theme["CTkButton"]["fg_color"][0])])
        style.configure("Treeview.Heading", 
                        background=ctk.ThemeManager.theme["CTkButton"]["fg_color"][0], 
                        foreground=ctk.ThemeManager.theme["CTkButton"]["text_color"][0],
                        font=('Segoe UI', 10, 'bold'))
        
        # ttk.Treeview kullanılıyor
        self.tree = ttk.Treeview(self.tree_frame, show="headings")
        self.tree.grid(row=0, column=0, sticky="nsew")
        
        self.vsb = ctk.CTkScrollbar(self.tree_frame, orientation="vertical", command=self.tree.yview)
        self.vsb.grid(row=0, column=1, sticky="ns")
        self.tree.configure(yscrollcommand=self.vsb.set)

        self.refresh_data()

    def refresh_data(self):
        df = read_latest_df(200)
        
        cols = ["Id", "Tarih", "Sicaklik", "Anomali"]

        self.tree["columns"] = cols
        for c in cols:
            self.tree.heading(c, text=c)
            self.tree.column(c, anchor="center", width=120 if c!="Tarih" else 180)

        self.tree.delete(*self.tree.get_children())
        
        if df.empty:
            return

        for _, row in df.iloc[::-1].iterrows(): 
            vals = [row.get(c, "-") for c in cols]
            if isinstance(vals[1], pd.Timestamp):
                vals[1] = vals[1].strftime("%Y-%m-%d %H:%M:%S")
            tag = "anomaly" if row["Anomali"] else ""
            self.tree.insert("", "end", values=vals, tags=(tag,))

        # Anomali satırları için renk etiketi
        self.tree.tag_configure("anomaly", background="#8b0000", foreground="white")


class LiveGraphFrame(ctk.CTkFrame):
    def __init__(self, parent_frame, app_instance):
        super().__init__(parent_frame, corner_radius=0)
        self.app = app_instance
        self.grid_rowconfigure(2, weight=1)
        self.grid_columnconfigure(0, weight=1)

        self.proc: subprocess.Popen | None = None
        self.is_alarm_on = False
        self.ani = None

        # Header Frame
        header_frame = ctk.CTkFrame(self, fg_color="transparent")
        header_frame.grid(row=0, column=0, sticky="ew", padx=10, pady=5)
        header_frame.grid_columnconfigure(0, weight=1)

        self.title_label = ctk.CTkLabel(header_frame, text="Canlı Sıcaklık İzleme", 
                                        font=ctk.CTkFont(size=18, weight="bold"))
        self.title_label.grid(row=0, column=0, sticky="w")

        # Simulator Controls
        self.status_label = ctk.CTkLabel(header_frame, text="Simülatör: DURDU", text_color="red", 
                                        font=ctk.CTkFont(size=14, weight="bold"))
        self.status_label.grid(row=0, column=1, padx=20, sticky="e")

        self.start_button = ctk.CTkButton(header_frame, text="▶ Başlat", command=self.start_sim, 
                                          fg_color="#28a745", hover_color="#218838")
        self.start_button.grid(row=0, column=2, padx=5)

        self.stop_button = ctk.CTkButton(header_frame, text="■ Durdur", command=self.stop_sim, 
                                         fg_color="#dc3545", hover_color="#c82333", state="disabled")
        self.stop_button.grid(row=0, column=3, padx=5)

        # Summary Cards Frame
        self.summary_frame = ctk.CTkFrame(self, fg_color="transparent")
        self.summary_frame.grid(row=1, column=0, sticky="ew", padx=10, pady=10)
        self.summary_frame.grid_columnconfigure((0,1,2,3), weight=1)
        
        self.total_records_card = self._create_summary_card(self.summary_frame, "Toplam Kayıt", "0", 0, "#007acc")
        self.avg_temp_card = self._create_summary_card(self.summary_frame, "Ortalama Sıcaklık", "0.00°C", 1, "#28a745")
        self.max_min_card = self._create_summary_card(self.summary_frame, "Sıcaklık Aralığı", "N/A", 2, "#ffc107")
        self.anomalies_card = self._create_summary_card(self.summary_frame, "Anomali Sayısı", "0 (0.0%)", 3, "#dc3545")

        # Matplotlib Grafik Alanı
        self.fig, self.ax = plt.subplots(figsize=(9, 5))
        
        self.canvas = FigureCanvasTkAgg(self.fig, master=self)
        self.canvas_widget = self.canvas.get_tk_widget()
        self.canvas_widget.grid(row=2, column=0, sticky="nsew", padx=10, pady=10)
        
        self._start_animation()

    def _create_summary_card(self, parent, title, value, column, color):
        card_frame = ctk.CTkFrame(parent, corner_radius=10, fg_color=color)
        card_frame.grid(row=0, column=column, padx=5, pady=5, sticky="nsew")
        card_frame.grid_columnconfigure(0, weight=1)

        ctk.CTkLabel(card_frame, text=title, font=ctk.CTkFont(size=12, weight="bold"), text_color="white").grid(row=0, column=0, padx=10, pady=(10, 0), sticky="w")
        value_label = ctk.CTkLabel(card_frame, text=value, font=ctk.CTkFont(size=24, weight="bold"), text_color="white")
        value_label.grid(row=1, column=0, padx=10, pady=(0, 10), sticky="w")
        return value_label

    def _update_summary_cards(self, summary_data):
        self.total_records_card.configure(text=str(summary_data["kayıt_sayısı"]))
        
        ortalama = summary_data['ortalama']
        min_val = summary_data['min']
        max_val = summary_data['max']
        
        if ortalama is not None:
            self.avg_temp_card.configure(text=f"{ortalama:.2f}°C")
            self.max_min_card.configure(text=f"{min_val:.2f} - {max_val:.2f}°C")
            self.anomalies_card.configure(text=f"{summary_data['anomali_sayısı']} ({summary_data['anomali_oranı']})")
        else:
             self.avg_temp_card.configure(text="N/A")
             self.max_min_card.configure(text="N/A")
             self.anomalies_card.configure(text="0 (0.0%)")


    def _play_alarm(self):
        if not self.is_alarm_on and WINSOUND_OK:
            try:
                winsound.PlaySound("SystemExit", winsound.SND_ALIAS | winsound.SND_ASYNC)
                self.is_alarm_on = True
                print("!!! ANOMALİ ALARMI ÇALDI !!!")
            except Exception as e:
                print(f"Ses çalma hatası: {e}")

    def _stop_alarm(self):
        if self.is_alarm_on and WINSOUND_OK:
            try:
                winsound.PlaySound(None, winsound.SND_PURGE)
                self.is_alarm_on = False
            except Exception:
                pass

    def _update_plot(self, frame):
        try:
            # 1. Veriyi Çek ve Özeti Hesapla
            df = read_latest_df(200)
            print(f"[DEBUG] df shape: {df.shape}")
            summary = compute_summary(df)
            self._update_summary_cards(summary)

            self.ax.clear()
            
            # Tema rengine göre dinamik ayar (Matplotlib'i özelleştirme)
            #text_color = ctk.ThemeManager.theme["CTkLabel"]["text_color"][0]
            #bg_color = ctk.ThemeManager.theme["CTkFrame"]["fg_color"][0]
             #plot_bg_color = ctk.ThemeManager.theme["CTkFrame"]["top_fg_color"][0]
            text_color = "#ffffff"  # beyaz
            bg_color = "#2b2b2b"    # koyu gri
            plot_bg_color = "#1e1e1e"


            self.ax.set_title("Canlı Sıcaklık Verisi (Son 200 Kayıt)", color=text_color)
            self.ax.set_xlabel("Zaman", color=text_color)
            self.ax.set_ylabel("Sıcaklık (°C)", color=text_color)
            
            self.fig.patch.set_facecolor(bg_color)
            self.ax.set_facecolor(plot_bg_color)
            self.ax.tick_params(colors=text_color)
            self.ax.spines['left'].set_color(text_color)
            self.ax.spines['bottom'].set_color(text_color)
            self.ax.grid(True, linestyle='--', alpha=0.6, color='gray')


            # 2. Grafik Çizimi Kontrolü
            if df.empty or len(df) < 2:
                # Veri yoksa veya çizgi çizmeye yetecek kadar (en az 2) nokta yoksa
                self._stop_alarm()
                self.ax.text(0.5, 0.5, "Simülatör çalışıyor, veri bekleniyor...", 
                             color=text_color, ha='center', va='center', fontsize=12)
                self.canvas.draw_idle()
                return
            # >>> EKSİK KISIM BURASIYDI: X ve Y verisi burada tanımlanmalı <<<
            
            # Tarih verisini Matplotlib'in sayısal formatına çeviriyoruz.
            x_data = mdates.date2num(df["Tarih"])
            y_data = df["Sicaklik"]

            # 3. Çizgiyi Çiz
            self.ax.plot(x_data, y_data, label="Sıcaklık", color="#00bfff", linewidth=2)
            self.fig.tight_layout()
            # 4. Anomalileri İşaretle
            anomalies = df[df["Anomali"] == True]
            
            if not anomalies.empty:
                # Scatter plot da aynı şekilde sayısal X verisi kullanmalı
                anomaly_x = mdates.date2num(anomalies["Tarih"])
                anomaly_y = anomalies["Sicaklik"]
                self.ax.scatter(anomaly_x, anomaly_y, color="red", label="Anomali", s=50, zorder=5)
                self._play_alarm()
            else:
                self._stop_alarm()

            # 5. Ekseni ve Görünümü Güncelle
            self.ax.legend(facecolor=plot_bg_color, edgecolor='gray', labelcolor=text_color)
            self.fig.autofmt_xdate()
            self.ax.xaxis.set_major_formatter(mdates.DateFormatter('%H:%M:%S'))
            
            # Grafik eksen sınırlarını dinamik olarak ayarla (sadece görünebilir alanı kapsayacak şekilde)
            self.ax.relim()
            self.ax.autoscale_view()
            
            self.canvas.draw_idle()
            
        except Exception as e:
            print(f"Plot update error: {e}")
            self._stop_alarm()
            self.canvas.draw_idle()

    def _start_animation(self):
     if self.ani is None:
        self.ani = FuncAnimation(
            self.fig, self._update_plot,
            interval=1000, cache_frame_data=False, blit=False
        )
        self.canvas.draw_idle()
        self.fig.canvas.draw()
        plt.show(block=False)


    def _stop_animation(self):
        if self.ani:
            self.ani.event_source.stop()
            self.ani = None

            # Grafik alanını temizleyip boş bir eksen göster
            self.ax.clear()
            self.ax.set_title("Canlı Sıcaklık Verisi (Durduruldu)")
            self.canvas.draw_idle()

    def start_sim(self):
        if self.proc and (self.proc.poll() is None):
            messagebox.showinfo("Bilgi", "Simülatör zaten çalışıyor.")
            return
        try:
            self.proc = start_simulator_process()
            self.start_button.configure(state="disabled")
            self.stop_button.configure(state="normal")
            self.status_label.configure(text="Simülatör: ÇALIŞIYOR", text_color="green")
            self._start_animation() 
            messagebox.showinfo("Bilgi", "Simülatör başlatıldı.")
        except Exception as e:
            messagebox.showerror("Hata", f"Simülatör başlatılamadı. .NET SDK ve EXE yolunu kontrol edin.\nHata: {e}")

    def stop_sim(self):
        if not self.proc:
            messagebox.showinfo("Bilgi", "Çalışan simülatör yok.")
            return
        stop_process(self.proc)
        self.proc = None
        self.start_button.configure(state="normal")
        self.stop_button.configure(state="disabled")
        self.status_label.configure(text="Simülatör: DURDU", text_color="red")
        self._stop_alarm()
        self._stop_animation()
        messagebox.showinfo("Bilgi", "Simülatör durduruldu.")

# --- Uygulama Başlatıcılar ---
def main():
    ctk.set_appearance_mode("Dark")
    ctk.set_default_color_theme("blue")
    
    app = App()
    app.mainloop()

if __name__ == "__main__":
    main() 