using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipComponent : ShipComponent
{
    void Awake()
    {
        if (initialPlanet == null) {
            Debug.LogError("Set a start location for " + name);
        }

        ship = PlayerShip.Instantiate(initialPlanet, new List<CargoItem>()).Ship;
        //PlayerShip.Instance.Ship.cargo.Add(new CargoItem("Food", 3));
        //PlayerShip.Instance.Ship.cargo.Add(new CargoItem("Ammo", 1));

    }
}
