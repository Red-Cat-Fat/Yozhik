using UnityEngine;
using System.Threading;
using System.Collections;

public class Character : MonoBehaviour {

	[SerializeField]
	public float speed = 3f;
    public float jumpForce = 0.00001f;
    public float jumpValue = 15f;

    Serial serial;

    new private Rigidbody2D rigidbody;
	private Animator animator;
    private SpriteRenderer sprite;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();

        serial = new Serial();
        serial.UpdatePorts();
        Debug.Log(serial.AvailablePorts[0]);
        //на соплях! нужно поправить
        serial.Create(0, 115200);
        Thread.Sleep(100);
        serial.Open();
        Debug.Log(serial.WaitRecv());
    }

    // Use this for initialization
    private void Start () {
    }

    // Update is called once per frame
    private void Update () {
        if (Input.GetKey(KeyCode.A)&& Input.GetKey(KeyCode.D)) Run();
        if (Input.GetKey(KeyCode.Space)) Jump();
	}

    private void Run()
    {
        Vector3 direction = transform.right;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        sprite.flipX = !Input.GetKey(KeyCode.A);
    }

    private void Jump()
    {
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
}
