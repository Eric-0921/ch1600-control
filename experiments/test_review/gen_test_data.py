import numpy as np
from pathlib import Path

np.random.seed(42)

def write_csv(path, timestamps, field_mt, freq_hz, temp_c):
    with open(path, "w", encoding="utf-8-sig") as f:
        f.write("timestamp_s,field_mt,freq_hz,temp_c\n")
        for t, b, fq, tp in zip(timestamps, field_mt, freq_hz, temp_c):
            f.write(f"{t:.6f},{b:.6f},{fq:.1f},{tp:.1f}\n")

def write_txt(path, timestamps, field_mt, freq_hz, temp_c):
    with open(path, "w", encoding="utf-8-sig") as f:
        f.write("timestamp_s\tfield_mt\tfreq_hz\ttemp_c\n")
        for t, b, fq, tp in zip(timestamps, field_mt, freq_hz, temp_c):
            f.write(f"{t:.6f}\t{b:.6f}\t{fq:.1f}\t{tp:.1f}\n")

# test_m1600.csv: 100 rows, timestamp_s from 0 to 0.99 step 0.01
t1 = np.arange(0, 1.0, 0.01)
b1 = np.sin(2 * np.pi * t1) + np.random.normal(0, 0.05, size=100)
fq1 = np.full(100, 50.0)
tp1 = np.full(100, 25.0)
write_csv(Path(__file__).with_name("test_m1600.csv"), t1, b1, fq1, tp1)

# test_datareader2.txt: 100 rows, timestamp_s from 1.0 to 1.99 step 0.01
t2 = np.arange(1.0, 2.0, 0.01)
b2 = np.sin(2 * np.pi * t2) + np.random.normal(0, 0.05, size=100)
fq2 = np.full(100, 50.0)
tp2 = np.full(100, 25.0)
write_txt(Path(__file__).with_name("test_datareader2.txt"), t2, b2, fq2, tp2)

# test_append.csv: 100 rows, timestamp_s from 2.0 to 2.99 step 0.01
t3 = np.arange(2.0, 3.0, 0.01)
b3 = np.sin(2 * np.pi * t3) + np.random.normal(0, 0.05, size=100)
fq3 = np.full(100, 50.0)
tp3 = np.full(100, 25.0)
write_csv(Path(__file__).with_name("test_append.csv"), t3, b3, fq3, tp3)

print("Test data generated.")
