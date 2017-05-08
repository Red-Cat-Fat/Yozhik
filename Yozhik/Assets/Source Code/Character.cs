using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	[SerializeField]
	public float speed = 3f;
	public float jumpValue = 15f;

	new private Rigidbody2D rigidbody;
	private Animator animator;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
