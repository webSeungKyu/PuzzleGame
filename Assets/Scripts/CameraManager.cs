using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public GameObject player;
    public bool lookOnOff = false;
    public Image viewImage;
    public Sprite[] viewChangeImage = new Sprite[] { };
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector3(0, 46, 0);
        transform.rotation = Quaternion.Euler(90, 0, 0);
        viewImage.sprite = viewChangeImage[0];
    }

    
    void Update()
    {
        if (lookOnOff)
        {
            transform.LookAt(player.transform.position);
            transform.rotation = Quaternion.Euler(45, 0, 0);
            transform.position = player.transform.position + new Vector3(0, 2f, -3f);
        }
        

    }

    /// <summary>
    /// 시점 변경 : 플레이어 시점과 위에서 보는 시점
    /// </summary>
    public void ViewChange()
    {
        if(lookOnOff)
        {
            lookOnOff = false;
            transform.position = new Vector3(0, 46, 0);
            transform.rotation = Quaternion.Euler(90, 0, 0);
            viewImage.sprite = viewChangeImage[0];
        }
        else
        {
            lookOnOff = true;
            viewImage.sprite = viewChangeImage[1];
        }


    }

}
