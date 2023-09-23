using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CargoListGUI
{
    public Texture2D CargoTexture { get; set; }

    private const int cargoItemHeight = 35;
    private const int cargoItemPadding = 5;
    private const int cargoItemLabelBoxWidth = 250;

    Rect windowRect;
    Vector2 cargoListItemsScrollPos = Vector2.zero;
    public CargoListGUI(Texture2D cargoTexture, int windowWidth, int windowHeight) {
        CargoTexture = cargoTexture;
        windowRect = new Rect(0, 0, windowWidth, windowHeight);
    }

    public void RenderCargoList() {
        // Cargo list items
        cargoListItemsScrollPos = GUILayout.BeginScrollView(cargoListItemsScrollPos);

        GUILayout.BeginVertical();
        int relativeY;
        CargoManifest cargo = PlayerShip.Instance.Ship.cargo;
  
        for (int i = 0; i < cargo.Count(); i++) {
            var element = cargo.cargoDict.ElementAt(i);
            relativeY = i * (cargoItemHeight + cargoItemPadding);
            GUI.DrawTexture(new Rect(0, relativeY, cargoItemLabelBoxWidth, cargoItemHeight), CargoTexture, ScaleMode.StretchToFill);
            GUI.Label(new Rect(40, relativeY + 7, cargoItemLabelBoxWidth, cargoItemHeight), element.Value + "x " + element.Key);
            if (PlayerShip.Instance.Ship.IsDockedAtPlanet())
                GUI.Button(new Rect(cargoItemLabelBoxWidth - 10, relativeY, 80, cargoItemHeight), "Drop");

            GUILayout.Space(relativeY);
        }

        GUILayout.EndVertical();
        GUILayout.EndScrollView();
    }
}
