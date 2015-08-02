using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scrActions : MonoBehaviour {

	public GameObject confirmationPanel;

	string queuedAction = "wait";

	// Use this for initialization
	void Start () {
		HideConfirmation ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ShowConfirmation () {
		confirmationPanel.SetActive (true);
	}

	void HideConfirmation () {
		confirmationPanel.SetActive (false);
	}

	void SetAction(string act) {
		queuedAction = act;
		ShowConfirmation ();
	}

	public void PerformAction() {
		switch (queuedAction) {
		case "clear":
			Debug.Log ("Clearing Trash");
			break;
		default:
			Debug.Log ("No action selected.");
			break;
		}
		HideConfirmation ();
	}

	public void ClearAction() {
		queuedAction = "wait";
		HideConfirmation ();
	}
}
