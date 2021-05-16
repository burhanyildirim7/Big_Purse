using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPrefabsScript : MonoBehaviour
{

    private int _playerNumber;
    [SerializeField] private GameObject _cantalar;
    [SerializeField] private GameObject _spawnPoint;
    private GameObject _enemyObject;

    void Start()
    {
        _playerNumber = PlayerPrefs.GetInt("PlayerNumber");
        Debug.Log(_playerNumber);
        for (int a = 0; a < _cantalar.transform.childCount; a++)
        {
            Debug.Log("Forda canta acma oncesi");
            _cantalar.transform.GetChild(a).GetChild(_playerNumber + 1).gameObject.SetActive(true);
            Debug.Log("Forda canta acma sonrasi");
        }

       
        _enemyObject = GameObject.FindGameObjectWithTag("Enemy");
        _enemyObject.transform.position = new Vector3(0, _spawnPoint.transform.position.y, _spawnPoint.transform.position.z);
    }

    
    void Update()
    {
        
    }
}
