using UnityEngine;
using UnityEngine.UI;

public class TitleDialog : MonoBehaviour
{
    [SerializeField] private Text txtUserName;
    [SerializeField] private Text txtTrophy;

    public void Init(RankProduct rankProduct)
    {
        txtUserName.text = rankProduct.nickName;
        txtTrophy.text = rankProduct.trophy.ToString();
    }
}
