using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsDialog : MonoBehaviour
{
    [SerializeField] private Text txtUser;
    [SerializeField] private Text txtRank;

    public void Init(RankProduct rankProduct,int ranking)
    {
        txtUser.text = "User:" + rankProduct.uid;
        txtRank.text = "Rank:" + (ranking + 1);
        
        gameObject.SetActive(true);
    }


    public void Close()
    {
        gameObject.SetActive(false);
    }
}
