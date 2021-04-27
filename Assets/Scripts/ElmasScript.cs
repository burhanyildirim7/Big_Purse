using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElmasScript : MonoBehaviour
{

    GameObject _coinsController;
   
    void Start()
    {
        _coinsController = GameObject.FindGameObjectWithTag("CoinsController");
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _coinsController.GetComponent<CoinsController>().CoinToplama(1);
            Destroy(gameObject);
            
        }
    }
}
