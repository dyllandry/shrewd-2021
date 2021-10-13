using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemIndex))]
public class ItemIndexEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        ItemIndex itemIndex = (ItemIndex) target;

        if (GUILayout.Button("Create Item"))
        {
            Item item = ScriptableObject.CreateInstance<Item>();

            itemIndex.items.Add(item);
            itemIndex.Reindex();

            AssetDatabase.CreateAsset(item, "Assets/ScriptableObjects/Item/NewItem.asset");
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();
            Selection.activeObject = item;
        }

        if (GUILayout.Button("Reindex"))
        {
            itemIndex.Reindex();
        }
    }
}
