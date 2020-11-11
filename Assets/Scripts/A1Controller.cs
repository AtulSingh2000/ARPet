using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class A1Controller : MonoBehaviour
{

    private List<DetectedPlane> allPlanes;
  
    public GameObject Tile;
    public GameObject Pet;
  
    public Vector3 camPOS;

    public Camera FirstPersonCamera;
    public Text PlaneCount;
    private GameObject gameObject;
    public float targetY;



    private void Start()
    {
        allPlanes = new List<DetectedPlane>();
        camPOS = FirstPersonCamera.transform.position;
      
    }
    void Update()
    {
        if (Session.Status != SessionStatus.Tracking)
        {
            return;
        }
        Session.GetTrackables<DetectedPlane>(allPlanes, TrackableQueryFilter.All);
        PlaneCount.text = "Number of Planes:" + allPlanes.Count;



        Touch touch;
        if (Input.touchCount < 1 ||
                (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }

        if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        {
            return;
        }



        TrackableHit hit;
        TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon;
        if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit))
        {
            if ((hit.Trackable is DetectedPlane) &&
                Vector3.Dot(FirstPersonCamera.transform.position -
                hit.Pose.position, hit.Pose.rotation * Vector3.up) > 0)

           
          
            {
              if(gameObject == null){
                    gameObject = Instantiate(Tile,
                    hit.Pose.position, hit.Pose.rotation);

                    var gameObjectPet = Instantiate(Pet, hit.Pose.position + new Vector3(0f, 0f, -2f), hit.Pose.rotation);
                }
              else
                {
                    gameObject.transform.position = hit.Pose.position;
                }
               
            }

            targetY = hit.Pose.position.y;


        }
    }
 
}
