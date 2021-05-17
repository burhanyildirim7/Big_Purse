using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class CoinArtiBir : MonoBehaviour
{
    //[SerializeField] private GameObject _canvas;

    void Start()
    {
       // _canvas = GameObject.FindGameObjectWithTag("Canvas");
        StartCoroutine(ElmasMove());
    }

    
    void Update()
    {
       
    }

    IEnumerator ElmasMove()
    {
       // transform.SetParent(_canvas.transform, false);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);


    }
}
