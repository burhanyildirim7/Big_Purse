using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArtiBirOlusturma : MonoBehaviour
{
    [SerializeField]private GameObject PlayerCanvas;
    [SerializeField] private GameObject ArtiBirobject;
    [SerializeField] private TextMeshProUGUI ArtiBirobjectText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController._artiBirAktif)
        {
            GameObject GeciciTextObject;
            GeciciTextObject=Instantiate(ArtiBirobject,new Vector3(0,4f,0),Quaternion.identity);
            ArtiBirobjectText.text = "+1";
            GeciciTextObject.transform.parent = PlayerCanvas.transform;
            GeciciTextObject.transform.localPosition = new Vector3(0, 4f, 0);
            PlayerController._artiBirAktif = false;
        }
        else if(PlayerController._eksiBirAktif)
        {
            GameObject GeciciTextObject;
            GeciciTextObject = Instantiate(ArtiBirobject, new Vector3(0, 4f, 0), Quaternion.identity);
            ArtiBirobjectText.text = "-1";
            GeciciTextObject.transform.parent = PlayerCanvas.transform;
            GeciciTextObject.transform.localPosition = new Vector3(0, 4f, 0);
            PlayerController._eksiBirAktif = false;
        }
        else
        {

        }
    }

    


}
