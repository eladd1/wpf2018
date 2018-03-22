import sqlite3
import csv
import mmap
import pandas;


with open("MonthlyData.txt","r") as source:
    rdr= csv.reader( source )   
    headers = next(rdr)
    with open("MonthlyDataProcessed.txt","w") as result:
        wtr = csv.writer(result)
        for line in rdr:
            #iterate the currencies in this row and create a row for each one
            for i in range(0,5):
                year, month = line[5], line[6]
                name = headers[i]
                row = [year, month, name, line[i]]
                print(row)
                wtr.writerow(row)
                
                


