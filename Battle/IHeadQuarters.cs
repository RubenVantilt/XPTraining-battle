using System;
using System.Collections.Generic;
using System.Text;

namespace Battle
{
    public interface IHeadQuarters
    {
        int ReportEnlistment(string soldierName);
        
        void ReportCasualty(int soldierId);

        void ReportVictory(int remainingNumberOfSoldiers);

    }
}
