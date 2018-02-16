using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZXS
{
    [Table(Name = "scan_history")]
    public class ScanData
    {

        [PrimaryKey, Identity]
        [Column(Name = "path"), NotNull]
        public string Path { get; set; }

        [Column(Name = "barcode")]
        public string Barcode { get; set; }

        [Column(Name = "timestamp")]
        public string TimeStamp { get; set; }

        [Column(Name = "result")]
        public int Result { get; set; }
        
    }
}
