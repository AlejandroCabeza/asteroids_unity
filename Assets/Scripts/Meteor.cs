using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour
{
    public float maximumSpeed;
    public float minimumSpeed;

    public GameObject[] pieces;

    private Vector3 direction;
    private float speed;

	// Use this for initialization
	void Start ()
	{
	    speed     = Random.Range(minimumSpeed, maximumSpeed);
	    direction = Random.insideUnitCircle.normalized;
	    ++Manager.meteorsInScreen;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += direction * speed * Time.deltaTime;

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
    }

    void DestroyMeteor()
    {
        foreach (GameObject piece in pieces)
        {
            Instantiate(piece , transform.position, transform.rotation);
        }

        --Manager.meteorsInScreen;
        Destroy(this.gameObject);
    }
}
