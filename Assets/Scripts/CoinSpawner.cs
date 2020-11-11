using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
   

    public GameObject CentrePos;
    public GameObject Portal;
    public GameObject Coin;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCoins", 2f, 1f);

    }

    // Update is called once per frame
    void Update()
    {
       // StartCoroutine(Spawner());
      
    }
    public void SpawnCoins()
    {
        Vector3 pos = CentrePos.transform.position + new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-2f, 2f));
        GameObject temp = Instantiate(Coin, pos, Quaternion.identity);
        //  temp.transform.position = pos;

      //  temp = 
       
        temp.transform.parent = Portal.transform;
        

       
       

    }

   /* IEnumerator Spawner()
    {
        yield return new WaitForSeconds(2);
        SpawnCoins();
        yield return new WaitForSeconds(2);
    }*/
}
