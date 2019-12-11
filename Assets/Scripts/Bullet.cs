using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour
{
    private float aliveTime;

    public float speed;
    public float lifeTime;
    public static List<Bullet> bulletsInScreen = new List<Bullet>();

	// Use this for initialization
	void Start ()
	{
        bulletsInScreen.Add(this);
	}

    void OnDestroy()
    {
        bulletsInScreen.Remove(this);
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += transform.up * speed * Time.deltaTime;

	    aliveTime += Time.deltaTime;
        if (aliveTime >= lifeTime) Destroy(this.gameObject);
    }

    public void SetToDestroy()
    {
        aliveTime = lifeTime;
    }
}