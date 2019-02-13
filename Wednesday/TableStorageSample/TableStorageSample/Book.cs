using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace TableStorageSample
{
    public class Book : TableEntity
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
    }
}
