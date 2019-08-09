using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace ExecutableScript.TestTools
{
    [CreateAssetMenu(fileName = "PrefabRename", menuName = "EditorExeScript/PrefabRename")]
    public class PrefabRename : ExecutableScriptBase
	{
		public GameObject prefab;
		public string newName;
		public override void Excute()
		{
			AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(prefab), newName);
			prefab.name = newName;
		}
	}
}
