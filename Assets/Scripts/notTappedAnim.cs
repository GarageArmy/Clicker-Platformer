using UnityEngine;
using System.Collections;

public class notTappedAnim : MonoBehaviour {

	public void notTapped (){
		this.GetComponent<Animator> ().SetBool ("Tapped", false);
	}
}
