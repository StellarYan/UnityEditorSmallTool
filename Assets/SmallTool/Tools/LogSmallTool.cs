using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSmallTool : SmallToolBase {
    public string s;
    public override void Excute()
    {
        Debug.Log(s);
    }

    
}
