using UnityEngine;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;

public class MainLogic : MonoBehaviour {
    [SerializeField]
    SlideLine m_LinePrefab;
    
    [SerializeField]
    Camera m_MainCamera;

    SlideLine m_Line;

    bool m_IsDrawing = false;
    public Vector2 _DeltaPos { get; set; }

    // Use this for initialization
    void Start() {
        
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
            m_Line.EndPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(m_Line.EndPosition.y < -260)
            {
                m_IsDrawing = false;
                Destroy(m_Line.gameObject);
            }
        }

        if (Input.GetMouseButtonUp(0) && m_IsDrawing)
        {
            m_IsDrawing = false;
            m_Line.DrawEnd();
        }
    }

    void CreateTempLine(Vector2 startPos)
    {
        Vector3 _StartPos = (Vector3)startPos + new Vector3(0, 0, 5);
        m_Line = Instantiate<SlideLine>(m_LinePrefab);
        m_Line.StartPosition = startPos;

        m_Line.gameObject.transform.localPosition = _StartPos;
        m_Line.gameObject.transform.localScale = Vector3.one;
    }

    public void GameReset()
    {
        SceneManager.LoadScene("InGame");
        //LopeManager.getInstance().Clear();
        //m_Player.Reset();
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
