using System;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;

namespace ConsoleApp1
{
    internal class Program
    {
        public static yurtymbaevEntities context = new yurtymbaevEntities();
        static void Main(string[] args)
        {
            MemoryStream stream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(new BitmapImage(new Uri("C:\\Users\\azadeba\\source\\repos\\KirovCentralParkFramework\\ConsoleApp1\\NewFolder1\\Смирнова.jpeg", UriKind.Absolute))));
            encoder.Save(stream);
            Employee employee = context.Employee.First(e => e.Lastname == "Смирнова");
            employee.Image = stream.ToArray();
            context.SaveChanges();
        }
    }
}
