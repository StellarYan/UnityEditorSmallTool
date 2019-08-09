using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ExecutableScript
{
    public abstract class ExecutableScriptBase : ScriptableObject
    {
        private Editor editor;
        public abstract void Excute();
        public void DrawInGUI()
        {
            if (editor == null) editor = Editor.CreateEditor(this);

            editor.DrawDefaultInspector();
        }
    }
}

