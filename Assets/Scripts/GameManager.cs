using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int heartNum = 0;
    public int spadeNum = 0;
    public int cloverNum = 0;
    public int diamondNum = 0;



    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }

    }
    void Start()
    {
        
    }

    

    void Update()
    {
        
    }

    /// <summary>
    /// 아이템 +1 / 사용 시 string으로 heart, spade, clover, diamond
    /// </summary>
    /// <param name="cardName"></param>
    public void EatItem(string cardName)
    {
        switch(cardName)
        {
            case "heart":
                heartNum++; break;
            case "spade":
                heartNum++; break;
            case "clover":
                heartNum++; break;
            case "diamond":
                heartNum++; break;
                default:break;
        }
    }
}
