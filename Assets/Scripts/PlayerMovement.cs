using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using Sirenix.OdinInspector;

public class PlayerMovement : MonoBehaviour
{
    [Title("Player Hareket Script")]
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

    public static bool _oyunAktif;
    
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
        _oyunAktif = true;
    }

    void Update()
    {
        if (_oyunAktif == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 5f);

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

}