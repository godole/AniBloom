using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {
    public PlayerControl pc;
    public Vector3 m_DeltaPos;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector3 delta = pc.gameObject.transform.localPosition + m_DeltaPos;

        if (delta.y + 360 > 455)
            delta.y = 455 - 360;

        else if (delta.y < -240)
            delta.y = -240;

        gameObject.transform.localPosition = new Vector3(delta.x, gameObject.transform.localPosition.y, delta.z);
    }
}
