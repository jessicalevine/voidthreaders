using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipComponent : MonoBehaviour
{
    [SerializeField] private GameObject initialPlanet;

    // Start is called before the first frame update
    void Start()
    {
        PlayerShip.Instantiate(initialPlanet, new List<CargoItem>());
    }
}
