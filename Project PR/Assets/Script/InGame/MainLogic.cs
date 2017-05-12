using UnityEngine;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class MainLogic : MonoBehaviour {
    [SerializeField]
    SlideLine m_LinePrefab;
    
    [SerializeField]
    Camera m_MainCamera;

    [System.Serializable]
    public class SlideEvent : UnityEvent<float> { }

    [SerializeField]
    public SlideEvent SlideChangeEvent;

    SlideLine m_Line;

    bool m_IsDrawing = false;
    public Vector2 _DeltaPos { get; set; }

    public float _MaxSlideTime;
    float _CurSlideTime;
    float CurSlideTime
    {
        get { return _CurSlideTime; }
        set
        {
            _CurSlideTime = value;

            if (_CurSlideTime < 0.0f)
                _CurSlideTime = 0.0f;

            else if (_CurSlideTime > _MaxSlideTime)
                _CurSlideTime = _MaxSlideTime;
        }
    }

    // Use this for initialization
    void Start() {
        _CurSlideTime = _MaxSlideTime;
    }

    // Update is called once per frame
    void Update() {
        if (Cutscene._IsPlayingCutscene)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            if (UICamera.Raycast(Input.mousePosition) == false)
            {
                CreateTempLine(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                m_IsDrawing = true;
            }
        }

        if (m_IsDrawing)
        {
            CurSlideTime -= Time.deltaTime;
            SlideChangeEvent.Invoke(CurSlideTime / _MaxSlideTime);

            m_Line.EndPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(m_Line.EndPosition.y < -160 ||
                _CurSlideTime <= 0.0f)
            {
                m_IsDrawing = false;
                Destroy(m_Line.gameObject);
                GameObject.Find("Player").GetComponent<PlayerControl>().SlideEnd();
            }
        }

        if (Input.GetMouseButtonUp(0) && m_IsDrawing)
        {
            m_IsDrawing = false;
            m_Line.DrawEnd();
        }

        if(!m_IsDrawing)
        {
            SlideChangeEvent.Invoke(CurSlideTime / _MaxSlideTime);
        }
    }

    void CreateTempLine(Vector2 startPos)
    {
        Vector3 _StartPos = (Vector3)startPos + new Vector3(0, 0, 5);
        m_Line = Instantiate(m_LinePrefab);
        m_Line.StartPosition = startPos;

        m_Line.gameObject.transform.localPosition = _StartPos;
        m_Line.gameObject.transform.localScale = Vector3.one;
    }

    public void GameReset()
    {
        SceneManager.LoadScene("Test");
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        GameObject.Find("BGM").GetComponent<AudioSource>().Pause();
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        GameObject.Find("BGM").GetComponent<AudioSource>().Play();
    }

    public void GoTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
