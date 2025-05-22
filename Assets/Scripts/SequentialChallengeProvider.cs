using System;
using System.Collections.Generic;
using UnityEngine;

public static class SequentialChallengeProvider
{
   
    static readonly List<string> challenges = new List<string>()
    {
        "Do 25 jumping jacks!",
        "Hold a 1-minute plank!",
        "Do 15 push-ups!",
        "Run in place for 2 minutes!",
        "Do 20 squats!",
        "Stretch for 5 minutes!",
        "Try 10 lunges per leg!",
        "Do a 30-second wall sit!",
        "Perform 20 mountain climbers!",
        "Walk or jog for 10 minutes!"
    };

    
    public static int GetDayNumber()
    {
        string reg = PlayerPrefs.GetString("regDate", "");
        DateTime regDate;
        if (!DateTime.TryParse(reg, out regDate))
        {
            
            regDate = DateTime.Now;
            PlayerPrefs.SetString("regDate", regDate.ToString("yyyy-MM-dd"));
            PlayerPrefs.Save();
        }

        int delta = (DateTime.Now.Date - regDate.Date).Days;
        int dayNum = delta + 1;
        if (dayNum < 1) dayNum = 1;
        if (dayNum > challenges.Count) dayNum = challenges.Count;
        return dayNum;
    }

   
    public static string GetChallengeText()
    {
        int day = GetDayNumber();
        return challenges[day - 1];
    }

 
    public static int GetTotalDays()
    {
        return challenges.Count;
    }
}
