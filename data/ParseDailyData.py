import pandas as pd
data = pd.read_csv("./DailyDataProcessed.txt")

names = ["EUR","GBP","ILS","JPY","CHF"]
range = pd.date_range("01-01-2015", "09-09-2015")

merged = pd.DataFrame({"Date":[], "Name":[],"Value":[]})
for Currency in names:
    new = data[["Date", Currency]].rename(columns={Currency: "Value"})
    new["Name"] = Currency
    merged = pd.concat([merged, new], ignore_index = False)

merged.Date = pd.to_datetime(merged["Date"])
merged.Date = merged.Date.dt.strftime('%Y-%m-%dT%H:%M:%S')
#merged = merged.set_index("Date")
merged = merged.sort_values(by = ["Date"])
merged.to_csv("FinalDailyData.txt", index = False)
print(merged)

