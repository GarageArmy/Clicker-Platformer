using UnityEngine;
using System.Collections;

public class DestroyObj : MonoBehaviour {
	public float timeDestroy;
	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, timeDestroy);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
