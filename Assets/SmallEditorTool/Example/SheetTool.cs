using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
namespace SmallEditorTool
{
	public class SheetTool : SmallEditorToolBase
	{
		public GameObject[] prefabs;
		Dictionary<GameObject, List<SerializedProperty>> sheet;
		SheetWindow sheetWindow;
		public override void Excute()
		{
			if (sheet != null) SyncToPrefabs();
			BuildSheet();
			DisplaySheet();
		}

		private void BuildSheet()
		{
			sheet = new Dictionary<GameObject, List<SerializedProperty>>();
			if (prefabs == null) return;
			foreach (var prefab in prefabs)
			{
				sheet.Add(prefab,new List<SerializedProperty> ());
				foreach (var comp in prefab.GetComponents<MonoBehaviour>())
				{
					SerializedObject so = new SerializedObject(comp);
					var it = so.GetIterator();
					it.Next(true);
					for (; it.Next(false); )
					{
						var Attrfield= System.Array.Find(comp.GetType().GetFields(),
							(f) => f.Name == it.name && f.GetCustomAttributes(typeof(InSheetFieldAttribute), true).Length > 0);
						if(Attrfield!=null)
						{
							sheet[prefab].Add(so.FindProperty(it.name));
						}
					}
				}
			}
		}

		private void SyncToPrefabs()
		{

		}

		private void DisplaySheet()
		{
			sheetWindow = EditorWindow.GetWindow<SheetWindow>();
			sheetWindow.sheet = sheet;
		}
	}

	public class SheetWindow : EditorWindow
	{
		public Dictionary<GameObject, List<SerializedProperty>> sheet;
		void OnGUI()
		{
			foreach (var p in sheet)
			{
				GUILayout.BeginHorizontal();
				GUILayout.Label(p.Key.name);
				foreach (var item in p.Value)
				{
					
					EditorGUILayout.PropertyField(item);
				}
				GUILayout.EndHorizontal();
			}
		}
	}


	public class InSheetFieldAttribute : System.Attribute
	{

	}
}
