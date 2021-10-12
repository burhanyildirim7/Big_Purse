using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField]
    GameObject gObj;
    [SerializeField]
    GameObject gObj2;
    [SerializeField]
    GameObject barierSol;
    [SerializeField]
    GameObject barierSag;
    Plane objPlane;
    Vector3 m0;
    [SerializeField] private float _playerSpeed;

    public static bool _playerHareket;

    private float _speed;

    
    
    Ray GenerateMouseRay()
    {

        Vector3 mousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane
            );

        Vector3 mousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane
            );
        Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
        Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);

        Ray mr = new Ray(mousePosN, mousePosF - mousePosN);
        return mr;
    }

    private void Start()
    {
        _speed = _playerSpeed;
    }

    void Update()
    {
        if (GameController._oyunAktif == true && _playerHareket == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);

            if (Input.GetMouseButtonDown(0))
            {
                Ray mouseRay = GenerateMouseRay();
                RaycastHit hit;



                if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit))
                {


                    objPlane = new Plane(Vector3.up, gObj2.transform.position);

                    Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                    float rayDistance;
                    objPlane.Raycast(mRay, out rayDistance);

                    m0 = gObj2.transform.position - mRay.GetPoint(rayDistance);
                }
            }

            else if (Input.GetMouseButton(0))
            {


                Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                float rayDistance;
                if (objPlane.Raycast(mRay, out rayDistance))
                {
                    gObj2.transform.position = mRay.GetPoint(rayDistance) + m0;

                    if (gObj2.transform.position.x <= barierSol.transform.position.x)
                    {

                        gObj.transform.position = new Vector3(barierSol.transform.position.x + 0.1f, gObj.transform.position.y, gObj.transform.position.z);
                    }
                    else if (gObj2.transform.position.x >= barierSag.transform.position.x)
                    {

                        gObj.transform.position = new Vector3(barierSag.transform.position.x - 0.1f, gObj.transform.position.y, gObj.transform.position.z);
                    }
                    else
                    {
                        gObj.transform.position = new Vector3(gObj2.transform.position.x, gObj.transform.position.y, gObj.transform.position.z);
                    }

                }
            }
        }
        
     
    }

    public void PlayerHiziniDusur()
    {
        _speed = _playerSpeed / 2;
    }

    public void PlayerHiziniArtir()
    {
       _speed = _playerSpeed;
    }

}