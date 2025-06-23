using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Product : MonoBehaviour
{
    public int id;
    public string productName;
    public int price;
    public Sprite imageSprite;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI priceText;
    public Image productImage;
    public Button buyButton;

    private GoldSystem goldSystem;

    public void Setup(int _id, string _name, int _price, Sprite _sprite, GoldSystem _goldSystem)
    {
        id = _id;
        productName = _name;
        price = _price;
        imageSprite = _sprite;
        goldSystem = _goldSystem;

        nameText.text = productName;
        priceText.text = price + " $";
        productImage.sprite = imageSprite;

        buyButton.interactable = goldSystem.gold >= price;
        buyButton.onClick.RemoveAllListeners();
        buyButton.onClick.AddListener(BuyProduct);
    }

    void BuyProduct()
    {
        if (goldSystem.gold >= price)
        {
            goldSystem.gold -= price;
            Debug.Log("Ai cump?rat: " + productName);
            buyButton.interactable = false;

            // Plantare la o pozi?ie fix? de test
            Vector3 plantPosition = new Vector3(Random.Range(-5f, 5f), 0, 0); // sau pozi?ia mouse-ului
            FindObjectOfType<PlantManager>().Plant(id, plantPosition);
        }
        else
        {
            Debug.Log("Nu ai suficient aur pentru " + productName);
        }
    }


}
