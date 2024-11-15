﻿namespace SE;
    
    ///<summary>
    /// Contains the datatype that store the data that the app uses
    /// 
    /// Author: Gabriel Tower
    /// Written: 11/2023
    /// 
    /// Kilroy Was Here
    ///</summary>

    /// <summary>
    /// Defines the data that will be carried over from match to match
    /// </summary>
   public struct LastMatchInfo
    {
        public string scoutName;
        public int matchNumber;
    }

    /// <summary>
    /// Defines all the data that the app will collect during a match
    /// </summary>
    public struct Match
    {
        public string scoutName;
        public int matchNumber;
        public int teamNumber;

        public bool isBlue;

        public string auto1;
        public string auto2;
        public string auto3;
        public string auto4;
        public string auto5;
        public string auto6;
        public string auto7;
        public string teleop1;
        public string teleop2;
        public string teleop3;
        public string teleop4;
        public string teleop5;
        public string teleop6;
        public string teleop7;

        public int robotSpeed;
        public int givesDefense;
        public int takesDefense;

        public bool robotDied;
        public bool fieldFault;

        public int TimeSpan;
    }