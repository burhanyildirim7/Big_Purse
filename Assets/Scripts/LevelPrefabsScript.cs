using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ElephantSDK;

public class LevelPrefabsScript : MonoBehaviour
{

    private int _playerNumber;
    [SerializeField] private GameObject _cantalar;
    [SerializeField] private GameObject _counterlar;
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private GameObject[] _enemyPrefabs;
    private GameObject _enemyObject;

    private int _levelNumber;

    void Start()
    {

        

        _playerNumber = PlayerPrefs.GetInt("PlayerNumber");
        _levelNumber = PlayerPrefs.GetInt("LevelNumarasi");

        Elephant.LevelStarted(_levelNumber + 1);
        // Debug.Log(_playerNumber);
        for (int a = 0; a < _cantalar.transform.childCount; a++)
        {
           // Debug.Log("Forda canta acma oncesi");
            _cantalar.transform.GetChild(a).GetChild(_playerNumber + 1).gameObject.SetActive(true);
           // Debug.Log("Forda canta acma sonrasi");
        }
        for (int a = 0; a < _counterlar.transform.childCount; a++)
        {
            // Debug.Log("Forda canta acma oncesi");
            _counterlar.transform.GetChild(a).GetChild(_playerNumber + 1).gameObject.SetActive(true);
            // Debug.Log("Forda canta acma sonrasi");
        }


        _enemyObject = GameObject.FindGameObjectWithTag("Enemy");
        Instantiate(_enemyPrefabs[_playerNumber], _spawnPoint.transform.position, _spawnPoint.transform.rotation);

        //AppMetrica.Instance.ReportEvent("level_start" + _levelNumber);
        //AppMetrica.Instance.SendEventsBuffer();
        //_enemyObject.transform.position = new Vector3(0, _spawnPoint.transform.position.y, _spawnPoint.transform.position.z);
    }

    

}
