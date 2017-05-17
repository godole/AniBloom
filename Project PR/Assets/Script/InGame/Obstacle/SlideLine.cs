using UnityEngine;
using System.Collections;
using System;

public class SlideLine : MonoBehaviour,
    IStepable{
    SpriteRenderer m_SlideSprite;
    GameObject player;

    Vector2 m_StartPosition;
    Vector2 m_EndPosition;

    bool m_IsDrawing = true;
    [SerializeField]
    float StepDeltaY;

    // Use this for initialization
    void Start () {
        m_SlideSprite = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if (player.transform.localPosition.x - gameObject.transform.localPosition.x > 2000)
            Destroy(gameObject);

        if (m_IsDrawing)
            DrawingUpdate();
    }

    public Vector2 StartPosition
    {
        set { m_StartPosition = value; }
        get { return m_StartPosition.x < m_EndPosition.x ? m_StartPosition : m_EndPosition; }
    }

    public Vector2 EndPosition
    {
        set { m_EndPosition = value; }
        get { return m_StartPosition.x > m_EndPosition.x ? m_StartPosition : m_EndPosition; }
    }

    void DrawingUpdate()
    {
        Vector2 distVec = m_EndPosition - m_StartPosition;
        float dist = distVec.magnitude;
        float radius = Mathf.Atan2(distVec.y, distVec.x) * Mathf.Rad2Deg;

        m_SlideSprite.gameObject.transform.localScale = new Vector3(dist, 15, 1);
        gameObject.transform.localEulerAngles = new Vector3(0.0f, 0.0f, radius);
    }

    public void DrawEnd()
    {
        m_IsDrawing = false;
    }

    public Vector2 CalcStepPoint(RectTransform playerTransform)
    {
        Vector2 deltaPos = EndPosition - StartPosition;
        float xdelta = playerTransform.position.x - StartPosition.x;
        float ydelta = (xdelta / deltaPos.x) * deltaPos.y;

        return new Vector2(playerTransform.position.x, ydelta + StartPosition.y + StepDeltaY);
    }

    public Vector2 CalcMoveVector(RectTransform playerTransform, float maxSpeed)
    {
        float cy = (StartPosition.y > EndPosition.y ? StartPosition.y : EndPosition.y);
        if (playerTransform.localPosition.y - playerTransform.rect.height * 100 / 2> cy)
        {
            return new Vector3(maxSpeed, 0.0f, 0.0f);
        }
        else
        {
            Vector2 deltaPos = EndPosition - StartPosition;
            float angle = Mathf.Atan2(deltaPos.y, deltaPos.x);
            float length = Mathf.Sqrt(new Vector2(maxSpeed, 0.0f).SqrMagnitude()) / Mathf.Cos(angle);

            return deltaPos.normalized * length;
        }
    }
}
