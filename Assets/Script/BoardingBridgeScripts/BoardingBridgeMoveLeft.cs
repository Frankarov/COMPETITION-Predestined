using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardingBridgeMoveLeft : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime*speed);
    }
}
