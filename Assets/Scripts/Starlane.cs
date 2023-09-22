using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starlane : MonoBehaviour {
    private const float width = 0.1f;
    private const int sortingOrder = 3;

    public GameObject startPlanet;
    public GameObject endPlanet;
    private LineRenderer lineRenderer;

    public static Vector2 TargetDockingPosition(Vector2 starlaneStart, Vector2 starlaneEnd) {
        Vector2 dockingVector = Vector2.Perpendicular(starlaneEnd - starlaneStart).normalized;

        // Ensure you are always at the perpendicular that faces towards the top of the screen
        if (dockingVector.y < 0) {
            dockingVector.y = -dockingVector.y;
            dockingVector.x = -dockingVector.x;
        }

        return starlaneStart + dockingVector * 0.6f;
    }

    public static Vector2 LanePos(GameObject startPlanet, GameObject endPlanet) {
        return Vector2.MoveTowards(
            startPlanet.transform.position,
            endPlanet.transform.position,
            startPlanet.GetComponent<SpriteRenderer>().bounds.size.x
        );
    }

    void Start() {
        Vector2 starlaneStart = LanePos(startPlanet, endPlanet);
        Vector2 starlaneEnd = LanePos(endPlanet, startPlanet);

        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, starlaneStart);
        lineRenderer.SetPosition(1, starlaneEnd);
        lineRenderer.sortingOrder = sortingOrder;

        Material material = new Material(Shader.Find("Sprites/Default"));
        Color starlaneColor = new Color(1f, 1f, 1f, 0.5f);
        material.SetColor("_Color", starlaneColor);
        lineRenderer.material = material;
    }

    public bool HasPlanet(GameObject planet) {
        return startPlanet == planet || endPlanet == planet;
    }

    public Vector2? DockLocationIfMatchingPlanet(GameObject planet) {
        if (startPlanet == planet) {
            return TargetDockingPosition(
                LanePos(startPlanet, endPlanet),
                LanePos(endPlanet, startPlanet)
            );
        }
        else if (endPlanet == planet) {
            return TargetDockingPosition(
                LanePos(endPlanet, startPlanet),
                LanePos(startPlanet, endPlanet)
            );
        }
        return null;
    }
}