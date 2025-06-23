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

            // Notific? PlantSystem c? am cump?rat planta
            PlantSystem plantSystem = GameObject.Find("PlantSystem").GetComponent<PlantSystem>();
            plantSystem.SelectPlantForPlanting(id); // id = indexul plantei cump?rate
        }
    }


}
