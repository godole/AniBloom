using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cutscene : MonoBehaviour {
    public static bool _IsPlayingCutscene { get; set; }

    public List<Sprite> _Sprites;
    public List<double> _Length;

    SpriteRenderer _SpriteRenderer;
    double _CurTime = 0;
    int _CurIndex = 0;

	// Use this for initialization
    void Awake()
    {
        _Sprites = new List<Sprite>();
        _Length = new List<double>();
    }

	void Start () {
        _SpriteRenderer = GetComponent<SpriteRenderer>();
        _SpriteRenderer.sprite = _Sprites[0];
        _IsPlayingCutscene = true;
    }
	
	// Update is called once per frame
	void Update () {
        _CurTime += Time.deltaTime;

        if(_CurTime > (_Length[_CurIndex]))
        {
            _CurIndex++;
            _CurTime = 0;
            if (_CurIndex >= _Sprites.Count)
            {
                _CurIndex = _Sprites.Count - 1;
                GameObject.Find("CutsceneCamera").SetActive(false);
                Destroy(this.gameObject);
                _IsPlayingCutscene = false;
                return;
            }
            _SpriteRenderer.sprite = _Sprites[_CurIndex];
        }
	}

    public void AddFrame(Sprite sprite, double duration)
    {
        _Sprites.Add(sprite);
        _Length.Add(duration);
    }
}
