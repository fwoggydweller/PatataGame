using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    #region
    Vector2 _direction;
    Rigidbody2D _rb;
    Vector3 _position;
    [SerializeField]
    private float speedValue = 10f;
    [SerializeField]
    CropsManager _cropsManager;
    #endregion

    #region
    public void SetAxis(Vector2 direction)
    {
        _direction = direction;
    }
    #endregion
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = _direction*speedValue;
    }

    public void SelectTile(Vector3 position)
    {
        Debug.Log(position);
        _cropsManager.Plow(position);
    }

    private void UseToolGrid()
    {
        
    }
}
