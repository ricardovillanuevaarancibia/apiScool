using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ApiScool.ViewModel.Cursos
{
    public class Funciones
    {
        public string ConvertToBase64(string path)
        {
            byte[] data;
            using (Stream inputStream = File.OpenRead(path))
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                data = memoryStream.ToArray();
            }
            var datosConvert = Convert.ToBase64String(data);
            return datosConvert;
        }
    }
}
