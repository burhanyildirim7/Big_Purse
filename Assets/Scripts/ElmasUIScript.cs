using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class ElmasUIScript : MonoBehaviour
{
    private GameObject _canvas;
    private GameObject _coinImage;
    void Start()
    {
        _canvas = GameObject.FindGameObjectWithTag("Canvas");
        _coinImage = GameObject.FindGameObjectWithTag("CoinImage");
        StartCoroutine(ElmasMove());
    }

    
    void Update()
    {
       
    }

    IEnumerator ElmasMove()
    {
        transform.SetParent(_canvas.transform, false);
        transform.DOMove(new Vector2(_coinImage.transform.position.x, _coinImage.transform.position.y), 1f);
       // transform.localPosition = Vector2.Lerp(transform.localPosition, _coinImage.transform.position, 1f);

        yield return new WaitForSeconds(1f);
        Destroy(gameObject);


    }
}
