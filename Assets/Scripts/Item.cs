using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    string tagName;

    private void Start()
    {
        tagName = gameObject.tag;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(GameManager.Instance.heartNum);
            GameManager.Instance.EatItem(tagName);
            Debug.Log(GameManager.Instance.heartNum);
            Destroy(gameObject);
        }
    }
}
