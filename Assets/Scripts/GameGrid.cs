using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    public int columnLength, rowLength;
    public float x_Space, z_Space;
    public GameObject grass;
    public GameObject[] currentGrid;

    public bool gotGrid;
    public GameObject hitted;
    public GameObject field;

    private RaycastHit _Hit;

    public bool creatingFields;

    public Texture2D basicCursor, fieldCursor;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;



    public GameObject goldSystem;
    public int fieldsPrice;


    // Se seteaz? cursorul implicit la pornirea jocului
    private void Awake()
    {
        Cursor.SetCursor(basicCursor, hotSpot, cursorMode);
    }

    void Start()
    {
        for (int i = 0; i < columnLength * rowLength; i++)
        {
            Instantiate(grass, new Vector3(x_Space + (x_Space * (i % columnLength)), 0, z_Space + (z_Space * (i / columnLength))), Quaternion.identity);
        }
    }

    void Update()
    {
        if (!gotGrid)
        {
            currentGrid = GameObject.FindGameObjectsWithTag("grid");
            gotGrid = true;
        }

        // Raycast sub mouse
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _Hit))
        {
            if (creatingFields && _Hit.transform.CompareTag("grid"))
            {
                // Cursor de plantare
                Cursor.SetCursor(fieldCursor, hotSpot, cursorMode);

                if (Input.GetMouseButtonDown(0))
                {
                    // Verific? dac? avem aur suficient
                    if (goldSystem.GetComponent<GoldSystem>().gold >= fieldsPrice)
                    {
                        hitted = _Hit.transform.gameObject;
                        Instantiate(field, hitted.transform.position, Quaternion.identity);
                        Destroy(hitted);

                        // Scade aurul
                        goldSystem.GetComponent<GoldSystem>().gold -= fieldsPrice;
                    }
                    else
                    {
                        Debug.Log("Nu ai suficient aur pentru a planta un câmp!");
                    }
                }
            }
            else
            {
                Cursor.SetCursor(basicCursor, hotSpot, cursorMode);
            }
        }
        else
        {
            Cursor.SetCursor(basicCursor, hotSpot, cursorMode);
        }
    }

    public void CreateFields()
    {
        creatingFields = true;
    }

    public void returnToNormality()
    {
        creatingFields = false;
        Cursor.SetCursor(basicCursor, hotSpot, cursorMode); // reset
    }

    public void HandleFieldClick(GameObject clickedField)
    {
        Debug.Log("Ai apasat pe field-ul de la pozitia: " + clickedField.transform.position);
    }
}
