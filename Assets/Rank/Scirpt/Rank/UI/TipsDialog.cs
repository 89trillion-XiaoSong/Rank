using UnityEngine;
using UnityEngine.UI;

public class TipsDialog : MonoBehaviour
{
    [SerializeField] private Text txtUser;
    [SerializeField] private Text txtRank;

    //消息框初始化
    public void Init(RankProduct rankProduct,int ranking)
    {
        txtUser.text = "User:" + rankProduct.uid;
        txtRank.text = "Rank:" + (ranking + 1);
        
        gameObject.SetActive(true);
    }

    //关闭
    public void Close()
    {
        gameObject.SetActive(false);
    }
}
