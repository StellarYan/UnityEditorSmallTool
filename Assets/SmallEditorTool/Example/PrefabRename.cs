using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace SmallEditorTool.TestTools
{
	public class PrefabRename : SmallEditorToolBase
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
