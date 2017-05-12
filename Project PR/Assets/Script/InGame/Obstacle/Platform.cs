using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Platform : MonoBehaviour,
    IStepable{

    [SerializeField]
    private float _Width;
    [SerializeField]
    private float _Height;
    bool m_IsJudged = false;
    RectTransform m_Transform;
    BoxCollider2D m_Collider2D;

    // Use this for initialization
    void Awake () {
        m_Collider2D = GetComponent<BoxCollider2D>();
        m_Transform = GetComponent<RectTransform>();

        Width = _Width;
    }

    public void OnValidate()
    {
        if (m_Collider2D == null)
            m_Collider2D = gameObject.GetComponent<BoxCollider2D>();

        if (m_Transform == null)
            m_Transform = gameObject.GetComponent<RectTransform>();

        ChangeValue();
    }

    void ChangeValue()
    {
        Width = _Width;
    }

    public Vector2 CalcStepPoint(RectTransform playerTransform)
    {
        return new Vector2(playerTransform.position.x, gameObject.transform.position.y + playerTransform.rect.height * 100 / 2);
    }

    public Vector2 CalcMoveVector(RectTransform playerTransform, float maxSpeed)
    {
        return new Vector2(maxSpeed, 0);
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
            m_Transform.sizeDelta = new Vector2(value, _Height);
            m_Collider2D.size = new Vector2(value, _Height / 2);
            m_Collider2D.offset = new Vector2(value / 2, -_Height / 4);
        }
    }
}
