using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CropTypes
{
    public int growTimer;
    public Crops crop;
}
public class CropsManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TileBase plowed;
    [SerializeField] TileBase seeded;
    [SerializeField] Tilemap targetTilemap;

    Dictionary<Vector2, CropTypes> crops;
    void Start()
    {
        crops = new Dictionary<Vector2, CropTypes>(); //diccionario con todos los crops y con su info
    }

    public void Check(Vector3 position)
    {

    }
    public void Plow(Vector3 position)
    {
        CreatePlowedTile(position);
    }
    private void CreatePlowedTile(Vector3 position)
    {
        CropTypes crop = new CropTypes();
        crops.Add((Vector2)position, crop);
        Vector3Int posCrop = new Vector3Int(Mathf.FloorToInt(position.x), Mathf.FloorToInt(position.y), Mathf.FloorToInt(position.z));
        targetTilemap.SetTile(posCrop, plowed);
    }
}
