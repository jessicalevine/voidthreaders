using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMover : MonoBehaviour {

    [SerializeField] private GameObject initialPlanet;
    public GameObject activePlanet;
    public float speed = 1.0f;

    private float traversalStartTime;
    private Vector2 traversalStartpoint;
    private Vector2 traversalEndpoint;
    private bool traversalComplete = true;

    void Start() {
        if (initialPlanet == null) {
            Debug.Log("Set a start location for " + name);
        }

        activePlanet = initialPlanet;
        transform.position = activePlanet.transform.position;
    }

    void Update() {
        if (traversalComplete) {
            RaycastHit2D hit;
            if (Input.GetMouseButtonDown(0)) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                hit = Physics2D.GetRayIntersection(ray);
                if (hit) {
                    GameObject hitObj = hit.collider.gameObject;
                    Debug.Log("There is " + hitObj.name + " in front of the mouse!");

                    TraverseToPlanet(hitObj);
                }
                else {
                    Debug.Log("No hit");
                }

                // Debug.DrawRay(ray.origin, ray.direction * 10, Color.green, 10, false);
            }
        } else {
            float distCovered = (Time.time - traversalStartTime) * speed;
            float fractionOfJourney = distCovered / Vector2.Distance(traversalStartpoint, traversalEndpoint);

            transform.position = Vector3.Lerp(traversalStartpoint, traversalEndpoint, fractionOfJourney);

            if (fractionOfJourney >= 1) {
                traversalComplete = true;
            }
        }
    }
    void TraverseToPlanet(GameObject targetPlanet) {
        Vector2? targetDockLocation = null;
        List<Starlane> starlanes;

        if (GetComponent<StarlaneMap>().starlaneDictionary.TryGetValue(activePlanet, out starlanes)) {
            Debug.Log("Dict includes " + activePlanet.name);

            foreach (Starlane starlane in starlanes) {
                Debug.Log("Evaluating lane " + activePlanet.name);

                /*
                if (starlane.HasPlanet(activePlanet)) {
                    Debug.Log("Has the planet " + activePlanet.name);
                */

                    targetDockLocation = starlane.DockLocationIfMatchingPlanet(targetPlanet);
                    Debug.Log("Checking if starlane " + starlane.startPlanet + ", " + starlane.endPlanet + " has planet " + targetPlanet.name);

                    if (targetDockLocation != null) {
                        Debug.Log("Has the dock " + targetPlanet.name);

                        traversalStartTime = Time.time;
                        traversalStartpoint = transform.position;
                        traversalEndpoint = (Vector2) targetDockLocation;
                        traversalComplete = false;
                        activePlanet = targetPlanet;

                }
                // }
            }
        }

    }
}
