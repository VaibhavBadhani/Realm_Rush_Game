using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//take enemy prefab and institate in every sec using coroutine
public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] [Range(0, 50)] int poolSize = 5;
    [SerializeField] [Range(0.1f, 30f)] float spawnTimer = 1f;
    
    GameObject[] pool;

    // Start is called before the first frame update 
    void Awake()
    {
        PopulatePool();
    }
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for(int i =0;i<pool.Length;i++)
        {
            pool[i]=Instantiate(enemyPrefab,transform);
            pool[i].SetActive(false);
        }
    }
     
            
     void EnableObjectInPool()
     {
        for(int i =0;i<pool.Length;i++)
        {
            if(pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
     }
     //coroutine
     IEnumerator SpawnEnemy()
     {
        //like update meth
        while(true)
        {
            // Instantiate(enemyPrefab,transform);//object pool se krunga ab
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
     }

  
}
