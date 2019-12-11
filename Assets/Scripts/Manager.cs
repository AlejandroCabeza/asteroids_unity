using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour
{
    private static int wave = 0;

    public GameObject meteor;
    public bool Spawn = true;
    public static int meteorsInScreen = 0;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Spawn && meteorsInScreen <= 0)
        {
            meteorsInScreen = 0;
	        Debug.Log("Wave: " + wave);
	        for (int i = 0; i < wave + 1; ++i)
	        {
	            Instantiate(meteor, transform.position + ((Vector3)Random.insideUnitCircle * 20), transform.rotation);
	        }

	        ++wave;
	    }
	}
}
