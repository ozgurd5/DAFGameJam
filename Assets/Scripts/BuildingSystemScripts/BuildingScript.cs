using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingScript : MonoBehaviour
{
    [Header("Assign")]
    public Camera cam;
    public Tilemap tilemap;
    public GameObject highlightedObject;
    public Tile highlightedTile;

    [Header("Variables - Don't Touch")]
    public Vector2 mousePosition;
    public Vector2Int tilePosition;
    public bool isSelected;
    public static GameObject[] selectedObject = new GameObject[1]; 
    
    public void Click()
    {
        selectedObject[0] = Instantiate(highlightedObject, cam.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        isSelected = true;
    }
    
    private void Update()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        if (mousePosition.x > 0 && mousePosition.y > 0)
        {
            tilePosition = new Vector2Int((int)mousePosition.x, (int)mousePosition.y);
        }
        else if (mousePosition.x < 0 && mousePosition.y > 0)
        {
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            selectedObject[0] = Instantiate(highlightedObject, cam.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
            isSelected = true;   
        }
        
        if (isSelected)
        {
            selectedObject[0].transform.position = new Vector3(tilePosition.x + 0.5f, tilePosition.y + 0.5f);

            if (Input.GetMouseButtonDown(0))
            {
                tilemap.SetTile(new Vector3Int(((int)mousePosition.x), ((int)mousePosition.y)), highlightedTile);
            }
            
            else if (Input.GetMouseButtonDown(1))
            {
                Destroy(selectedObject[0]);
                isSelected = false;
            }
        }
    }
}
