using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;

namespace ExecutableScript
{

    public class ScriptObjectInfomation
    {
        public int instanceId;
        public string json;
        public string name;
    }

    [CreateAssetMenu(fileName = "JsonApplyToScriptObjectTool", menuName = "EditorExeScript/JsonApplyToScriptObjectTool")]
    public class JsonApplyToScriptObjectTool : ExecutableScriptBase
    {
        public TextAsset jsonText;
        public override void Excute()
        {
            List<ScriptObjectInfomation> soList = new List<ScriptObjectInfomation>();
            string jtext = jsonText.text;
            JsonTextReader reader = new JsonTextReader(new StringReader(jtext));
            JObject jo = JObject.Parse(jtext);
            JArray arr = jo.First.First.Value<JArray>();
            foreach (var hso in arr)
            {
                var chsoEnumerator = hso.Children().GetEnumerator();
                chsoEnumerator.MoveNext();
                int id = chsoEnumerator.Current.First.Value<int>();
                chsoEnumerator.MoveNext();
                string name = chsoEnumerator.Current.First.Value<string>();
                chsoEnumerator.MoveNext();
                string s = chsoEnumerator.Current.First.Value<JObject>().ToString();
                soList.Add(new ScriptObjectInfomation() { instanceId = id, json = s ,name=name});
            }


            foreach (var so in soList)
            {
                Object obj = EditorUtility.InstanceIDToObject(so.instanceId);
                if (obj != null)
                {
                    JsonUtility.FromJsonOverwrite(so.json, obj);
                    obj.name = so.name;
                }
            }
        }
    }
}
