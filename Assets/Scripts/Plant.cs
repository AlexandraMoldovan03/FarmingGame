using UnityEngine;

public class Plant : MonoBehaviour
{
    public Sprite[] growthStages; // sprite-uri pentru fiecare stadiu (ex: s?mân??, puiet, adult)
    public float timeBetweenStages = 3f;

    private int currentStage = 0;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = growthStages[currentStage];
        InvokeRepeating(nameof(Grow), timeBetweenStages, timeBetweenStages);
    }

    void Grow()
    {
        if (currentStage < growthStages.Length - 1)
        {
            currentStage++;
            spriteRenderer.sprite = growthStages[currentStage];
        }
        else
        {
            CancelInvoke(nameof(Grow)); // Planta este complet crescut?
        }
    }

    private void OnMouseDown()
    {
        if (currentStage == growthStages.Length - 1)
        {
            Debug.Log("Planta a fost recoltat?!");
            Destroy(gameObject);
            // TODO: adaug? în inventar sau ofer? recompens?
        }
    }
}
