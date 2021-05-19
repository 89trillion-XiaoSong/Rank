using System.Collections.Generic;
using SuperScrollView;
using UnityEngine;
using UnityEngine.UI;

public class RankDialog : MonoBehaviour
{
    [SerializeField] private Text txtCountDown;
    [SerializeField] private ItemDialog rankItem;
    [SerializeField] private TipsDialog tipsDialog;
    [SerializeField] private TitleDialog titleDialog;
    
    [HideInInspector] public TimeUtils timeUtils;
    
    public Transform content;
    public int countDown;                                  //倒计时

    private List<RankProduct> m_RankProductList = new List<RankProduct>();      //数据列表
    public LoopListView2 mLoopListView;                                         //列表复用
    
    public RecyclingListView scrollList;
    
    //初始化页面
    public void Init()
    {
        ItemConfig itemConfig = new ItemConfig();
        m_RankProductList = itemConfig.rankProductList;
        countDown = itemConfig.countDown;
        
        InitItem();

        timeUtils.CountDownChange += SetCountDown;
        
        //列表复用
        scrollList.ItemCallback = PopulateItem;
        scrollList.RowCount = m_RankProductList.Count;
    }


    private void PopulateItem(RecyclingListViewItem item, int rowIndex)
    {
        var child = item as ItemDialog;
        child.Init(m_RankProductList[rowIndex],tipsDialog);
    }
    
    //初始化item
    private void InitItem()
    {
        ListSort.Sort(m_RankProductList);

        titleDialog.Init(m_RankProductList[0],0);
        
        int listCount = m_RankProductList.Count;
        for (int i = 0; i < listCount; i++)
        {
            RankProduct rankProduct = m_RankProductList[i];
            rankProduct.rank = i;
            m_RankProductList[i] = rankProduct;
        }
    }
    

    //关闭页面
    public void CloseRankDialog()
    {
        gameObject.SetActive(false);
    }

    //刷新倒计时text
    private void SetCountDown(int timeCount)
    {
        txtCountDown.text = TimeUtils.GetTime(timeCount);
        txtCountDown.text = TimeUtils.GetTime(timeCount);
    }
}
