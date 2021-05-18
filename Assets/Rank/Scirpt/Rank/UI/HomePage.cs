using UnityEngine;

public class HomePage : MonoBehaviour
{
    [SerializeField] private RankDialog prbRank;
    [SerializeField] private TimeUtils m_TimeUtils;
    
    private RankDialog rankTable;
    private bool isInit;
    
    /// <summary>
    /// 打开排行榜
    /// </summary>
    public void OpenRank()
    {
        if (!isInit)
        {
            rankTable= Instantiate(prbRank,transform);
            isInit = true;
            rankTable.timeUtils = m_TimeUtils;
            rankTable.Init();
            
            m_TimeUtils.InitCountDown(rankTable.countDown);
        }
        else
        {
            rankTable.gameObject.SetActive(true);
        }
    }
}
