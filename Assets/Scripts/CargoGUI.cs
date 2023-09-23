using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoGUI : MonoBehaviour
{
	public GUISkin guiSkin;
	public Texture2D cargoTexture;
	public GameObject playerShip;

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

	void Start() {
		windowRect.x = (Screen.width - windowRect.width) - 50;
		windowRect.y = 50;
		cargoItems.Add("Weapons");
		cargoItems.Add("Food");
		cargoItems.Add("Ammo");
	}

	void OnGUI() {
		GUI.skin = guiSkin;
		windowRect = GUI.Window(0, windowRect, RenderCargoWindow, "CARGO");
	}

	void RenderCargoWindow(int windowID) {
		// Cargo list
		GUILayout.BeginArea(new Rect(areaX, areaY, areaW, areaH));

		// Cargo list items
		cargoListItemsScrollPos = GUILayout.BeginScrollView(cargoListItemsScrollPos);

		GUILayout.BeginVertical();
		int relativeY;
		for(int i = 0; i < cargoItems.Count; i++) {
			relativeY = i * (cargoItemHeight + cargoItemPadding);
			GUI.DrawTexture(new Rect(0, relativeY, cargoItemLabelBoxWidth, cargoItemHeight), cargoTexture, ScaleMode.StretchToFill);
			GUI.Label(new Rect(areaX, relativeY + 7, cargoItemLabelBoxWidth, cargoItemHeight), cargoItems[i]);
			if(playerShip.GetComponent<ShipMover>().ship.IsDockedAtPlanet())
				GUI.Button(new Rect(cargoItemLabelBoxWidth - 10, relativeY, 80, cargoItemHeight), "Drop");

			GUILayout.Space(relativeY);
		}

		GUILayout.EndVertical();
		GUILayout.EndScrollView();
		GUILayout.EndArea();

		GUI.DragWindow(new Rect(0, 0, 10000, 10000));
	}
}
