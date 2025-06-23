using UnityEngine;
using TMPro;

public class GoldSystem : MonoBehaviour
{
    public int gold = 1000;
    public TextMeshProUGUI goldText;

    void Start()
    {
        UpdateGoldUI();
    }

    void Update()
    {
        goldText.text = $"{gold} $";
    }

    public void AddGold(int amount)
    {
        gold += amount;
        UpdateGoldUI();
    }

    public void SpendGold(int amount)
    {
        gold -= amount;
        UpdateGoldUI();
    }

    public bool HasEnoughGold(int cost)
    {
        return gold >= cost;
    }

    private void UpdateGoldUI()
    {
        goldText.text = $"{gold} $";
    }
}
