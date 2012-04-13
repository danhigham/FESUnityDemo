using UnityEngine;
using System.Collections;

public class DoorAnimator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		Animation anim = GetComponent<Animation>();
		
		anim.Play("DoorOpen");
	}
	
	void OnTriggerExit(Collider other)
	{
		Animation anim = GetComponent<Animation>();
		
		anim.Play("DoorClose");
		
	}
}
