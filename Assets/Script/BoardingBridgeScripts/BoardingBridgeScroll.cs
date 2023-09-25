using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardingBridgeScroll : MonoBehaviour
{

    Vector3 startPos;
    float repeatWidth;

    private void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider2D>().size.x/2;
    }

    private void Update()
    {
        if(transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }

}
