using UnityEngine;

public class PlantManager : MonoBehaviour
{
    public GameObject[] plantPrefabs; // prefabs pentru fiecare plant? (ex: ro?ii, grâu etc.)

    public void Plant(int productId, Vector3 position)
    {
        Instantiate(plantPrefabs[productId], position, Quaternion.identity);
    }
}
