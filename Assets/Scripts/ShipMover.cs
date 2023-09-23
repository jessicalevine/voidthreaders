using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMover : MonoBehaviour {

    [SerializeField] private GameObject initialPlanet;
    [SerializeField] private StarlaneMap starlaneMap;

    public float speed = 1.0f;

    public Ship ship;

    private float traversalStartTime;
    private Vector2 traversalStartpoint;
    private Vector2 traversalEndpoint;

    void Start() {
        if (initialPlanet == null) {
            Debug.Log("Set a start location for " + name);
        }

        ship = new Ship(initialPlanet);

        transform.position = ship.ActivePlanet.transform.position;

        List<Starlane> starlanes;
        if (starlaneMap.starlaneDictionary.TryGetValue(ship.ActivePlanet, out starlanes)) {
            if (starlanes.Count == 0)
                throw new System.InvalidOperationException("Starting planet has list but no starlanes");

            var dockLocation = starlanes[0].DockLocationIfMatchingPlanet(initialPlanet);
            if (dockLocation == null)
                throw new System.InvalidOperationException("Starlane does not contain planet through which starlane was found");

            transform.position = (Vector2) dockLocation;

        } else {
            throw new System.InvalidOperationException("Starting planet has no list of starlanes");
        }
    }

    void Update() {
        if (ship.IsDockedAtPlanet()) {
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
                ship.CompleteTraversal();
            }
        }
    }
    void TraverseToPlanet(GameObject targetPlanet) {
        Vector2? targetDockLocation = null;
        List<Starlane> starlanes;

        if (targetPlanet != starlaneMap.starlaneDictionary.TryGetValue(ship.ActivePlanet, out starlanes)) {
            Debug.Log("Dict includes " + ship.ActivePlanet.name);

            foreach (Starlane starlane in starlanes) {
                Debug.Log("Evaluating lane " + ship.ActivePlanet.name);

                targetDockLocation = starlane.DockLocationIfMatchingPlanet(targetPlanet);
                Debug.Log("Checking if starlane " + starlane.startPlanet + ", " + starlane.endPlanet + " has planet " + targetPlanet.name);

                if (targetDockLocation != null) {
                    Debug.Log("Has the dock " + targetPlanet.name);

                    Vector2 originDockLocation = (Vector2) starlane.DockLocationIfMatchingPlanet(ship.ActivePlanet);
                    transform.position = originDockLocation;

                    traversalStartTime = Time.time;
                    traversalStartpoint = transform.position;
                    traversalEndpoint = (Vector2) targetDockLocation;
                    ship.BeginTraversal(targetPlanet);

                    return;
                }
            }
        }

    }
}
