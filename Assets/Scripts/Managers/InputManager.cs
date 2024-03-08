using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    #region
    private float _xAxis;
    private float _yAxis;
    [SerializeField]
    PlayerController _playerController;
    #endregion

    // Update is called once per frame
    void Update()
    {
        _xAxis = Input.GetAxis("Horizontal");
        _yAxis = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(_xAxis, _yAxis, 0);
        _playerController.SetAxis(direction);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _playerController.SelectTile(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}
