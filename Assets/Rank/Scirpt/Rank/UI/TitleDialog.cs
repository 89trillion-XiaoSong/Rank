using UnityEngine;
using UnityEngine.UI;

public class TitleDialog : MonoBehaviour
{
    [SerializeField] private Text txtUserName;
    [SerializeField] private Text txtTrophy;

    /// <summary>
    /// 标题数据
    /// </summary>
    /// <param name="rankProduct"></param>
    public void Init(RankProduct rankProduct)
    {
        txtUserName.text = rankProduct.nickName;
        txtTrophy.text = rankProduct.trophy.ToString();
    }
}
