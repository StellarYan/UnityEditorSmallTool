using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ExecutableScript.TestTools
{
    [CreateAssetMenu(fileName = "LogSmallTool", menuName = "EditorExeScript/LogSmallTool")]
    public class LogSmallTool : ExecutableScriptBase
    {
        public string s;
        public override void Excute()
        {
            Debug.Log(s);
        }


    }
}
