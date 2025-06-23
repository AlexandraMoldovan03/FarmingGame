using UnityEngine;

public class Shop : MonoBehaviour
{
    public string[] productName;
    public int[] price;
    public Sprite[] productImages;

    public int numberOfProducts;
    public GameObject shopWindow;
    public GameObject[] products;

    public void OpenShop()
    {
        shopWindow.SetActive(true);
        Refresh();
    }

    public void CloseShop()
    {
        shopWindow.SetActive(false);
    }

    public void Refresh()
    {
        for (int i = 0; i < numberOfProducts; i++)
        {
            products[i].SetActive(true);
            Product p = products[i].GetComponent<Product>();
            p.Setup(i, productName[i], price[i], productImages[i], GameObject.Find("Gold System").GetComponent<GoldSystem>());
        }
    }
}
