using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerShip {
    private static PlayerShip instance = null;
    public CargoShip Ship { get; set; }

    private PlayerShip(GameObject initialPlanet, List<CargoItem> initialCargo) {
        Ship = new CargoShip(initialPlanet, initialCargo);
    }

    public static PlayerShip Instance {
        get {
            if (instance == null) {
                throw new System.InvalidOperationException("Attempted to access PlayerShip Singleton without instantiating it first");
            }
            return instance;
        }
    }

    public static PlayerShip Instantiate(GameObject initialPlanet, List<CargoItem> initialCargo) {
        return instance = new PlayerShip(initialPlanet, initialCargo);
    }
}

