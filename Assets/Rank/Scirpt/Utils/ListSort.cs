using System.Collections.Generic;
using UnityEngine;

public class ListSort : MonoBehaviour
{
    //列表排序
    public static void Sort(List<RankProduct> list)
    {
        list.Sort(
            delegate(RankProduct p1, RankProduct p2)
            {
                return p2.trophy.CompareTo(p1.trophy);
            }
        );
    }
}
