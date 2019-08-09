using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using Newtonsoft.Json;
using System.Text;

namespace ExecutableScript
{
    [CreateAssetMenu(fileName = "ScriptObjectToJsonTool", menuName = "EditorExeScript/ScriptObjectToJsonTool")]
    public class ScriptObjectToJsonTool : ExecutableScriptBase
    {
        
        public List<ScriptableObject> targets;
        public AssetPath path;
        public string fileName;
        public override void Excute()
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(path.path, fileName)))
            {
                JsonTextWriter jtw = new JsonTextWriter(outputFile);
                jtw.Formatting = Formatting.Indented;
                jtw.WriteStartObject();
                jtw.WritePropertyName("Objects");
                jtw.WriteStartArray();
                foreach (var target in targets)
                {
                    ScriptObjectInfomation info = new ScriptObjectInfomation()
                    {
                        instanceId = target.GetInstanceID(),
                        name = target.name,
                        json = JsonUtility.ToJson(target, true)
                    };

                    jtw.WriteStartObject();
                    string s = JsonUtility.ToJson(target, true);
                    jtw.WritePropertyName("SOinstanceID");
                    jtw.WriteValue(info.instanceId);
                    jtw.WritePropertyName("name");
                    jtw.WriteValue(info.name);
                    jtw.WritePropertyName("json");
                    //应该使用WriteRawValue而不是WriteRaw，否则会在json中添加莫名其妙的null
                    //https://webcache.googleusercontent.com/search?q=cache:WC8EeqeFia4J:https://codecorner.galanter.net/2015/01/07/writeendobject-of-json-net-ouptuts-null-literal/+&cd=1&hl=zh-CN&ct=clnk&gl=us
                    //jtw.WriteRaw(info.json);
                    jtw.WriteRawValue(info.json);
                    jtw.WriteEndObject();
                }
                jtw.WriteEndArray();
                jtw.WriteEndObject();
            }

            AssetDatabase.Refresh();
        }
    }
}
