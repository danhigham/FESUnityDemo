using UnityEngine;
using System.Collections;

public class ObjectCreator : MonoBehaviour {
	
	public GameObject CubeThing;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown)
		{
			Instantiate(CubeThing, new Vector3(0, 10f, 0), Quaternion.identity);	
		}
	}
}
