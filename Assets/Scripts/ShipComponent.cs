using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipComponent : MonoBehaviour
{
    public GameObject initialPlanet;
    public Ship ship;

    void Awake()
    {
        if (initialPlanet == null) {
            Debug.LogError("Set a start location for " + name);
        }

        ship = new Ship(initialPlanet);
    }
}
