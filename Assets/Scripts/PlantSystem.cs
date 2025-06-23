using UnityEngine;

public class PlantSystem : MonoBehaviour
{
    public GameObject[] plantPrefabs; // trebuie s? corespund? ordinii produselor (ex: porumb, grâu, etc.)
    public GameObject fieldParent; // obiectul care con?ine toate celulele din teren (tile-urile)

    public void Plant(int productId)
    {
        foreach (Transform cell in fieldParent.transform)
        {
            if (cell.childCount == 0) // dac? celula e liber?
            {
                Instantiate(plantPrefabs[productId], cell.position, Quaternion.identity, cell);
                Debug.Log("Plantat " + productId + " în celula: " + cell.name);
                return;
            }
        }

        Debug.Log("Nu exist? celule libere pentru plantat!");
    }
}
