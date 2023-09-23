using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoShip : Ship {
    public List<CargoItem> cargo = new List<CargoItem>();

    public CargoShip(GameObject initialPlanet, List<CargoItem> initialCargo) : base(initialPlanet) {
        cargo.AddRange(initialCargo);
    }
}