using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]

public class PhysicBullet : MonoBehaviour
{
    private float aliveTime;

    public float speed;
    public float lifeTime;
    public static List<PhysicBullet> bulletsInScreen = new List<PhysicBullet>();

	// Use this for initialization
	void Start ()
	{
        bulletsInScreen.Add(this);
	    this.GetComponent<Rigidbody>().velocity = transform.up * speed;
	}

    void OnDestroy()
    {
        bulletsInScreen.Remove(this);
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
	    aliveTime += Time.deltaTime;
        if (aliveTime >= lifeTime) Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision coll)
    {
        Destroy(this.gameObject);
    }
}