using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEditor.PlayerSettings;

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
    [SerializeField] Transform targetTransform;

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
        SacarDirección(out Vector3Int dir, posCrop);
        Vector3Int finalPos = new Vector3Int((int)Mathf.Round(targetTransform.position.x) + dir.x, (int)Mathf.Round(targetTransform.position.y) + dir.y, 0);
        Debug.Log("Dirección: " + dir + "  , Posición seleccionada: " + posCrop);
        targetTilemap.SetTile(finalPos, plowed);
    }

    private void SacarDirección(out Vector3Int dir, Vector3Int pos)
    {
        Vector3Int aux = new Vector3Int(pos.x, pos.y, pos.z);
        dir = Vector3Int.zero;
        dir.x = pos.x - (int)Mathf.Round(targetTransform.position.x);
        dir.y = pos.y - (int)Mathf.Round(targetTransform.position.y);
        if(dir.x < 0)
        {
            dir.x = -1;
        }
        else if(dir.x > 0)
        {
            dir.x = 1;
        }
        if (dir.y < 0)
        {
            dir.y = -1;
        }
        else if(dir.y > 0)
        {
            dir.y = 1;
        }

    }
}
