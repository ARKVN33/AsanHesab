using System;
using System.IO;

namespace DAL.Class
{
    public static class Globals
    {
        public static string ConnetionString = @"Data Source=(LocalDb)\v12.0;Database=dbAsanHesab;Integrated Security=True;Connect Timeout=30";
        public static string MyAppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"ARKVN\AsanHesab\");
    }
}
