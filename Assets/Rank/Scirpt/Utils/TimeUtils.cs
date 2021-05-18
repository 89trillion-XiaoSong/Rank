using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUtils : MonoBehaviour
{
    //每秒调用事件去刷新text
    public delegate void countDownHanlder(int timeCount);
    public event countDownHanlder CountDownChange;
    
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

    //开始倒计时协程
    public void InitCountDown(int countDown)
    {
        StartCoroutine(CountDown(countDown));
    }

    //倒计时协程
    private IEnumerator CountDown(int timeCount)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (timeCount > 0)
        {
            yield return waitForSeconds;
            timeCount--;
            
            if (CountDownChange != null)
            {
                CountDownChange(timeCount);
            }
        }
    }
}
