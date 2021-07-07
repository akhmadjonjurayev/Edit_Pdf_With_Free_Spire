using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Edit_Pdf_Free_Spire.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly IWebHostEnvironment _web;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IWebHostEnvironment web)
        {
            _web = web;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpPost("editpdf")]
        public IActionResult EditPDf([FromBody] PdfReportViewModel pdfReport)
        {
            PdfDocument document = new PdfDocument();
            var path = string.Concat(_web.WebRootPath, @"\resourse\report.pdf");
            document.LoadFromFile(path);
            var img = PdfImage.FromStream(DrawImage(pdfReport.Year,pdfReport.Month));
            if (pdfReport.IsFirstPage)
            {
                document.Pages[0].Canvas.DrawImage(img, pdfReport.Image_Location.Position_X, pdfReport.Image_Location.Position_Y);
            }
            else
            {
                int count = document.Pages.Count;
                document.Pages[count - 1].Canvas.DrawImage(img, pdfReport.Image_Location.Position_X, pdfReport.Image_Location.Position_Y);
            }
            var pdf = new MemoryStream();
            document.SaveToStream(pdf, FileFormat.PDF);
            return File(pdf.ToArray(), "application/pdf", "hisobot.pdf");
        }
        private MemoryStream DrawImage(int Year,int Month)
        {
            var path = string.Concat(_web.WebRootPath, @"\resourse\pechat_kirish.png");
            Image image = System.Drawing.Image.FromFile(path);
            using (Graphics graphics = Graphics.FromImage(image))
            {
                graphics.DrawString(Year.ToString(), new Font("Tahoma", 8), Brushes.Blue, 125f, 108f);
                graphics.DrawString(Month.ToString(), new Font("Tahoma", 8), Brushes.Blue, 250f, 108f);
                var ms = new MemoryStream();
                image.Save(ms, ImageFormat.Png);
                return ms;
            }
        }
    }
}
