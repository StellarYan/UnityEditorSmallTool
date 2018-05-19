using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestTool : SmallToolBase
{
    public AssetPath ap;
    public FieldSingleSelector fs;
    public GameObject go;
    public override void Excute()
    {
        Debug.Log(ap.path);
        string localPath = ap.GetUnityAssetLocalPath();
        if (localPath != null)
        {
            PrefabUtility.CreatePrefab(localPath + "x.prefab", go);
        }
        else Debug.Log("Not Unity Asset Path");
        



    }
}