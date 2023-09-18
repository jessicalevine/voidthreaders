using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetLine : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform pointA;
    public Transform pointB;

    void Start()
    {
        pointA = transform.Find("Point A");
        pointB = transform.Find("Point B");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
