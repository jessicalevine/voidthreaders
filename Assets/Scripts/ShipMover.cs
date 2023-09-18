using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMover : MonoBehaviour {

    [SerializeField] private Transform startLoc;
    public Transform activeLoc;
    public float speed = 1.0f;
    public Transform tempTargetPlanetLineLoc;

    private Transform lastLoc;
    private float traversalStartTime;
    private float traversalLength;
    private bool traversalComplete = true;

    void Start() {
        if (startLoc == null) {
            Debug.Log("Set a start location for " + name);
        }

        activeLoc = startLoc;
        transform.position = activeLoc.position;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            TraverseToPlanet(tempTargetPlanetLineLoc);
        }

            if (!traversalComplete) {
            float distCovered = (Time.time - traversalStartTime) * speed;
            float fractionOfJourney = distCovered / traversalLength;

            transform.position = Vector3.Lerp(lastLoc.position, activeLoc.position, fractionOfJourney);

            if (fractionOfJourney >= 1) {
                traversalComplete = true;
            }
        }
    }
    void TraverseToPlanet(Transform planetLineLoc) {
        lastLoc = activeLoc;
        activeLoc = planetLineLoc;

        traversalStartTime = Time.time;
        traversalLength = Vector3.Distance(lastLoc.position, activeLoc.position);
        traversalComplete = false;
    }
}
