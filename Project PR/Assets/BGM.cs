using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BGM : MonoBehaviour {
    [SerializeField]
    List<AudioClip> _BGMList;
    AudioSource _BGM;
    int _CurBGMIndex = 0;

	// Use this for initialization
	void Start () {
        _BGM = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(!_BGM.isPlaying)
        {
            _CurBGMIndex++;
            _BGM.clip = _BGMList[_CurBGMIndex];
            _BGM.Play();
        }
	}
}
