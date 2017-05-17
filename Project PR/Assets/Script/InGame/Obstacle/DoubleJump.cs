using UnityEngine;
using System.Collections;

public class DoubleJump : MonoBehaviour
{
    bool m_IsJudged = false;

    // Use this for initialization
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool IsJudged
    {
        get { return m_IsJudged; }
        set { m_IsJudged = value; }
    }
}
