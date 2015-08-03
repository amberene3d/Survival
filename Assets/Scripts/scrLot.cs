using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using CustomClasses;

public class scrLot : MonoBehaviour {

	GameObject manager;
	public SpriteRenderer spr;

	public string type;
	public string state;
	public Sprite face;

	public List<Flag> flags = new List<Flag>();

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
		Flag f = new Flag ();
		f.name = flag;
		f.duration = duration;
		flags.Add (f);
	}

	// TODO: Add events that happen when specific flags run out
	void ClearFlag(string flag) {
//		flags.Remove (flag);
//		switch (flag) {
//		case "clearing":
//			type = "empty";
//			state = "empty";
//			face = manager.GetComponent<scrBackground>().emptyEmpty;
//			ShowFace ();
//			break;
//		}
	}

	void NewDay() {
//		foreach (KeyValuePair<string, int> f in flags) {
//			f.Value = f.Value - 1;
//			if(f.Value <= 0) {
//				ClearFlag (f.Key);
//			}
//		}
	}
}
