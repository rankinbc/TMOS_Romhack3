using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmos.Romhacks.Core;

namespace Tmos.Romhacks.UI.Images
{
    public static class ImageFileManager
    {
        const string TileImagesPath = "Images/TileImages/{0}";
        public static string GetTileImagePath(int tileValue) 
        {
            return String.Format(TileImagesPath, GetTileFileName(tileValue));
        }
        private static string GetTileFileName(int tileValue)
        {
            switch (tileValue)
            {
                case 0x00: return "00.png";
                case 0x01: return "01.png";
                case 0x02: return "02.png";
                case 0x03: return "03.png";
                case 0x04: return "04.png";
                case 0x05: return "05.png";
                case 0x06:
                case 0x0D:
                case 0x0E:
                case 0x0F:
                case 0x10:
                case 0x14:
                case 0x15:
                case 0x16:
                case 0x17:
                case 0x18:
                case 0x19:
                case 0x1A: return "0D.png";
                case 0x07:
                case 0x08:
                case 0x09:
                case 0x0A:
                case 0x11: return "08.png";
                case 0x0B:
                case 0x20: return "20.png";
                case 0x0C: return "0C.png";
                case 0x12: return "12.png";
                case 0x1B: return "1B.png";
                case 0x1E: return "1E.png";
                case 0x1F: return "1F.png";
                case 0x21: return "21.png";
                case 0x22: return "22.png";
                case 0x23: return "23.png";
                case 0x24:
                case 0x25: return "25.png";
                case 0x26: return "26.png";
                case 0x2B:
                case 0x2C:
                case 0x2D:
                case 0x2E:
                case 0x37:
                case 0x38:
                case 0x39:
                case 0x3A:
                case 0x3B:
                case 0x3C:
                case 0x3D:
                case 0x3E:
                case 0x43: return "43.png";
                case 0x2F:
                case 0x30:
                case 0x3F: return "3F.png";
                case 0x32: return "41.png";
                case 0x33:
                case 0x34:
                case 0x40: return "40.png";
                case 0x41: return "41.png";
                case 0x42: return "42.png";
                case 0x44: return "44.png";
                case 0x47: return "47.png";
                case 0x48: return "48.png";
                case 0x4A: return "4A.png";
                case 0x4C: return "4C.png";
                case 0x4D: return "4D.png";
                case 0x4E: return "4E.png";
                case 0x53: return "53.png";
                case 0x54: return "54.png";
                case 0x55: return "55.png";
                case 0x56: return "56.png";
                case 0x57: return "57.png";
                case 0x58: return "58.png";
                case 0x59: return "59.png";
                case 0x5A: return "5A.png";
                case 0x5B: return "5B.png";
                case 0x5C: return "5C.png";
                case 0x5D: return "5D.png";
                case 0x5E: return "5E.png";
                case 0x5F: return "5F.png";
                case 0x60: return "60.png";
                case 0x61: return "61.png";
                case 0x62: return "62.png";
                case 0x63: return "63.png";
                case 0x64: return "64.png";
                case 0x65: return "65.png";
                case 0x67: return "67.png";
                case 0x68: return "68.png";
                case 0x6B: return "6B.png";
                case 0x6F: return "6F.png";
                case 0x70: return "70.png";
                case 0x71: return "71.png";
                case 0x72: return "72.png";
                case 0x73:
                case 0xED:
                case 0xF3: return "03.png";
                case 0x76: return "76.png";
                case 0x77: return "77.png";
                case 0x78: return "78.png";
                case 0x7A: return "7A.png";
                case 0x7B: return "7B.png";
                case 0x7C: return "7C.png";
                case 0x7D: return "7D.png";
                case 0x7F: return "7F.png";
                case 0x79: return "26.png";
                case 0x80: return "80.png";
                case 0x81: return "81.png";
                case 0x82: return "82.png";
                case 0x83: return "83.png";
                case 0x84: return "84.png";
                case 0x86: return "86.png";
                case 0x87: return "87.png";
                case 0x88: return "88.png";
                case 0x89: return "89.png";
                case 0x8A: return "8A.png";
                case 0x8C: return "8C.png";
                case 0x8D: return "8D.png";
                case 0x8E: return "8E.png";
                case 0x8F: return "8F.png";
                case 0x92: return "92.png";
                case 0x93: return "93.png";
                case 0x94: return "94.png";
                case 0x95: return "95.png";
                case 0x96: return "96.png";
                case 0x97: return "97.png";
                case 0x98: return "98.png";
                case 0x99: return "99.png";
                case 0x9A: return "9A.png";
                case 0x9B: return "9B.png";
                case 0x9C: return "9C.png";
                case 0x9D: return "9D.png";
                case 0x9E: return "9E.png";
                case 0x9F: return "9F.png";
                case 0xA1: return "A1.png";
                case 0xA2: return "A2.png";
                case 0xA3: return "A3.png";
                case 0xA4: return "A4.png";
                case 0xA5: return "A5.png";
                case 0xA6: return "A6.png";
                case 0xA8: return "A8.png";
                case 0xA9:
                case 0xE2: return "A9.png";
                case 0xAA:
                case 0xAB:
                case 0xAF: return "AA.png";
                case 0xAC: return "AC.png";
                case 0xAD: return "AD.png";
                case 0xB0: return "B0.png";
                case 0xB1: return "B1.png";
                case 0xB2: return "B2.png";
                case 0xB3: return "B3.png";
                case 0xB5: return "B5.png";
                case 0xB8: return "B8.png";
                case 0xB9: return "B9.png";
                case 0xBC: return "BC.png";
                case 0xBD: return "BD.png";
                case 0xBE: return "BE.png";
                case 0xBF: return "BF.png";
                case 0xC0: return "C0.png";
                case 0xC1: return "C1.png";
                case 0xC2: return "C2.png";
                case 0xC3: return "C3.png";
                case 0xC4: return "C4.png";
                case 0xC5: return "C5.png";
                case 0xC6: return "C6.png";
                case 0xC7: return "C7.png";
                case 0xCF: return "CF.png";
                case 0xD0: return "D0.png";
                case 0xD5:
                case 0xD6: return "D6.png";
                case 0xDA: return "DA.png";
                case 0xDC: return "DC.png";
                case 0xDD: return "DD.png";
                case 0xDE: return "DE.png";
                case 0xE0: return "E0.png";
                case 0xE1: return "E1.png";
                case 0xE6: return "E6.png";
                case 0xE7: return "E7.png";
                case 0xE9: return "E9.png";
                case 0xEA: return "EA.png";
                case 0xEB: return "EB.png";
                case 0xEC: return "EC.png";
                case 0xEE: return "EE.png";
                case 0xEF: return "EF.png";
                case 0xF0: return "F0.png";
                case 0xF1: return "F1.png";
                case 0xF2: return "F2.png";
                case 0xF4: return "F4.png";
                case 0xF5: return "F5.png";
                case 0xF6: return "F6.png";
                case 0xF7: return "F7.png";
                case 0xF8: return "F8.png";
                case 0xF9: return "F9.png";
                case 0xFA: return "FA.png";
                case 0xFB: return "FB.png";
                case 0xFC: return "FC.png";
                case 0xFD: return "FD.png";
                case 0xFE: return "FE.png";
                case 0xFF: return "FF.png";
                default: return "unknown.png";
            }
        }


    }
}

