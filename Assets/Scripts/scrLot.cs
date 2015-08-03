using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class scrLot : MonoBehaviour {

	GameObject manager;
	public SpriteRenderer spr;

	public string type;
	public string state;
	public Sprite face;

	Dictionary<string, int> flags = new Dictionary<string, int>();

	void Start () {
		manager = GameObject.Find ("Manager");

		ShowFace ();
	}

	void ShowFace() {
		spr.sprite = face;
	}

	void SetType(string t) {
		type = t;
	}

	void SetState(string s) {
		state = s;
	}

	void SetFace(Sprite s) {
		face = s;
	}

	void OnMouseDown () {
		if (!EventSystem.current.IsPointerOverGameObject ()) {
			switch (type) {
			case "empty":
				switch (state) {
				case "empty":
					Debug.Log ("This lot is empty");
					break;
				case "trash":
					manager.SendMessage ("SetAction", "clear");
					Debug.Log ("This lot is full of trash");
					break;
				}
				break;
			case "housing":
				Debug.Log ("Someone can live here");
				break;
			}
		}
	}

	// FLAGS
	// clearing: Removing rubble and preparing to build. Lots must be cleared before building.
	void AddFlag(string flag, int duration) {
		flags.Add (flag, duration);
	}

	// TODO: Add events that happen when specific flags run out
	void ClearFlag(string flag) {
		flags.Remove (flag);
		switch (flag) {
		case "clearing":
			type = "empty";
			state = "empty";
			face = manager.GetComponent<scrBackground>().emptyEmpty;
			ShowFace ();
			break;
		}
	}

	void NewDay() {
		foreach (KeyValuePair<string, int> f in flags) {
			f.Value--;
			if(f.Value <= 0) {
				ClearFlag (f.Key);
			}
		}
	}
}
