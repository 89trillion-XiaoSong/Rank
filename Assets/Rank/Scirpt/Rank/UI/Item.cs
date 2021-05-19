using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : RecyclingListViewItem,IPointerClickHandler
{
    [SerializeField] private Text txtRanking;
    [SerializeField] private Text txtUserName;
    [SerializeField] private Image imgRanking;
    [SerializeField] private Image imgRank;
    [SerializeField] private Text txtTrophy;
    [SerializeField] private Image itemBackGround;
    [SerializeField] private TipsDialog tipsDialog;
    
    private int ranking;
    private RankProduct m_RankProduct;
    
    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="rankProduct"></param>
    /// <param name="tipsDialog"></param>
    public void Init(RankProduct rankProduct,TipsDialog tipsDialog)
    {
        ranking = rankProduct.rank;     //排名
        this.tipsDialog = tipsDialog;   //提示页面
        m_RankProduct = rankProduct;    //数据列表
        
        if (ranking < 3)                //前三名
        {
            txtRanking.gameObject.SetActive(false);
            imgRanking.gameObject.SetActive(true);
            
            imgRanking.sprite = Resources.Load<Sprite>("Rank/rank_" + (ranking + 1));
            itemBackGround.sprite = Resources.Load<Sprite>("RankList/rank list_" + (ranking + 1));
        }
        else
        {
            txtRanking.gameObject.SetActive(true);
            imgRanking.gameObject.SetActive(false);
            txtRanking.text = (ranking+1).ToString();
            itemBackGround.sprite = Resources.Load<Sprite>("RankList/rank list_normal");
        }

        txtUserName.text = rankProduct.nickName;
        txtTrophy.text = rankProduct.trophy.ToString();
        imgRank.sprite = Resources.Load<Sprite>("Dan/arenaBadge_" + (rankProduct.trophy / 1000 + 1));
    }

    /// <summary>
    /// Toast 消息框
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        tipsDialog.Init(m_RankProduct,ranking);
    }
}
