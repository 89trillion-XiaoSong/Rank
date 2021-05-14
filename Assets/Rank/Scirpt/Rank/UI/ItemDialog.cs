using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDialog : MonoBehaviour,IPointerClickHandler
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
    public void Init(RankProduct rankProduct,int ranking,TipsDialog tipsDialog)
    {
        this.ranking = ranking;
        this.tipsDialog = tipsDialog;
        m_RankProduct = rankProduct;
        
        if (ranking < 3)
        {
            txtRanking.gameObject.SetActive(false);
            imgRanking.gameObject.SetActive(true);
            imgRanking.sprite = rankingList[ranking];
            itemBackGround.sprite = itemBackGroundList[ranking];
        }
        else
        {
            txtRanking.text = (ranking+1).ToString();
        }

        txtUserName.text = rankProduct.nickName;
        txtTrophy.text = rankProduct.trophy.ToString();

        imgRank.sprite = rankList[rankProduct.trophy / 1000];
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        tipsDialog.Init(m_RankProduct,ranking);
    }
}
