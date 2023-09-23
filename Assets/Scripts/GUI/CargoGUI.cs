using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoGUI : MonoBehaviour
{
	public GUISkin guiSkin;
	public Texture2D cargoTexture;

	private const int windowHeight = 400;
	private const int windowWidth = 380;

	private const int areaX = 40;
	private const int areaY = 40;
	private const int areaW = windowWidth - areaX - 10;
	private const int areaH = windowHeight - areaY - 2;

	Rect windowRect = new Rect(0, 0, windowHeight, windowWidth);
	Vector2 cargoListItemsScrollPos = Vector2.zero;

	private CargoListGUI cargoListGUI;

	void Start() {
		cargoListGUI = new CargoListGUI(cargoTexture, windowWidth, windowHeight);

		windowRect.x = (Screen.width - windowRect.width) - 50;
		windowRect.y = 50;
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
		cargoListGUI.RenderCargoList();

		GUILayout.EndVertical();
		GUILayout.EndScrollView();
		GUILayout.EndArea();

		GUI.DragWindow(new Rect(0, 0, 10000, 10000));
	}
}
