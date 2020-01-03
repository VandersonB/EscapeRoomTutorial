using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;


[CustomEditor(typeof(DynamicObjects))]
public class DynamicObjectsEditor : Editor 
{
    override public void OnInspectorGUI()
    {
        var dynamicObject = target as DynamicObjects;

        dynamicObject.ChangedStateSprite = (GameObject)EditorGUILayout.ObjectField("ChangedState",
                dynamicObject.ChangedStateSprite, typeof(GameObject), true);

        dynamicObject.Property = (DynamicObjects.InteractionProperty)EditorGUILayout.EnumPopup("Property", dynamicObject.Property);

        if (dynamicObject.Property == DynamicObjects.InteractionProperty.access_interaction)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PrefixLabel("UnlockItem");
            dynamicObject.UnlockItem = EditorGUILayout.TextField(dynamicObject.UnlockItem);
            dynamicObject.AccessObject = (GameObject)EditorGUILayout.ObjectField("AccessObject",
                dynamicObject.AccessObject, typeof(GameObject), true);
            EditorGUI.indentLevel--;

        }
    }
}
