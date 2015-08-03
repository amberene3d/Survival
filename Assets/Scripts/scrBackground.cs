using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using CustomClasses;

public class scrBackground : MonoBehaviour {

	Transform tr;
	bool isMoving;

	public GameObject lot;

	public List<GameObject> lots = new List<GameObject> ();

	int numLots = 8;
	int slotWidth = 6;

	public List<Vector3> positions = new List<Vector3> ();
	int currentPos = 0;

	Vector3 targetPos;

	public Sprite emptyTrash, emptyEmpty;
	public Sprite housingTent;
	
	void Start () {
		tr = Camera.main.GetComponent<Transform> ();
		for (int i = 0; i < numLots; i++) {
			GameObject l = Instantiate(lot, new Vector3(i * slotWidth, 0, 0), Quaternion.identity) as GameObject;
			lots.Add (l);
			l.SendMessage("SetType","empty");
			if(Random.Range(0,100) < 75) {
				l.SendMessage("SetState","trash");
				l.SendMessage("SetFace",emptyTrash);
			} else {
				l.SendMessage("SetState","empty");
				l.SendMessage("SetFace",emptyEmpty);
			}
			l.SendMessage("ShowFace");
			positions.Add (new Vector3((i * slotWidth) + tr.position.x, tr.position.y, tr.position.z));
		}

		tr.position = positions [currentPos];
	}
	
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
			isMoving = true;
		}
	}

	public void MoveRight() {
		if (currentPos < positions.Count - 2) {
			currentPos++;
			targetPos = positions[currentPos];
			isMoving = true;
		}
	}
	
}
