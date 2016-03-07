using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Click : MonoBehaviour {

	public int maxTouch, touchValue;
	int TouchNumber;
	Vector3 worldPos;
	public GameObject tapDisplay;
	public void CheckIfTouched () {
		TouchNumber = 0;
		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began && TouchNumber < maxTouch) {
				TouchNumber++;
				GetComponent<ClickerHandler> ().TotalCoinsValue += touchValue;
				GameObject.Find("Chest").GetComponent<Animator> ().SetBool ("Tapped", true);
				worldPos = Camera.main.ScreenToWorldPoint(touch.position);
				worldPos.z = 20;
				Debug.Log (worldPos);
				GameObject tap = (GameObject)Instantiate (tapDisplay, worldPos, Quaternion.identity);
				Debug.Log (tap.transform.position);
				tap.GetComponentInChildren<Text> ().text = "+ " + touchValue.ToString ("D");
			}

		}

	}
}
