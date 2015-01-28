using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicPaper
{
    public interface IProgressReceiver
    {
        void ProcessStart();

        void ProcessEnd();

        void ProcessProgress(int progress);
    }
}
