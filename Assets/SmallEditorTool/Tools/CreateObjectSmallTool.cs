using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace SmallEditorTool.TestTools
{
    public class CreateObjectSmallTool : SmallEditorToolBase
    {
        public GameObject goToAdd;
        public int count;
        public string path;

        public override void Excute()
        {
            for (int i = 0; i < count; i++)
            {
                PrefabUtility.CreatePrefab(path + i + ".prefab", goToAdd);
            }

        }
    }
}
