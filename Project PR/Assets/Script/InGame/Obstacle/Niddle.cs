using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Niddle : MonoBehaviour{
    
    bool m_IsJudged = false;
    RectTransform m_Transform;
    BoxCollider2D m_Collider2D;

    int m_nCount = 0;

    // Use this for initialization
    void Awake () {
        m_Collider2D = GetComponent<BoxCollider2D>();
        m_Transform = GetComponent<RectTransform>();
        IsFlip = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool IsJudged
    {
        get { return m_IsJudged; }
    }

    public int Count
    {
        get
        {
            return m_nCount;
        }
        set
        {
            m_nCount = value;

            float w = 80;
            m_Transform.sizeDelta = new Vector2(w * value, 80);
            m_Collider2D.size = new Vector2(w* value, 80);
            m_Collider2D.offset = new Vector2(w * value / 2, 80);
        }
    }

    public bool IsFlip
    {
        get
        {
            return m_Transform.localScale.y.Equals(-1.0f);
        }
        set
        {
            m_Transform.localScale = new Vector3(1, value ? -1 : 1, 1);
        }
    }
}
