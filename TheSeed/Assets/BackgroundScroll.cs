using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {
    GameObject _Player;
    Vector2 _WorldSize;

    void Awake()
    {
        _Player = GameObject.Find("Player");
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 scrSize = new Vector2(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        if (gameObject.transform.position.x > scrSize.x || gameObject.transform.position.x < -scrSize.x)
            gameObject.transform.position = new Vector3(0, gameObject.transform.position.y, gameObject.transform.position.z);

        else if (gameObject.transform.position.y > scrSize.y || gameObject.transform.position.y < -scrSize.y)
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z);
    }
}
