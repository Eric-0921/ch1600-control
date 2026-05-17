import sys
from pathlib import Path
import numpy as np

sys.path.insert(0, str(Path(__file__).resolve().parents[2]))

from data.review_loader import load_review_file, load_review_files, get_review_summary

TEST_DIR = Path(__file__).resolve().parent
errors = []

def assert_eq(actual, expected, msg):
    if actual != expected:
        errors.append(f"{msg}: expected {expected}, got {actual}")

def assert_close(actual, expected, tol, msg):
    if abs(actual - expected) > tol:
        errors.append(f"{msg}: expected ~{expected}, got {actual}")

# Test load_review_file with CSV
csv_path = TEST_DIR / "test_m1600.csv"
arr_csv = load_review_file(csv_path)
assert_eq(arr_csv is not None, True, "CSV load returned None")
assert_eq(arr_csv.size, 100, "CSV row count")
assert_eq(arr_csv.dtype.names, ("timestamp_s", "field_mt", "freq_hz", "temp_c"), "CSV column names")

# Test load_review_file with TXT
txt_path = TEST_DIR / "test_datareader2.txt"
arr_txt = load_review_file(txt_path)
assert_eq(arr_txt is not None, True, "TXT load returned None")
assert_eq(arr_txt.size, 100, "TXT row count")
assert_eq(arr_txt.dtype.names, ("timestamp_s", "field_mt", "freq_hz", "temp_c"), "TXT column names")

# Test load_review_files with 3 files
append_path = TEST_DIR / "test_append.csv"
merged, ok_count = load_review_files([csv_path, txt_path, append_path])
assert_eq(ok_count, 3, "successful file count")
assert_eq(merged.size, 300, "merged row count")

# Check sorted by timestamp
ts = merged["timestamp_s"]
assert_eq(np.all(np.diff(ts) >= 0), True, "timestamp not sorted")

# Check first and last timestamps
assert_close(float(ts[0]), 0.0, 1e-6, "first timestamp")
assert_close(float(ts[-1]), 2.99, 1e-6, "last timestamp")

# Test get_review_summary
summary = get_review_summary(merged)
assert_eq(summary["count"], 300, "summary count")
assert_close(summary["duration_s"], 2.99, 1e-6, "summary duration")
assert_eq(summary["field_min"] <= summary["field_max"], True, "min <= max")

if errors:
    print("FAILURES:")
    for e in errors:
        print("  -", e)
    sys.exit(1)
else:
    print("All tests passed.")
    sys.exit(0)
