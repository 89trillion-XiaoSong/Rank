﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class TimeUtils : MonoBehaviour
{
    /// <summary>
    /// 时间格式化
    /// </summary>
    /// <param name="countDown"></param>
    /// <returns></returns>
    public static string GetTime(int countDown)
    {
        TimeSpan timeSpan = new TimeSpan(0,0, 0, countDown);
        int s = timeSpan.Seconds;
        int m = timeSpan.Minutes;
        int h = timeSpan.Hours;
        int d = timeSpan.Days;

        return string.Format("End in:{0}d {1}h {2}m {3}s", d, h, m, s);
    }

    //列表排序
    public static void GetList(List<RankProduct> list)
    {
        list.Sort(
            delegate(RankProduct p1, RankProduct p2)
            {
                return p2.trophy.CompareTo(p1.trophy);
            }
            );
    }
}
