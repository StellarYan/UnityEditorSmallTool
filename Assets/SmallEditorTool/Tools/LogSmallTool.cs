using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SmallEditorTool.TestTools
{
    public class LogSmallTool : SmallEditorToolBase
    {
        public string s;
        public override void Excute()
        {
            Debug.Log(s);
        }


    }
}
