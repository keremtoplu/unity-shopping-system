using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [System.Serializable]
    class ShopItem
    {
        public Sprite Image;
        public int Price;
        public bool IsPurchased = false;
    }
    [SerializeField]
    List<ShopItem> ShopItemsList;

    [SerializeField]
    Transform shopScrollView;

    GameObject itemTemplate;

    private void Start()
    {
        itemTemplate = shopScrollView.GetChild(0).gameObject;
        int lenght = ShopItemsList.Count;
        for (int i = 0; i < lenght; i++)
        {
            var g = Instantiate(itemTemplate, shopScrollView);
            g.transform.GetChild(0).GetComponent<Image>().sprite = ShopItemsList[i].Image;
            g.transform.GetChild(1).GetComponent<Text>().text = ShopItemsList[i].Price.ToString();
            g.transform.GetChild(2).GetComponent<Button>().interactable = !ShopItemsList[i].IsPurchased;

        }
        Destroy(itemTemplate);
    }

    public void OnShıpItemBtnClicked(int itemIndex)
    {
        ShopItemsList[itemIndex].IsPurchased = true;

        shopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>().interactable = false;
    }
}
