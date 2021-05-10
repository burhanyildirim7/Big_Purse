using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ElmasScript : MonoBehaviour
{

    private CoinsController _coinsController;

    private GameObject _player;
    [SerializeField] private GameObject _elmasObject;
    private GameObject _canvas;
    private Vector2 _playerPosition;

    void Start()
    {
        _coinsController = GameObject.FindGameObjectWithTag("CoinsController").GetComponent<CoinsController>(); 
        _player = GameObject.FindGameObjectWithTag("Player");
       // _elmasObject = GameObject.FindGameObjectWithTag("ElmasUI");
        _canvas = GameObject.FindGameObjectWithTag("Canvas");

    }

    
    void Update()
    {
        _playerPosition = _player.transform.position;
       // _playerPosition = Camera.main.ScreenToViewportPoint(_playerPosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //  _coinsController.GetComponent<CoinsController>().CoinToplama(1);
            Destroy(gameObject);
            Instantiate(_elmasObject, new Vector2(_playerPosition.x, _playerPosition.y + 100f), Quaternion.identity);
            _coinsController.CoinToplama(1);
          //  StartCoroutine(ElmasDestroy());



        }
    }

    /*
    IEnumerator ElmasDestroy()
    {
        
        
        yield return new WaitForSeconds(1f);
        
        

    }
    */
}
