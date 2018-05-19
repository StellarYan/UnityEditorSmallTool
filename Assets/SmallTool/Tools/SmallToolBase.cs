using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(SmallToolBase))]
public class SmallToolEditor : Editor
{
}

public abstract class SmallToolBase : ScriptableObject{
    private Editor editor;
    public abstract void Excute();
	public void DrawInGUI()
    {
        if(editor==null) editor = Editor.CreateEditor(this);
        
        editor.DrawDefaultInspector();
    }
}

