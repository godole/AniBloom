using UnityEngine;
using System.Collections;

public class LopeCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.transform.tag)
        {
            case "Lope":
                PlayerControl pc = GameObject.Find("Player").GetComponent<PlayerControl>();
                pc.ChangeState(new LopeState(pc, col, this));
                pc.ObstacleTriggerCheck(col);
                break;
        }
    }
}
