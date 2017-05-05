using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LineCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Slide":
                GameObject.Find("Logic").GetComponent<MainLogic>().GameReset();
                break;
        }
    }
}
