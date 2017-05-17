using UnityEngine;
using System.Collections;

public class Region : MonoBehaviour {
    public string _StageName;
    public string _TitleText;
    public string _ExplaneText;
    public string _ButtonText;

    public WordBubble _WordBubble;

    bool _IsLock = false;

    void Awake()
    {
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Unlock()
    {
        _IsLock = true;
    }

    void OnPress(bool isDown)
    {
        if (isDown)
        {
            if(_IsLock)
            {
                SelectedRegionName.RegionName = _StageName;
                _WordBubble.Title = _TitleText;
                _WordBubble.Explane = _ExplaneText;
                _WordBubble.ButtonText = _ButtonText;

                _WordBubble.OpenAnimation();
            }
        }
    }
}
