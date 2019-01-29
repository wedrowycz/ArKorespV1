using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ArKorespV1.Helpers
{
    /// <summary>
    /// Helper class to convert data to hex string and hex string to data
    /// </summary>
    public static class HexHelper
    {
        /// <summary>
        /// metho convert data to hex string - to save to database
        /// </summary>
        /// <param name="Bytes">byte array that represents file -data</param>
        /// <returns></returns>
        public static string ByteArrayToHexString(byte[] bytes)
        {
            StringBuilder Result = new StringBuilder(bytes.Length * 2);
            string hexalphabet = "0123456789ABCDEF";

            foreach (byte kolejny in bytes)
            {
                Result.Append(hexalphabet[(int)(kolejny >> 4)]);//dolny
                Result.Append(hexalphabet[(int)(kolejny & 0xF)]);//górny
            }

            return Result.ToString();
        }

        /// <summary>
        /// method convert hexencoded data to pure data
        /// </summary>
        /// <param name="hexstring"></param>
        /// <returns></returns>
        public static byte[] HexStringToByteArray(string hexstring)
        {
            byte[] bajts = new byte[hexstring.Length / 2];
            int[] hexalphabet = new int[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05,
                    0x06, 0x07, 0x08, 0x09, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,//7 zer na roznice w ascii pomiedzy cyframi i alfabetem -znaki 58 - 54
                    0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };

            for (int x = 0, i = 0; i < hexstring.Length; i += 2, x += 1)
            {
                bajts[x] = (byte)(hexalphabet[Char.ToUpper(hexstring[i + 0]) - '0'] << 4 |//górne
                                  hexalphabet[Char.ToUpper(hexstring[i + 1]) - '0']); //dolne
            }

            return bajts;//to moze byc zapisane jako plik
        }
    }
}