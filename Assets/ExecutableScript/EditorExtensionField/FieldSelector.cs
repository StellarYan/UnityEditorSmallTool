using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace ExecutableScript
{
    [System.Serializable]
    public struct FieldSingleSelector
    {
        public UnityEngine.Object obj;
        public string selectingFieldName;
    }

    [CustomPropertyDrawer(typeof(FieldSingleSelector))]
    class FieldSingleSelectorDrawer : PropertyDrawer
    {
        int selectingIndex;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            property.Next(true);
            property.objectReferenceValue = EditorGUILayout.ObjectField(property.objectReferenceValue, typeof(Object), true);
            if (property.objectReferenceValue == null) return;
            System.Type type = property.objectReferenceValue.GetType();
            var selectingStyle = new GUIStyle(EditorStyles.radioButton);
            selectingStyle.normal = EditorStyles.radioButton.active;
            for (int i = 0; i < type.GetFields().Length; i++)
            {
                var field = type.GetFields()[i];
                GUIStyle style = selectingIndex == i ? selectingStyle : EditorStyles.radioButton;
                if (GUILayout.Button(field.Name, style)) selectingIndex = i;
            }
            type.GetProperties();
            Debug.Log(type.GetFields().Length);
            property.Next(true);
            property.Next(true);
            property.Next(true);
            if (selectingIndex > -1 && selectingIndex < type.GetFields().Length)
            {
                property.stringValue = type.GetFields()[selectingIndex].Name;
            }
            else property.stringValue = null;
            EditorGUILayout.LabelField(property.stringValue);
        }
    }
}