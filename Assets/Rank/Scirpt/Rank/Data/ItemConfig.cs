using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public struct RankProduct
{
    public string uid;
    public string nickName;
    public int avatar;
    public int trophy;
    public int rank;
}

public class ItemConfig
{
    public List<RankProduct> rankProductList = new List<RankProduct>();
    public int countDown;

    public ItemConfig()
    {
        JsonLoad();
    }

    /// <summary>
    /// 加载JSON文件
    /// </summary>
    private void JsonLoad()
    {
        var jsonFile = Resources.Load<TextAsset>("Json/ranklist");
        JSONNode jsonData = JSONNode.Parse(jsonFile.text);

        countDown = jsonData["countDown"];
        JSONArray dataArray = jsonData["list"].AsArray;

        foreach (JSONNode node in dataArray)
        {
            RankProduct rankProduct = new RankProduct();

            rankProduct.uid = node["uid"];
            rankProduct.nickName = node["nickName"];
            rankProduct.avatar = node["avatar"].AsInt;
            rankProduct.trophy = node["trophy"].AsInt;
            
            rankProductList.Add(rankProduct);
        }
    }
}
