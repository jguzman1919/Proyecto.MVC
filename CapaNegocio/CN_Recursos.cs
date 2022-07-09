using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

  namespace CapaNegocio
  {
        public class CN_Recursos
        { 
            public static String ConvertirSha256(String texto)
            {
                    StringBuilder sb = new StringBuilder();
                using (SHA256 hash = SHA256Managed.Create())
                {
                    Encoding enc = Encoding.UTF8;
                    byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                    foreach (byte b in result)
                        sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }
  } 