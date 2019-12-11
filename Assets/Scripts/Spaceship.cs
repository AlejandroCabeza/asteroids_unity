using UnityEngine;
using System.Collections;
using UnityEditor;

public class Spaceship : MonoBehaviour
{
    private bool left;
    private bool right;
    private bool boost;
    private bool shoot;

    private Vector3 speed;

    public float RotationSpeed;
    public float Acceleration;
    public float Drag;
    public GameObject bullet;
    public static int maximumAmountOfBullets = 20;

    public static Spaceship _instance ;


    // Use this for initialization
    void Start ()
    {
        _instance = this;
    }
	
	// Update is called once per frame
	void Update ()
	{
	    checkInput();

	    float rotation = 0.0f;

	    if (left)  ++rotation;
	    if (right) --rotation;

	    this.transform.eulerAngles += Vector3.forward * rotation * Time.deltaTime * RotationSpeed;

	    if (boost) speed += transform.up * Acceleration * Time.deltaTime;
	    transform.position += speed * Time.deltaTime;
	    speed *= 1 - (Drag * Time.deltaTime);

	    if (shoot && Bullet.bulletsInScreen.Count < maximumAmountOfBullets) Instantiate(bullet, transform.position, transform.rotation);
	}

    void checkInput()
    {
        left  = Input.GetKey(KeyCode.LeftArrow);
        right = Input.GetKey(KeyCode.RightArrow);
        boost = Input.GetKey(KeyCode.UpArrow);
        shoot = Input.GetKeyDown(KeyCode.Space);
    }
}