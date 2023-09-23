using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoListGUI : MonoBehaviour
{
    public Texture2D cargoTexture;

    private const int windowHeight = 400;
    private const int windowWidth = 380;

    private const int areaX = 40;
    private const int areaY = 40;
    private const int areaW = windowWidth - areaX - 10;
    private const int areaH = windowHeight - areaY - 2;
    private const int cargoItemHeight = 35;
    private const int cargoItemPadding = 5;
    private const int cargoItemLabelBoxWidth = 250;

    Rect windowRect = new Rect(0, 0, windowHeight, windowWidth);
    Vector2 cargoListItemsScrollPos = Vector2.zero;

    List<string> cargoItems = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RenderCargoList() {
        // Cargo list items
        cargoListItemsScrollPos = GUILayout.BeginScrollView(cargoListItemsScrollPos);

        GUILayout.BeginVertical();
        int relativeY;
        for (int i = 0; i < cargoItems.Count; i++) {
            relativeY = i * (cargoItemHeight + cargoItemPadding);
            GUI.DrawTexture(new Rect(0, relativeY, cargoItemLabelBoxWidth, cargoItemHeight), cargoTexture, ScaleMode.StretchToFill);
            GUI.Label(new Rect(areaX, relativeY + 7, cargoItemLabelBoxWidth, cargoItemHeight), cargoItems[i]);
            if (PlayerShip.Instance.Ship.IsDockedAtPlanet())
                GUI.Button(new Rect(cargoItemLabelBoxWidth - 10, relativeY, 80, cargoItemHeight), "Drop");

            GUILayout.Space(relativeY);
        }

        GUILayout.EndVertical();
        GUILayout.EndScrollView();
    }
}
