using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PanelController : MonoBehaviour {
	public void PanelPadding (int pieces, string name){ 
		GameObject.Find(name).GetComponent<VerticalLayoutGroup> ().padding.bottom = 280 - (pieces * 30);
	}

}
