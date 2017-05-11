using UnityEngine;
using System.Collections;

public class SlideCallback : MonoBehaviour {
    UIProgressBar _Bar;

	// Use this for initialization
	void Start () {
        _Bar = gameObject.GetComponent<UIProgressBar>();
    }
	
	public void ChangeSlideValue(float percent)
    {
        _Bar.value = percent;
    }
}
