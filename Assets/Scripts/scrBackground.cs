using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using CustomClasses;

public class scrBackground : MonoBehaviour {

	Transform tr;
	bool isMoving;

	public List<Lot> lots = new List<Lot> ();

	public List<GameObject> slots = new List<GameObject> ();
	int slotWidth = 6;

	public List<Vector3> positions = new List<Vector3> ();
	int currentPos = 0;

	Vector3 targetPos;

	public GameObject emptyTrash, emptyEmpty;
	public GameObject housingTent;
	
	void Start () {
		tr = Camera.main.GetComponent<Transform> ();
		for (int i = 0; i < lots.Count; i++) {
			GameObject l = emptyEmpty;
			switch(lots[i].type) {
			case "empty":
				if(lots[i].state == "trash") l = emptyTrash;
				else l = emptyEmpty;
				break;
			case "housing":
				l = housingTent;
				break;
			}
			Instantiate (l, new Vector3(i * slotWidth, 0, 0), Quaternion.identity);
			positions.Add (new Vector3((i * slotWidth) + tr.position.x, tr.position.y, tr.position.z));
		}

		tr.position = positions [currentPos];
	}
	
	// Update is called once per frame
	void Update () {
		if (isMoving) {
			if(tr.position != targetPos) {
				float dist = Vector3.Distance (tr.position, targetPos);
				if(dist < 0.1f) {
					if(dist < 0.025f) {
						tr.position = targetPos;
					} else {
						tr.position = Vector3.Lerp(tr.position, targetPos, Time.deltaTime * 2);
					}
				} else {
					tr.position = Vector3.Lerp(tr.position, targetPos, Mathf.SmoothStep(0f, 5f, Time.deltaTime * 2));
				}
			} else {
				isMoving = false;
			}
		}
	}

	public void MoveLeft() {
		if (currentPos > 0) {
			currentPos--;
			targetPos = positions[currentPos];
			//tr.position = positions[currentPos];
			isMoving = true;
		}
	}

	public void MoveRight() {
		if (currentPos < positions.Count - 2) {
			currentPos++;
			targetPos = positions[currentPos];
			//tr.position = positions[currentPos];
			isMoving = true;
		}
	}
	
}
