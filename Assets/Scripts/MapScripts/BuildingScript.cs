using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingScript : MonoBehaviour
{
    [Header("Assign - Tilemaps")]
    public Camera cam;
    public GameObject player;
    public Tilemap dirtTilemap;
    public Tilemap woodTilemap;
    public Tilemap concreteTilemap;
    public Tilemap steelTilemap;

    [Header("Assign - Tiles")]
    public GameObject highlightedHammer;
    public GameObject highlightedDirt;
    public GameObject highlightedWood;
    public GameObject highlightedConcrete;
    public GameObject highlightedSteel;
    public Tile dirtTile;
    public Tile woodTile;
    public Tile concreteTile;
    public Tile steelTile;

    [Header("Variables - Don't Touch")]
    public bool isDestroying;
    public bool isSuitable = true; //change if range is used
    public bool isSelected;
    public Tile selectedTile;
    public Tilemap selectedTilemap;
    public GameObject selectedObject;
    public Vector2 mousePosition;
    public Vector2Int mouseTilePosition;
    public Vector2Int playerTilePosition;
    
    //methods for buttons
    public void ClickDirt()
    {
        selectedObject = Instantiate(highlightedDirt, cam.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        selectedTile = dirtTile;
        selectedTilemap = dirtTilemap;
        isSelected = true;
    }
    public void ClickWood()
    {
        selectedObject = Instantiate(highlightedWood, cam.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        selectedTile = woodTile;
        selectedTilemap = woodTilemap;
        isSelected = true;
    }
    public void ClickConcrete()
    {
        selectedObject = Instantiate(highlightedConcrete, cam.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        selectedTile = concreteTile;
        selectedTilemap = concreteTilemap;
        isSelected = true;
    }
    public void ClickSteel()
    {
        selectedObject = Instantiate(highlightedSteel, cam.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        selectedTile = steelTile;
        selectedTilemap = steelTilemap;
        isSelected = true;
    }
    //methods for buttons
    
    //destroy
    public void ClickDestroy()
    {
        selectedObject = Instantiate(highlightedHammer, cam.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        isDestroying = true;
    }
    //destroy
    
    private void Update()
    {
        //player tile position calculation
        if (player.transform.position.x > 0 && player.transform.position.y > 0)
        {
            playerTilePosition = new Vector2Int((int)player.transform.position.x, (int)player.transform.position.y);
        }
        else if (player.transform.position.x < 0 && player.transform.position.y > 0)
        {
            playerTilePosition = new Vector2Int((int)player.transform.position.x - 1, (int)player.transform.position.y);
        }
        else if (player.transform.position.x < 0 && player.transform.position.y < 0)
        {
            playerTilePosition = new Vector2Int((int)player.transform.position.x - 1, (int)player.transform.position.y - 1);
        }
        else if (player.transform.position.x > 0 && player.transform.position.y < 0)
        {
            playerTilePosition = new Vector2Int((int)player.transform.position.x, (int)player.transform.position.y - 1);
        }
        //player tile position calculation
        
        //mouse tile position calculation
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        if (mousePosition.x > 0 && mousePosition.y > 0)
        {
            mouseTilePosition = new Vector2Int((int)mousePosition.x, (int)mousePosition.y);
        }
        else if (mousePosition.x < 0 && mousePosition.y > 0)
        {
            mouseTilePosition = new Vector2Int((int)mousePosition.x - 1, (int)mousePosition.y);
        }
        else if (mousePosition.x < 0 && mousePosition.y < 0)
        {
            mouseTilePosition = new Vector2Int((int)mousePosition.x - 1, (int)mousePosition.y - 1);
        }
        else if (mousePosition.x > 0 && mousePosition.y < 0)
        {
            mouseTilePosition = new Vector2Int((int)mousePosition.x, (int)mousePosition.y - 1);
        }
        //mouse tile position calculation
        
        //player tile to mouse tile - distance calculation
        if (math.abs(playerTilePosition.x - mouseTilePosition.x) <= 4000f && math.abs(playerTilePosition.y - mouseTilePosition.y) <= 4000f)
        {
            isSuitable = true;
        }
        else
        {
            isSuitable = false;
        }
        //player tile to mouse tile - distance calculation

        //test
        // if (Input.GetKeyDown(KeyCode.O))
        // {
        //     ClickDirt();
        // }
        // if (Input.GetKeyDown(KeyCode.P))
        // {
        //     ClickDestroy();
        // }
        //test

        if (isSelected)
        {
            if (isSuitable)
            {
                selectedObject.transform.position = new Vector3(mouseTilePosition.x + 0.5f, mouseTilePosition.y + 0.5f);
            }

            else
            {
                //izdüşüm hesaplama
            }

            if (Input.GetMouseButtonDown(0))
            {
                var pos = selectedObject.transform.position;
                if (selectedTilemap.GetTile(new Vector3Int((int)(pos.x - 0.5f), (int)(pos.y - 0.5f))) == null)
                {
                    selectedTilemap.SetTile(new Vector3Int((int)(pos.x - 0.5f), (int)(pos.y - 0.5f)), selectedTile);
                }
            }
            
            else if (Input.GetMouseButtonDown(1))
            {
                Destroy(selectedObject);
                isSelected = false;
            }
        }
        
        /*else if (isDestroying && isSuitable)
        {
            selectedObject.transform.position = new Vector3(mouseTilePosition.x + 0.5f, mouseTilePosition.y + 0.5f);
            
            if (Input.GetMouseButtonDown(0))
            {
                dirtTilemap.SetTile(new Vector3Int((mouseTilePosition.x), (mouseTilePosition.y)), null);
                woodTilemap.SetTile(new Vector3Int((mouseTilePosition.x), (mouseTilePosition.y)), null);
                concreteTilemap.SetTile(new Vector3Int((mouseTilePosition.x), (mouseTilePosition.y)), null);
                steelTilemap.SetTile(new Vector3Int((mouseTilePosition.x), (mouseTilePosition.y)), null);
            }
            
            else if (Input.GetMouseButtonDown(1))
            {
                Destroy(selectedObject);
                isDestroying = false;
            }
        }*/
    }
}
