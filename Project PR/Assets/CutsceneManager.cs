using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CutsceneManager : MonoBehaviour {
    public MapData.CutsceneData[] _CutsceneData;
    public Dictionary<string, Sprite> _Images;
    int _CurrentCutsceneIndex = 0;
    public GameObject _CutscenePrefab;
    PlayerControl _PlayerControl;
    GameObject _CutsceneCamera;

    void Awake()
    {
        _Images = new Dictionary<string, Sprite>();
    }

	// Use this for initialization
	void Start () {
        _PlayerControl = GameObject.Find("Player").GetComponent<PlayerControl>();
        _CutsceneCamera = GameObject.Find("CutsceneCamera");
    }
	
	// Update is called once per frame
	void Update () {
	    if(_CutsceneData[_CurrentCutsceneIndex].Start < _PlayerControl.gameObject.transform.position.x)
        {
            _CutsceneCamera.SetActive(true);
            Cutscene cutscene = Instantiate(_CutscenePrefab).GetComponent<Cutscene>();
            cutscene.transform.SetParent(_CutsceneCamera.transform);
            cutscene.gameObject.transform.localPosition = new Vector3(0, 0, 46);
            if(_CurrentCutsceneIndex == 0)
            {
                cutscene.AddFrame(_Images["111"], 1.25);
                cutscene.AddFrame(_Images["112"], 1);
                cutscene.AddFrame(_Images["113"], 1.25);
                cutscene.AddFrame(_Images["114"], 1.5);

                cutscene.AddFrame(_Images["121"], 1.25);
                cutscene.AddFrame(_Images["122"], 1.5);
                cutscene.AddFrame(_Images["123"], 1.25);
                cutscene.AddFrame(_Images["124"], 1.25);
                cutscene.AddFrame(_Images["125"], 1.75);

                cutscene.AddFrame(_Images["131"], 1.5);
                cutscene.AddFrame(_Images["132"], 1.5);

                cutscene.AddFrame(_Images["141"], 1.25);
                cutscene.AddFrame(_Images["142"], 1.25);
                cutscene.AddFrame(_Images["143"], 2.5);
            }

            else if(_CurrentCutsceneIndex == 1)
            {
                cutscene.AddFrame(_Images["211"], 1.25);
                cutscene.AddFrame(_Images["212"], 1.25);
                cutscene.AddFrame(_Images["213"], 1.25);
                cutscene.AddFrame(_Images["214"], 1.25);

                cutscene.AddFrame(_Images["221"], 1.25);
                cutscene.AddFrame(_Images["222"], 1.25);
                cutscene.AddFrame(_Images["223"], 0.25);
                cutscene.AddFrame(_Images["224"], 0.25);
                cutscene.AddFrame(_Images["225"], 2);
                
                cutscene.AddFrame(_Images["231"], 1.25);
                cutscene.AddFrame(_Images["232"], 1.25);
                cutscene.AddFrame(_Images["233"], 0.5);

                cutscene.AddFrame(_Images["241"], 0.75);
                cutscene.AddFrame(_Images["242"], 0.75);
                cutscene.AddFrame(_Images["243"], 0.5);
                cutscene.AddFrame(_Images["244"], 0.5);
                cutscene.AddFrame(_Images["245"], 0.5);
                cutscene.AddFrame(_Images["247"], 1);
                cutscene.AddFrame(_Images["248"], 0.5);
                cutscene.AddFrame(_Images["249"], 0.5);
                cutscene.AddFrame(_Images["2410"], 0.5);
                cutscene.AddFrame(_Images["2411"], 1);
            }

            else if(_CurrentCutsceneIndex == 2)
            {
                cutscene.AddFrame(_Images["311"], 0.75);
                cutscene.AddFrame(_Images["312"], 1);
                cutscene.AddFrame(_Images["313"], 1.25);
                cutscene.AddFrame(_Images["314"], 1.5);
                cutscene.AddFrame(_Images["315"], 1);
                cutscene.AddFrame(_Images["316"], 1);

                cutscene.AddFrame(_Images["321"], 1);
                cutscene.AddFrame(_Images["322"], 1);
                cutscene.AddFrame(_Images["323"], 1);
                cutscene.AddFrame(_Images["324"], 0.2);
                cutscene.AddFrame(_Images["325"], 0.2);
                cutscene.AddFrame(_Images["326"], 0.2);
                cutscene.AddFrame(_Images["327"], 1);
                cutscene.AddFrame(_Images["328"], 1.25);
                cutscene.AddFrame(_Images["329"], 1.15);

                cutscene.AddFrame(_Images["331"], 1);
                cutscene.AddFrame(_Images["332"], 2);

                cutscene.AddFrame(_Images["341"], 1.25);
                cutscene.AddFrame(_Images["342"], 1.25);
                cutscene.AddFrame(_Images["343"], 1);
            }

            _CurrentCutsceneIndex++;
        }
	}
}
