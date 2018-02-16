using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;

namespace ZXS
{
    public class ScanDBConnection : LinqToDB.Data.DataConnection
    {
        public ScanDBConnection() : base("SCANDB") { }

        public ITable<ScanData> LicenseData { get { return GetTable<ScanData>(); } }

    }
}
