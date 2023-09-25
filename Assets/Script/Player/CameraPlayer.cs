using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraPlayer : MonoBehaviour
{

    //Numeric
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    public Transform target;
    public Transform targetPlayerSakit;
    private Vector3 desiredPosition;
    [SerializeField]
    private int loopIndex;



    //String
    [SerializeField]
    private string currentSceneName;

    

    private void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;

    }



    private void FixedUpdate()
    {


        loopIndex = PlayerPrefs.GetInt("Loop");

        if(currentSceneName == "Hospital")
        {
            if(loopIndex == 0)
            {
                desiredPosition = targetPlayerSakit.position + offset;
            }
            else if(loopIndex == 1)
            {
                desiredPosition = target.position + offset;
            }
        }else if(currentSceneName == "Main")
        {
            desiredPosition = target.position + offset;
        }



        
        if(desiredPosition.x <= -32.4)
        {
            //untuk kedua scene
            desiredPosition.x = -32.84f;
        }

        if(currentSceneName == "Main")
        {
            if(desiredPosition.x >= 28.3 && desiredPosition.x <= 45) //28.3
            {
                //Batas Kabin Kanan
                desiredPosition.x = 27.49f;
            }

            if(desiredPosition.x >= 50 && desiredPosition.x <= 90)
            {
                desiredPosition.x = 68.4f;
            }

        }


        if(currentSceneName == "Hospital")
        {
            if(desiredPosition.x >= 6.14 && desiredPosition.x <= 14.37)
            {
                desiredPosition.x = 6.14f;
            }

            if( desiredPosition.x <= 115.72f && desiredPosition.x > 100)
            {
                desiredPosition.x = 115.72f;
            }

            if(desiredPosition.x >= 180.65f)
            {
                desiredPosition.x = 180.65f;
            }

        }

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x,transform.position.y,transform.position.z);

    }


}
