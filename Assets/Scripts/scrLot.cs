using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class scrLot : MonoBehaviour {

	GameObject manager;

	public string type;
	public string state;

	// Use this for initialization
	void Start () {
		manager = GameObject.Find ("Manager");
	}
	
	// Update is called once per frame
	void Update () {
	
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
}
