using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObjects/Item", order = 0)]
public class ItemSO : ScriptableObject
{
    public Sprite sprite;
    public string title;
    public float price;

    public string GetPrice()
    {
        return string.Format("Price: {0}", price);
            
    }
}
