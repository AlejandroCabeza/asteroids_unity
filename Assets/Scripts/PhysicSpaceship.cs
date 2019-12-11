using UnityEngine;
using System.Collections;
using UnityEditor;

[RequireComponent(typeof(Rigidbody))]

public class PhysicSpaceship : MonoBehaviour
{
    private bool left;
    private bool right;
    private bool boost;
    private bool shoot;

    private Vector3 speed;

    public float RotationSpeed;
    public float Acceleration;

    public GameObject bullet;
    private Rigidbody  body;

    public static int maximumAmountOfBullets = 20;

    public static PhysicSpaceship instance;


    // Use this for initialization
    void Start()
    {
        instance = this;
        body = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        checkInput();

        /*
        
        transform.position += speed * Time.deltaTime;
        speed *= 1 - (Drag * Time.deltaTime);
        */
        if (shoot && Bullet.bulletsInScreen.Count < maximumAmountOfBullets) Instantiate(bullet, transform.position, transform.rotation);
        
    }

    void FixedUpdate()
    {
        float rotation = 0.0f;
        if (left) ++rotation;
        if (right) --rotation;
        this.body.angularVelocity = Vector3.forward * RotationSpeed * rotation;

        if (boost) this.body.AddRelativeForce(Vector3.up * Acceleration, ForceMode.Acceleration);

        resetInput();
    }

    void resetInput()
    {
        shoot = false;
    }

    void checkInput()
    {
        left = Input.GetKey(KeyCode.LeftArrow);
        right = Input.GetKey(KeyCode.RightArrow);
        boost = Input.GetKey(KeyCode.UpArrow);
        if (Input.GetKeyDown(KeyCode.Space)) shoot = true;
    }

    void OnCollisionEnter(Collision coll)
    {
        Destroy(this.gameObject);
    }
}