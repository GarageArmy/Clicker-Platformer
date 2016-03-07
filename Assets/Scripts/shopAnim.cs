using UnityEngine;
using System.Collections;

public class shopAnim : MonoBehaviour {

	public Animator shopAnimator;

	public void shopAnimController(){
		if (shopAnimator.GetBool ("isUp"))
			shopAnimator.SetBool ("isUp", false);
		else
			shopAnimator.SetBool ("isUp", true);
		if (this.name == "TapShop") {
			GameObject.Find ("PerSecShop").GetComponent<Animator> ().SetBool ("isUp", false);
		}
		if (this.name == "PerSecShop") {
			GameObject.Find ("TapShop").GetComponent<Animator> ().SetBool ("isUp", false);
		}
	}
}
