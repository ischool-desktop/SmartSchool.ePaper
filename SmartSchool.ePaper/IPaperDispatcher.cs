using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSchool.ePaper
{
    public interface IPaperDispatcher
    {
        void Dispatch(ElectronicPaper ePaper);
    }
}