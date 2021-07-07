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
        public int Image_Weigth { get; set; }
        public int Image_Heigth { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public string PdfName { get; set; }
    }
    public class Location
    {
        public int Position_X { get; set; }
        public int Position_Y { get; set; }
    }
}
