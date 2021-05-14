using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePage : MonoBehaviour
{
    [SerializeField] private RankDialog prbRank;

    private RankDialog rankTable;
    private bool isInit;
    
    public void OpenRank()
    {
        if (!isInit)
        {
            rankTable= Instantiate(prbRank,transform);
            isInit = true;
            rankTable.Init();
        }
        else
        {
            rankTable.gameObject.SetActive(true);
        }
    }
}
