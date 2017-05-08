using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	[SerializeField]
	public float speed = 3f;
    public float jumpForce = 15f;
    public float jumpValue = 15f;

    new private Rigidbody2D rigidbody;
	private Animator animator;
    private SpriteRenderer sprite;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Use this for initialization
    private void Start () {
		
	}

    // Update is called once per frame
    private void Update () {
        if (Input.GetButton("Horisontal")) Run();
        if (Input.GetButton("Jump")) Jump();
	}

    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horisontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        sprite.flipX = direction.x < 0;
    }

    private void Jump()
    {
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
}
