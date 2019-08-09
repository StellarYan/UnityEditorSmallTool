using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace ExecutableScript.TestTools
{
    /// <summary>
    /// 如果没有CustomEditor，customeProperty的layout事件不会被触发，导致repaint时报错
    /// </summary>
    [CustomEditor(typeof(ExecutableScriptBase),true)]
    public class ExecutableScriptBaseEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if(GUILayout.Button("Execute"))
            {
                (target as ExecutableScriptBase).Excute();
            }
        }
    }
}
