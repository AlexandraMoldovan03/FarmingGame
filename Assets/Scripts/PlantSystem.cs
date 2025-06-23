using UnityEngine;

public class PlantSystem : MonoBehaviour
{
    public GameObject[] plantPrefabs;        
    public Transform fieldParent;            
    private int selectedPlantId = -1;        

    public LayerMask fieldLayer;             

    public void SelectPlantForPlanting(int id)
    {
        selectedPlantId = id;
        Debug.Log("Planta selectat? pentru plantare: " + id);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && selectedPlantId != -1)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, fieldLayer))
            {
                
                Vector3 position = hit.transform.position;

                
                if (hit.transform.childCount == 0)
                {
                    PlantAt(position, hit.transform);
                }
                else
                {
                    Debug.Log("Acest câmp este deja ocupat!");
                }
            }
        }
    }

    void PlantAt(Vector3 position, Transform parent)
    {
        GameObject plant = Instantiate(plantPrefabs[selectedPlantId], position + new Vector3(0, 0.1f, 0), Quaternion.identity, parent);
        plant.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); 
    }
}
