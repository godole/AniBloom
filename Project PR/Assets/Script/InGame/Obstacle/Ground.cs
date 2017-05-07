using UnityEngine;
using System.Collections;
using System;

public class Ground : MonoBehaviour,
    IStepable{
    RectTransform m_Transform;
    BoxCollider2D m_Collider2D;

    [SerializeField]
    private float _Width;
    [SerializeField]
    private float _Angle;

    void Reset()
    {
        if (m_Collider2D == null)
            m_Collider2D = GetComponent<BoxCollider2D>();

        if (m_Transform == null)
            m_Transform = GetComponent<RectTransform>();
    }

    // Use this for initialization
    void Awake () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnValidate()
    {
        if (m_Collider2D == null)
            m_Collider2D = GetComponent<BoxCollider2D>();

        if(m_Transform == null)
            m_Transform = GetComponent<RectTransform>();

        Width = _Width;
        Angle = _Angle;
    }

    public Vector2 CalcStepPoint(RectTransform playerTransform)
    {
        float b = playerTransform.position.x - gameObject.transform.position.x;
        float a = Mathf.Tan(Angle * Mathf.Deg2Rad) * b;

        return new Vector2(playerTransform.position.x, gameObject.transform.position.y + a + playerTransform.rect.height * 100 / 2);
    }

    public Vector2 CalcMoveVector(RectTransform playerTransform, float maxSpeed)
    {
        float length = Mathf.Sqrt(new Vector2(maxSpeed, 0.0f).SqrMagnitude()) / Mathf.Cos(Angle);

        return Normal * length;
    }

    public float Width
    {
        get { return m_Transform.rect.width; }
        set
        {
            _Width = value;
            m_Transform.sizeDelta = new Vector2(value, m_Transform.sizeDelta.y);
            m_Collider2D.size = new Vector2(value, m_Collider2D.size.y);
            m_Collider2D.offset = new Vector2(value / 2, m_Collider2D.offset.y);
        }
    }

    public Vector2 Normal
    {
        get
        {
            Vector2 retvec = new Vector2();

            retvec.x = Mathf.Cos(_Angle * Mathf.Deg2Rad);
            retvec.y = Mathf.Sin(_Angle * Mathf.Deg2Rad);

            return retvec;
        }
    }

    public float Angle
    {
        get
        {
            return _Angle;
        }
        set
        {
            _Angle = value;

            m_Transform.localEulerAngles = new Vector3(0.0f, 0.0f, value);
        }
    }
}
