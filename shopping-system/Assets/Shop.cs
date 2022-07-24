using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    [SerializeField]
    private TextMeshProUGUI notEnoughCoinsText;
    GameObject itemTemplate;
    GameObject g;
    private Button buyBtn;

    private void Start()
    {
        itemTemplate = shopScrollView.GetChild(0).gameObject;
        int lenght = ShopItemsList.Count;
        for (int i = 0; i < lenght; i++)
        {
            g = Instantiate(itemTemplate, shopScrollView);
            g.transform.GetChild(0).GetComponent<Image>().sprite = ShopItemsList[i].Image;
            g.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = ShopItemsList[i].Price.ToString();
            buyBtn = g.transform.GetChild(2).GetComponent<Button>();
            buyBtn.interactable = !ShopItemsList[i].IsPurchased;
            var i1 = i;
            buyBtn.onClick.AddListener(() => OnShıpItemBtnClicked(i1));

        }
        Destroy(itemTemplate);
    }

    public void OnShıpItemBtnClicked(int itemIndex)
    {
        if (Game.Instance.HasEnoughCoins(ShopItemsList[itemIndex].Price))
        {
            Game.Instance.UseCoins(ShopItemsList[itemIndex].Price);
            ShopItemsList[itemIndex].IsPurchased = true;
            shopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>().interactable = false;
            shopScrollView.GetChild(itemIndex).GetChild(2).GetChild(0).GetComponent<Text>().text = "Purchased";
        }
        else
        {
            //leantween eklenecek
            notEnoughCoinsText.gameObject.SetActive(true);
        }

    }
}

//uımanager ile bölüşecek
