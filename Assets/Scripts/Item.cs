using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public ItemSO data;
    [Space]
    public Image itemImage;
    public TextMeshProUGUI itemTextTitle;
    public TextMeshProUGUI itemTextPrice;

    // Update is called once per frame
    void Update()
    {
        Consume();
    }

    public void Consume()
    {
        itemImage.sprite = data.sprite;
        itemTextTitle.text = data.title;
        itemTextPrice.text = data.GetPrice();

    }
}
