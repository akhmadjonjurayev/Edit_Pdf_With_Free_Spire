using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edit_Pdf_Free_Spire.Controllers
{
    public class PdfReportViewModel
    {
        public bool IsFirstPage { get; set; }
        public Location Image_Location { get; set; }
        public IEnumerable<Location_Variable> location_Variables { get; set; }
        public string PdfName { get; set; }
    }
    public class Location
    {
        public int Position_X { get; set; }
        public int Position_Y { get; set; }
    }
    public class Location_Variable
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public Location Location { get; set; }
        public string Color { get; set; } = "Blue";
        public int Size { get; set; }
    }
}
