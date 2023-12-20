using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] GameObject _player = null;
    [SerializeField] Vector3 _delta = new Vector3(0.0f, -5.0f,0.0f);
    
    // Update is called once per frame
    void Update()
    {
        transform.position = _player.transform.position + _delta;
        transform.LookAt(_player.transform);
    }
}
