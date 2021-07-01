﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStatesCensusAnalyser.POCO
{
    public class StateCodeDAO
    {
        public int serialNumber;
        public string stateName;
        public int tin;
        public string stateCode;
        public StateCodeDAO(string serailNumber, string stateName, string tin, string stateCode)
        {
            this.serialNumber = Convert.ToInt32(serialNumber);
            this.stateName = stateName;
            this.tin = Convert.ToInt32(tin);
            this.stateCode = stateCode;
        }
    }
}
