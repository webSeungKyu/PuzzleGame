using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public GameObject player;
    public Image viewChangeImage;
    public bool lookOnOff = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector3(0, 46, 0);
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }

    
    void Update()
    {
        if (lookOnOff)
        {
            transform.rotation = Quaternion.Euler(45, 0, 0);
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y +10, 0);
        }
    }

    public void ViewChange()
    {
        if(lookOnOff)
        {
            lookOnOff = false;
            transform.position = new Vector3(0, 46, 0);
            transform.rotation = Quaternion.Euler(90, 0, 0);
        }
        else
        {
            lookOnOff = true;
        }


    }

}
