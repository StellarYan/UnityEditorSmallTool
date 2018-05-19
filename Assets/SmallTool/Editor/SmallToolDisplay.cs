using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SmallToolDisplay : EditorWindow
{
    [MenuItem("Window/SmallTool")]
    private static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(SmallToolDisplay));
    }

    public MonoScript smallToolScript;
    public SmallToolBase smallTool;

    void OnGUI()
    {
        GUILayout.Label("Unity Small Tool", EditorStyles.boldLabel);
        smallToolScript = EditorGUILayout.ObjectField("small tool script", smallToolScript, typeof(MonoScript),true) as MonoScript;
        if (smallToolScript != null && smallToolScript.GetClass().IsSubclassOf(typeof(SmallToolBase)))
        {
            if(smallTool==null || smallTool.GetType()!= smallToolScript.GetClass())
            {
                smallTool = ScriptableObject.CreateInstance(smallToolScript.GetClass()) as SmallToolBase;
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


