using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicPaper
{
    public interface IPaperDispatcher
    {
        void Dispatch(ElectronicPaper ePaper);
    }
}