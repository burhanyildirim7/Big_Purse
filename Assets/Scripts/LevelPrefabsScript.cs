using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPrefabsScript : MonoBehaviour
{

    private int _levelNumarasi;
    private int _playerNumber;

    void Start()
    {
        _levelNumarasi = PlayerPrefs.GetInt("LevelNumarasi");
        _playerNumber = PlayerPrefs.GetInt("PlayerNumber");

        GameObject _cantalar;
        _cantalar = GameObject.Find("Cantalar" + (_levelNumarasi + 1));

        for (int a = 0; a < _cantalar.transform.childCount; a++)
        {
            Debug.Log("Forda canta acma oncesi");
            _cantalar.transform.GetChild(a).GetChild(_playerNumber + 1).gameObject.SetActive(true);
            Debug.Log("Forda canta acma sonrasi");
        }
    }

    
    void Update()
    {
        
    }
}
