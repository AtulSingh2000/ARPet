using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PetFollow : MonoBehaviour
{
  
    private Vector3 camPos;
   // public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
       
        // camPos = cam.transform.position + new Vector3(0f, 0f, 2f);
        camPos = GetComponent<A1Controller>().camPOS;
      
        
    }
    
    // Update is called once per frame
    void Update()
    {
       //transform.position = Vector3.MoveTowards(transform.position, camPos, 5f * Time.deltaTime);
       //  transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, 5f * Time.deltaTime);
       //camPos = cam.transform.position;
       // gameObject.transform.LookAt(camPos);
       // camPos = new Vector3(cam.transform.position.x, gameObject.GetComponent<A1Controller>().targetY, cam.transform.position.z) + new Vector3(2f, 0f, 2f);


    }

    public void Follow()
    {
       
        StartCoroutine(FollowTime());

    }
    public void Unfollow()
    {
        StopCoroutine(FollowTime());
    }

    IEnumerator FollowTime()
    {
        while(true)
        {
            transform.position = Vector3.MoveTowards(transform.position, camPos, 5f * Time.deltaTime);
            yield return null;
        }
        
        

    }
}
