using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarlaneMap : MonoBehaviour {
    public Dictionary<GameObject, List<Starlane>> starlaneDictionary;

    void Start() {
        starlaneDictionary = new Dictionary<GameObject, List<Starlane>>();

        for (int i = 0; i < this.gameObject.transform.childCount; i++) {
            Starlane starlane = this.gameObject.transform.GetChild(i).gameObject.GetComponent<Starlane>();
            if(starlane != null) {
                AddToLinks(starlane.startPlanet, starlane);
                AddToLinks(starlane.endPlanet, starlane);
            }
        }
    }

    private void AddToLinks(GameObject startPlanet, Starlane starlane) {
        List<Starlane> targets;

        if (!starlaneDictionary.TryGetValue(startPlanet, out targets)) {
            targets = new List<Starlane>();
        }

        targets.Add(starlane);

        starlaneDictionary[startPlanet] = targets;
    }
}