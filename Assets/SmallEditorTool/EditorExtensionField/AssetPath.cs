using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SmallEditorTool
{
    [System.Serializable]
    public struct AssetPath
    {
        public string path;

        public string GetUnityAssetLocalPath()
        {
            if (path.Contains(Application.dataPath))
            {
                return "Assets" + path.Substring(Application.dataPath.Length, path.Length - Application.dataPath.Length);
            }
            else return null;
        }
    }


    [CustomPropertyDrawer(typeof(AssetPath))]
    public class AssetPathDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUILayout.BeginHorizontal();
            property.Next(true);
            EditorGUILayout.LabelField(property.stringValue);
            if (GUILayout.Button("Browse"))
            {
                //Unity处理Path时似乎都是默认正斜杠，与环境无关
                property.stringValue = UnityEditor.EditorUtility.OpenFolderPanel("Browse", "", "") + '/';
            }
            EditorGUILayout.EndHorizontal();
        }
    }
}