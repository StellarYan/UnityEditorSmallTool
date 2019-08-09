using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace ExecutableScript.TestTools
{
    [CreateAssetMenu(fileName = "CreateObjectSmallTool",menuName = "EditorExeScript/CreateObjectSmallTool")]
    public class CreateObjectSmallTool : ExecutableScriptBase
    {
        public GameObject goToAdd;
        public int count;
        public AssetPath path;

        public override void Excute()
        {
            for (int i = 0; i < count; i++)
            {
                PrefabUtility.CreatePrefab(path.path + i + ".prefab", goToAdd);
            }

        }
    }
}
