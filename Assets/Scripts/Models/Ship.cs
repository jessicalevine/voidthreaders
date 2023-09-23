using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship
{
    public GameObject ActivePlanet { get; set; }
    public GameObject TraversalDestinationPlanet { get; set; }

    public Ship(GameObject initialPlanet) {
        ActivePlanet = initialPlanet;
    }

    public void BeginTraversal(GameObject destinationPlanet) {
        ActivePlanet = null;
        TraversalDestinationPlanet = destinationPlanet;
    }

    public void CompleteTraversal() {
        ActivePlanet = TraversalDestinationPlanet;
        TraversalDestinationPlanet = null;
    }

    public bool IsDockedAtPlanet() {
        return ActivePlanet == true;
    }
}