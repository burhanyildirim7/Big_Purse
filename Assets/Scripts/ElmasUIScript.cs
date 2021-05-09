using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class ElmasUIScript : MonoBehaviour
{
    private GameObject _canvas;
    void Start()
    {
        _canvas = GameObject.FindGameObjectWithTag("Canvas");
        StartCoroutine(ElmasMove());
    }

    
    void Update()
    {
       
    }

    IEnumerator ElmasMove()
    {
        transform.SetParent(_canvas.transform, false);
        transform.DOMove(new Vector2(892, 1825), 1f);

        yield return new WaitForSeconds(1f);
        Destroy(gameObject);


    }
}
