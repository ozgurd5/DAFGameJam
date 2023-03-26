using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class DisasterController : MonoBehaviour
{
    [Header("Assign - Tilemaps")]
    public Tilemap dirtTilemap;
    public Tilemap woodTilemap;
    public Tilemap concreteTilemap;
    public Tilemap steelTilemap;

    [Header("Assign")]
    public float timerDefault = 100f;
    public float timerDecrease = 5f;
    public int timerDecreaseRate = 101; // 101 = %1 // 51 = %2 // 11 = %10 // etc.

    [Header("Don't Touch - Variables")]
    public float timer;
    public int dirtHealth = 100;
    public int woodHealth = 100;
    public int concreteHealth = 100;
    public int steelHealth = 100;
    public int disasterCode; //0 flood - 1 fire - 2 earthquake

    private void Update()
    {
        Random.InitState(System.DateTime.Now.Millisecond);

        if (Random.Range(0,timerDecreaseRate) == 1)
        {
            timer -= timerDecrease;
        }
        
        if (timer == 0)
        {
            disasterCode = Random.Range(0, 4);
            if (disasterCode == 0)
            {
                dirtHealth -= Random.Range(30, 46);
            }
            else if (disasterCode == 1)
            {
                dirtHealth -= Random.Range(30, 46);
                woodHealth -= Random.Range(30, 46);
                concreteHealth -= Random.Range(10, 26);
            }
            else if (disasterCode == 2)
            {
                dirtHealth -= Random.Range(30, 46);
                woodHealth -= Random.Range(30, 46);
                concreteHealth -= Random.Range(25, 36);
                steelHealth -= Random.Range(10, 26);
            }
            timer = timerDefault;
        }

        if (dirtHealth == 0)
        {
            dirtTilemap.ClearAllTiles();
        }
        if (woodHealth == 0)
        {
            woodTilemap.ClearAllTiles();
        }
        if (concreteHealth == 0)
        {
            concreteTilemap.ClearAllTiles();
        }
        if (steelHealth == 0)
        {
            steelTilemap.ClearAllTiles();
        }
    }
}
