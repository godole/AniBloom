using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Platform : MonoBehaviour{

    [SerializeField]
    private float _Width;
    bool m_IsJudged = false;
    RectTransform m_Transform;
    BoxCollider2D m_Collider2D;

    // Use this for initialization
    void Awake () {
        m_Collider2D = GetComponent<BoxCollider2D>();
        m_Transform = GetComponent<RectTransform>();
    }

    public void OnValidate()
    {
        if (m_Collider2D == null)
            m_Collider2D = gameObject.GetComponent<BoxCollider2D>();

        if (m_Transform == null)
            m_Transform = gameObject.GetComponent<RectTransform>();

        Width = _Width;
    }

    public bool IsJudged
    {
        get { return m_IsJudged; }
    }

    public float Width
    {
        get { return m_Transform.rect.width; }
        set
        {
            _Width = value;
            m_Transform.sizeDelta = new Vector2(value, m_Transform.sizeDelta.y);
            m_Collider2D.size = new Vector2(value, 100);
            m_Collider2D.offset = new Vector2(value / 2, 0);
        }
    }
}
