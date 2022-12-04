using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ItemGenerator : EditorWindow
{
    // Item Data
    private new string title;
    private float _price;
    private Sprite _sprite;
    private ItemSO _data;
    private GUIStyle _styleButtons;
    private string _pathAndName = "Assets/Scripts/ItemData/New Item.asset";
    
    [MenuItem("Tools/Item Generator")]
    static void Init()
    {
        ItemGenerator window = (ItemGenerator)GetWindow(typeof(ItemGenerator));
        Texture2D iconTitle = EditorGUIUtility.Load("d_Prefab Icon") as Texture2D;
        GUIContent tittleContent = new GUIContent("Item Generator", iconTitle);
        window.titleContent = tittleContent;
        window.minSize = new Vector2(250, 350);
        window.Show();
    }

    private void OnGUI()
    {
        _styleButtons = new GUIStyle(GUI.skin.button)
            { alignment = TextAnchor.MiddleCenter, fontSize = 15, fixedHeight = 40 };
        
        GUILayout.Label("Data", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        title = EditorGUILayout.TextField("Title: ", title);
        EditorGUILayout.Space();
        GUILayout.Label("Price: ");
        _price = EditorGUILayout.Slider(_price, 0, 999);
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        _sprite = (Sprite)EditorGUILayout.ObjectField("Sprite", _sprite, typeof(Sprite), true);
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        DrawHorizontalLine();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Create", _styleButtons))
        {
            CreateItem();
            string itemPathAndName = AssetDatabase.GenerateUniqueAssetPath(_pathAndName);
            AssetDatabase.CreateAsset(_data,itemPathAndName);
            AssetDatabase.RenameAsset(itemPathAndName, title);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = _data;



        }
        if (GUILayout.Button("Clear", _styleButtons))
        {
            ClearItem();
        }
        EditorGUILayout.EndHorizontal();
    }

    private void DrawHorizontalLine()
    {
        Rect rect = EditorGUILayout.GetControlRect(false, 1);
        rect.height = 1;
        EditorGUI.DrawRect(rect,new Color(0.5f,0.5f,0.5f,1));
    }

    private void DrawSize()
    {
        EditorGUILayout.LabelField("X: " + base.position.width.ToString() );
        EditorGUILayout.LabelField("Y: " + base.position.height.ToString() );
    }

    private void CreateItem()
    {
        _data = CreateInstance<ItemSO>();
        _data.price = _price;
        _data.title = title;
        _data.sprite = _sprite;

    }

    private void ClearItem()
    {
        title = null;
        _price = 0;
        _sprite = null;
    }
}
