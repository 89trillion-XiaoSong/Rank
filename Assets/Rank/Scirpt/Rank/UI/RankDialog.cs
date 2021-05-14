using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankDialog : MonoBehaviour
{
    [SerializeField] private Text txtCountDown;
    [SerializeField] private ItemDialog rankItem;
    [SerializeField] private TipsDialog tipsDialog;
    [SerializeField] private TitleDialog titleDialog;
    
    public Transform content;

    private List<RankProduct> m_RankProductList = new List<RankProduct>();
    private List<ItemDialog> m_ItemConfigs = new List<ItemDialog>();

    private int countDown;

    //初始化页面
    public void Init()
    {
        ItemConfig itemConfig = new ItemConfig();
        m_RankProductList = itemConfig.rankProductList;
        countDown = itemConfig.countDown;
        
        InitCountDown();
        InitItem();
    }

    //初始化item
    private void InitItem()
    {
        TimeUtils.GetList(m_RankProductList);

        titleDialog.Init(m_RankProductList[0]);
        
        int listCount = m_RankProductList.Count;
        for (int i = 0; i < listCount; i++)
        {
            ItemDialog itemDialog = Instantiate(rankItem, content);
            itemDialog.Init(m_RankProductList[i], i,tipsDialog);
            m_ItemConfigs.Add(itemDialog);
        }
    }
    

    //关闭页面
    public void CloseRankDialog()
    {
        gameObject.SetActive(false);
    }

    //倒计时
    private void InitCountDown()
    {
        StartCoroutine(CountDown(countDown));
    }
    
    //倒计时协程
    private IEnumerator CountDown(int timeCount)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (timeCount > 0)
        {
            txtCountDown.text = TimeUtils.GetTime(timeCount);
            yield return waitForSeconds;
            timeCount--;
            txtCountDown.text = TimeUtils.GetTime(timeCount);
        }
    }
}
