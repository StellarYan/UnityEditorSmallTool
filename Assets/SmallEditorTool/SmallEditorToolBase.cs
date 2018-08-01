using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SmallEditorTool
{
    [CustomEditor(typeof(SmallEditorToolBase))]
    public class SmallEditorToolEditor : Editor
    {
    }

    public abstract class SmallEditorToolBase : ScriptableObject
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

