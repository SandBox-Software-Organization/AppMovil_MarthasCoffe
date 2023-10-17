using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarthasCoffe.Utilidades
{
    public class ConexionDB
    {
        public static string DevolverRuta(string MarthasCoffe)
        {
            string rutaBaseDatos = string.Empty;

            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                rutaBaseDatos = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                rutaBaseDatos = Path.Combine(rutaBaseDatos, MarthasCoffe);

            }
            else if (DeviceInfo.Platform == DevicePlatform.iOS)
            {
                rutaBaseDatos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                rutaBaseDatos = Path.Combine(rutaBaseDatos, "..", "Library", MarthasCoffe);
            }

            return rutaBaseDatos;
        }
    }
}
