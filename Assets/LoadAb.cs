/****************************************************
    文件：LoadAb.cs
	作者：Plane
    邮箱: 1785275942@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System.IO;
using UnityEngine;

public class LoadAb : MonoBehaviour 
{

    private void Start()
    {
        InstanceBundle("cube", "Sphere");
    }

    void InstanceBundle(string bundleName,string assetName)
    {
        AssetBundle asset = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, bundleName));
        var asset_obj = asset.LoadAsset<GameObject>(assetName);
        Instantiate(asset_obj);
    }
}