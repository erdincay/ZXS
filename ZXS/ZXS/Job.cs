using LinqToDB;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;

namespace ZXS
{
    public class Job
    {        
        FileInfo file;
        BarcodeReader reader;
        ScanDBConnection db; 

        public Job(FileInfo file, BarcodeReader reader, ScanDBConnection db)
        {
            this.file = file;
            this.reader = reader;
            this.db = db; 
        }

        public void Execute()
        {

            string path = Path.GetFullPath(file.FullName);

            Bitmap barcodeBitmap = (Bitmap)Bitmap.FromFile(path);
            var barcodeResult = reader.Decode(barcodeBitmap);

            string text = barcodeResult.Text;
            string format = barcodeResult.BarcodeFormat.ToString();

            int result = (!String.IsNullOrWhiteSpace(format)) ? 1 : 0;

            // Console.WriteLine($"Decoded barcode text: {barcodeResult?.Text}");
            // Console.WriteLine($"Barcode format: {barcodeResult?.BarcodeFormat}");

            string timestamp = DateTime.Now.ToString();


            ScanData sd = new ScanData();

            sd.Path = path; 
            sd.Barcode = text;
            sd.Result = result; 
            sd.TimeStamp = timestamp; 
            
            db.Insert(sd);

        }

    }
}
