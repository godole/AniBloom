using UnityEngine;
using System.Collections;

public class Keisan : MonoBehaviour {

    public Vector2 _DeltaPosition;

    public MenuPopup _WordBubble;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlaySelectAnimation1()
    {
        GameObject btn1 = GameObject.Find("Button1");
        TweenPosition tween = TweenPosition.Begin(gameObject, 1.0f, (-(Vector2)btn1.transform.localPosition) * 3.2f + _DeltaPosition);
        tween.AddOnFinished(new EventDelegate(_WordBubble, "OpenAnimation"));
        TweenScale ts = TweenScale.Begin(gameObject, 1.0f, new Vector3(3.2f, 3.2f));
    }
}
