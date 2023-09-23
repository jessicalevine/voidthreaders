using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoItem
{
    public string Name { get; set; }
    public int Quantity { get; set; }

    public CargoItem(string name, int quantity) {
        Name = name;
        Quantity = quantity;
    }
}
