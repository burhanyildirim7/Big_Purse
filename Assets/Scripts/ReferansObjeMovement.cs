using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferansObjeMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private GameObject _player;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController._oyunAktif == true && PlayerMovement._playerHareket == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
           // transform.position = new Vector3(0, _player.transform.position.y, _player.transform.position.z);

        }
       
    }
}
