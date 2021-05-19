using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDialog : RecyclingListViewItem,IPointerClickHandler
{
    [SerializeField] private Text txtRanking;
    [SerializeField] private Text txtUserName;
    [SerializeField] private Image imgRanking;
    [SerializeField] private Image imgRank;
    [SerializeField] private Text txtTrophy;
    [SerializeField] private Image itemBackGround;
    [SerializeField] private TipsDialog tipsDialog;
    
    [SerializeField] private List<Sprite> rankingList;
    [SerializeField] private List<Sprite> itemBackGroundList;
    [SerializeField] private List<Sprite> rankList;

    private int ranking;
    private RankProduct m_RankProduct;
    
    //初始化
    public void Init(RankProduct rankProduct,TipsDialog tipsDialog)
    {
        ranking = rankProduct.rank;     //排名
        this.tipsDialog = tipsDialog;   //提示页面
        m_RankProduct = rankProduct;    //数据列表
        
        if (ranking < 3)                //前三名
        {
            txtRanking.gameObject.SetActive(false);
            imgRanking.gameObject.SetActive(true);
            imgRanking.sprite = rankingList[ranking];
            itemBackGround.sprite = itemBackGroundList[ranking];
        }
        else
        {
            txtRanking.gameObject.SetActive(true);
            imgRanking.gameObject.SetActive(false);
            txtRanking.text = (ranking+1).ToString();
            itemBackGround.sprite = itemBackGroundList[3];
        }

        txtUserName.text = rankProduct.nickName;
        txtTrophy.text = rankProduct.trophy.ToString();

        imgRank.sprite = rankList[rankProduct.trophy / 1000];
    }

    //Toast 消息框
    public void OnPointerClick(PointerEventData eventData)
    {
        tipsDialog.Init(m_RankProduct,ranking);
    }
}
