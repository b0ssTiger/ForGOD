using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public string sceneName;
    public GameObject _Player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            DontDestroyOnLoad(_Player); 
            SceneManager.LoadScene(sceneName);
            _Player.transform.position  =  new Vector3(0, 0, 0);
        }
    }
}
