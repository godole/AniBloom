using UnityEngine;
using System.Collections;

public class MenuPopup : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OpenAnimation()
    {
        gameObject.SetActive(true);
        TweenScale.Begin(gameObject, 0.2f, new Vector3(1f, 1f, 1f));
    }

    public void CloseAnimation()
    {
        TweenScale ts = TweenScale.Begin(gameObject, 0.2f, new Vector3(0.0f, 0.0f, 1f));
        ts.callWhenFinished = "CloseAniEnd";
        Time.timeScale = 1.0f;
    }

    void CloseAniEnd()
    {
        gameObject.SetActive(false);
    }
}
