using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoShip : Ship {
    public CargoManifest cargo = new CargoManifest();

    public CargoShip(GameObject initialPlanet, CargoManifest initialCargo = null) : base(initialPlanet) {
        if (initialCargo != null)
            cargo = initialCargo;
    }
}