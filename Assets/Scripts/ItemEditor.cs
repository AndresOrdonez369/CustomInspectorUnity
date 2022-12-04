using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[UnityEditor.CustomEditor(typeof(Item))]
public class ItemEditor : Editor
{
    private Item currentTarget;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        currentTarget = (Item)target;
        GUILayout.Space(10);
        if (IsTargetReady())
        {
            if (!EditorApplication.isPlaying)
                GUILayout.Box($"Data:{currentTarget.data.title} (${currentTarget.data.price})");
            EditorGUI.BeginDisabledGroup(EditorApplication.isPlaying);
            string buttonText = EditorApplication.isPlaying ? "Consume (Only in editor mode)" : "Consume";
       
            if (GUILayout.Button(buttonText, GUILayout.Height(30)))
            {
                currentTarget.Consume();
            }
           
        }
        else
        {
            EditorGUILayout.HelpBox($"Error: {GetErrorMessage()} ",MessageType.Error);
        }
        
    }

    private bool IsTargetReady()
    {
        return
            currentTarget.itemTextTitle &&
            currentTarget.itemTextPrice &&
            currentTarget.data &&
            currentTarget.itemImage;
    }

    private string GetErrorMessage()
    {
        if (!currentTarget.data) return "Data Empty";
        if (!currentTarget.itemImage) return "Image Empty";
        if (!currentTarget.itemTextTitle) return "Title Empty";
        if (!currentTarget.itemTextPrice) return "Price Empty";
        return "Unknown";
    }

}
