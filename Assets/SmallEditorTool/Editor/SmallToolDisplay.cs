using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SmallEditorTool
{

    public class SmallEditorToolDisplay : EditorWindow
    {
        [MenuItem("Window/SmallEditorTool")]
        private static void ShowWindow()
        {
            EditorWindow.GetWindow(typeof(SmallEditorToolDisplay));
        }

        public MonoScript smallEditorToolScript;
        public SmallEditorToolBase smallTool;

        void OnGUI()
        {
            GUILayout.Label("Unity Small Editor Tool", EditorStyles.boldLabel);
            smallEditorToolScript = EditorGUILayout.ObjectField("Small Editor Tool Script", smallEditorToolScript, typeof(MonoScript), true) as MonoScript;
            if (smallEditorToolScript != null && smallEditorToolScript.GetClass().IsSubclassOf(typeof(SmallEditorToolBase)))
            {
                if (smallTool == null || smallTool.GetType() != smallEditorToolScript.GetClass())
                {
                    smallTool = ScriptableObject.CreateInstance(smallEditorToolScript.GetClass()) as SmallEditorToolBase;
                }

            }
            if (smallTool != null)
            {
                smallTool.DrawInGUI();
            }
            bool isExcute = GUILayout.Button("Excute");
            if (smallTool != null && isExcute)
            {
                smallTool.Excute();
            }

        }
    }



}
