using UnityEngine;
using System.Collections;

public class JumpButton : MonoBehaviour {
    PlayerControl pc;

	// Use this for initialization
	void Start () {
        pc = GameObject.Find("Player").GetComponent<PlayerControl>();
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnPress(bool IsDown)
    {
        if (Cutscene._IsPlayingCutscene)
            return;

        if(IsDown)
            pc.JumpJudge();

        else
            pc.JumpEndJudge();
    }
}
