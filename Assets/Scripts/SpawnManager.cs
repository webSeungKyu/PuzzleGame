using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject monster;
    Vector3 spawnPosition;
    void Start()
    {
        spawnPosition = new Vector3(-9f, 0.5f, -9f);
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        //빨간색 경고
        yield return new WaitForSeconds(3f);
        //몬스터 생성
        for(int i = 0; i < 10; i++)
        {
            Instantiate(monster, spawnPosition, Quaternion.identity);
            spawnPosition = new Vector3(spawnPosition.x +2, spawnPosition.y, spawnPosition.z);
        }

    }

    void Update()
    {
        
    }
}
