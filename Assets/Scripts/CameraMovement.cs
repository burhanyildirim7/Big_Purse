using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    
    private GameObject Player;

   // [SerializeField] private GameObject _dusmanObject;



    Vector3 aradakiFark;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        aradakiFark = transform.position - Player.transform.position;

        
    }


    void Update()
    {
        /*
        if (AnimationControl._dusmaniFirlat == true)
        {
            transform.position = new Vector3(_dusmanObject.transform.position.x, _dusmanObject.transform.position.y + aradakiFark.y, _dusmanObject.transform.position.z + aradakiFark.z);
        }
       */

        if (AnimationControl._dusmaniFirlat == false)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(Player.transform.position.x, Player.transform.position.y + aradakiFark.y, Player.transform.position.z + aradakiFark.z), Time.deltaTime * 5f);
        }
        else
        {

        }
        

    }

    public void KameraPozisyonResetle()
    {
        transform.position = new Vector3(0, 8.5f, -8.5f);
        Player = GameObject.FindGameObjectWithTag("Player");
        //aradakiFark = transform.position - Player.transform.position;
    }
}
