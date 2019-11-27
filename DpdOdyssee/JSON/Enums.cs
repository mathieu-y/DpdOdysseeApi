using System;
using System.Collections.Generic;
using System.Text;

namespace YardConsulting.DpdOdyssee
{
    public enum LabelFormat { A4, A6 };
    public enum FileType { PDF, DPL, ZPL, EPL, FPL }
    public enum LabelDPI : long { dpi203 = 203, dpi300 = 300, dpi600 = 600 }
    public enum DPDProduct : long { DpdClassic = 1, DpdClassicIntercontinental = 40033, DpdPredict = 40275, DpdRelais = 40276, DpdRetour = 40278 }
}
