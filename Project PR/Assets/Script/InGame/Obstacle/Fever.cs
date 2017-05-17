using UnityEngine;
using System.Collections;
using System;

public class Fever : MonoBehaviour{
    
    bool m_IsJudged = false;

    // Use this for initialization
    void Awake()
    {
    }

    // Update is called once per frame
    void Update () {
	
	}

    public bool IsJudged
    {
        get { return m_IsJudged; }
    }
}
