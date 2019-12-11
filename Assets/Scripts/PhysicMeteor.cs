using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class PhysicMeteor : MonoBehaviour
{
    public float maximumSpeed;
    public float minimumSpeed;
    public float maximumAngularSpeed;
    public float minimumAngularSpeed;

    public GameObject[] pieces;

    private Vector3 direction;
    private float speed;
    private bool isDestroyed = false;

	// Use this for initialization
	void Start ()
	{
	    speed     = Random.Range(minimumSpeed, maximumSpeed);
	    direction = Random.insideUnitCircle.normalized;

        //EHMMM... WTF
	    transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z);

        this.GetComponent<Rigidbody>().velocity = direction * speed;
	    this.GetComponent<Rigidbody>().angularVelocity = Vector3.forward * Random.Range(minimumAngularSpeed, maximumAngularSpeed);
        ++Manager.meteorsInScreen;
    }
	
	// Update is called once per frame
	void Update ()
    {
        /*
	    foreach (Bullet bullet in Bullet.bulletsInScreen)
	    {
	        if (Vector3.Distance(bullet.transform.position, this.transform.position) < this.transform.localScale.x)
	        {
	            DestroyMeteor();
                bullet.SetToDestroy();
	        }
	    }

        if (Spaceship._instance != null && Vector3.Distance(Spaceship._instance.transform.position, this.transform.position) < this.transform.localScale.x)
        {
            DestroyMeteor();
            Destroy(Spaceship._instance.gameObject);
        }
        */
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.GetComponent<PhysicMeteor>() == null) DestroyMeteor();
    }

    void DestroyMeteor()
    {
        if (isDestroyed) return;
        isDestroyed = true;

        foreach (GameObject piece in pieces)
        {
            piece.SetActive(true);
            piece.transform.parent = null;
        }

        --Manager.meteorsInScreen;
        Destroy(this.gameObject);
        Debug.Log(Manager.meteorsInScreen);
    }
}
