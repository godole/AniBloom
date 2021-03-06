﻿using UnityEngine;
using System.Collections;

public class JumpButton : MonoBehaviour {
    PlayerControl pc;
    bool _IsDown = false;

	// Use this for initialization
	void Start () {
        pc = GameObject.Find("Player").GetComponent<PlayerControl>();
	}
	
	// Update is called once per frame
	void Update () {
        if(_IsDown)
            pc.JumpJudge();
    }

    void OnPress(bool IsDown)
    {
        if (IsDown)
        {
            _IsDown = true;
            pc.JumpEnterJudge();
        }

        else
        {
            _IsDown = false;
            pc.JumpEndJudge();
        }
    }
}
