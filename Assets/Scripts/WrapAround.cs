using UnityEngine;
using System.Collections;

public class WrapAround : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    checkWrap();
	}

    void checkWrap()
    {
        Vector3 cPosition = Camera.main.WorldToViewportPoint(this.transform.position);

        if (cPosition.x < 0) cPosition += Vector3.right;
        if (cPosition.x > 1) cPosition -= Vector3.right;
        if (cPosition.y < 0) cPosition += Vector3.up;
        if (cPosition.y > 1) cPosition -= Vector3.up;

        transform.position = Camera.main.ViewportToWorldPoint(cPosition);
    }
}
