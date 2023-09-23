using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoManifest
{
    public SortedDictionary<string, int> cargoDict;

    public CargoManifest() {
        cargoDict = new SortedDictionary<string, int>();
    }

    public void AddCargo(string cargoItem, int quantityToAdd = 1) {
        int quantity;
        if (!cargoDict.TryGetValue(cargoItem, out quantity)) {
            cargoDict[cargoItem] = quantityToAdd;
        } else {
            cargoDict[cargoItem] = quantity + quantityToAdd;
        }
    }


    public void RemoveCargo(string cargoItem, int quantityToRemove = 1) {
        if (!cargoDict.TryGetValue(cargoItem, out int quantity)) {
            Debug.LogWarning("Tried to remove cargo [" + cargoItem + "] when no such cargo was present");
        }

        int newQuantity = quantity - quantityToRemove;
        if (newQuantity < 1) {
            cargoDict.Remove(cargoItem);
        }
        else {
            cargoDict[cargoItem] = newQuantity;
        }
    }

    public int QuantityOf(string cargoItem) {
        if (!cargoDict.TryGetValue(cargoItem, out int quantity)) {
            return 0;
        }
        else {
            return quantity;
        }
    }


    public int Count() {
        return cargoDict.Count;
    }
}
