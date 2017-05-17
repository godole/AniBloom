using UnityEngine;
using System.Collections;

public class KeisanSpace : MonoBehaviour {
    public float _AngleSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(new Vector3(0, 0, _AngleSpeed * Time.deltaTime));
	}
}
