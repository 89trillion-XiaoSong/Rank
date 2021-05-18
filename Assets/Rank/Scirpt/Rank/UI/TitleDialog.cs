using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TitleDialog : MonoBehaviour
{
    [SerializeField] private Text txtUserName;
    [SerializeField] private Text txtTrophy;
    [SerializeField] private Text txtRanking;
    [SerializeField] private Image imgRanking;
    [SerializeField] private Image imgRank;

    [SerializeField] private List<Sprite> rankingList;
    [SerializeField] private List<Sprite> rankList;
    /// <summary>
    /// 标题数据
    /// </summary>
    /// <param name="rankProduct"></param>
    public void Init(RankProduct rankProduct,int ranking)
    {
        txtUserName.text = rankProduct.nickName;
        txtTrophy.text = rankProduct.trophy.ToString();
        if (ranking < 3)
        {
            txtRanking.gameObject.SetActive(false);
            imgRanking.gameObject.SetActive(true);
            imgRanking.sprite = rankingList[ranking];
        }
        else
        {
            txtRanking.gameObject.SetActive(true);
            txtRanking.gameObject.SetActive(false);
            txtRanking.text = (ranking + 1).ToString();
        }

        imgRank.sprite = rankList[rankProduct.trophy / 1000];
    }
}
