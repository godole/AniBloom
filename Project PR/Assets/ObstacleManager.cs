using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ObstacleManager : MonoBehaviour {
    public GameObject m_PlatformPrefab;
    public GameObject m_RopePrefab;
    public GameObject m_GroundPrefab;
    public GameObject m_NiddlePrefab;
    public GameObject m_FeverPrefab;
    public GameObject m_SpringPrefab;
    public GameObject m_DoubleJumpPrefab;

    List<GameObject> m_ObstacleList = new List<GameObject>();
    List<Dictionary<string, string>> _ObjectDataList = new List<Dictionary<string, string>>();

    int _CurrentObjectIndex = 0;
    int _CurrentObjectPositionX;

    PlayerControl _PlayerControl;

    bool _IsStart = false;

    // Use this for initialization
    void Awake () {
        _PlayerControl = GameObject.Find("Player").GetComponent<PlayerControl>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!_IsStart)
            return;

        if (_ObjectDataList.Count <= _CurrentObjectIndex)
            return;

	    if(_CurrentObjectPositionX < _PlayerControl.gameObject.transform.position.x + 1280)
        {
            if (_ObjectDataList[_CurrentObjectIndex]["objectType"] == "ground")
                CreateObject(_CurrentObjectIndex++);
            else
                m_ObstacleList.Add(CreateObject(_CurrentObjectIndex++));
            _CurrentObjectPositionX = Convert.ToInt32(_ObjectDataList[_CurrentObjectIndex]["positionX"]);
        }

        if (m_ObstacleList.Count == 0)
            return;

        if(m_ObstacleList[0].transform.position.x < _PlayerControl.gameObject.transform.position.x - 1280)
        {
            GameObject o = m_ObstacleList[0];
            m_ObstacleList.Remove(o);
            Destroy(o);
        }
	}

    public List<GameObject> ObstacleList { get { return m_ObstacleList; } }

    public void AddObjectData(Dictionary<string, string> objData)
    {
        _ObjectDataList.Add(objData);
    }

    public void Sort()
    {
        _ObjectDataList.Sort((Dictionary<string, string> o1, Dictionary<string, string> o2) =>
        {
            return Convert.ToInt32(o1["positionX"]).CompareTo(Convert.ToInt32(o2["positionX"]));
        });
    }

    public void StartUp()
    {
        _CurrentObjectPositionX = Convert.ToInt32(_ObjectDataList[0]["positionX"]);

        while (_CurrentObjectPositionX < _PlayerControl.gameObject.transform.position.x + 1280)
        {
            if (_ObjectDataList[_CurrentObjectIndex]["objectType"] == "ground")
                CreateObject(_CurrentObjectIndex++);
            else
                m_ObstacleList.Add(CreateObject(_CurrentObjectIndex++));
            _CurrentObjectPositionX = Convert.ToInt32(_ObjectDataList[_CurrentObjectIndex]["positionX"]);
        }

        _IsStart = true;
    }

    GameObject CreateObject(int index)
    {
        string objType = _ObjectDataList[index]["objectType"];
        GameObject retObj = null;

        switch(objType)
        {
            case "platform":
                MapData.PlatformObjectData p = new MapData.PlatformObjectData(_ObjectDataList[index]);
                retObj = CreatePlatform(new Vector2(p.PositionX - 50, 600 - p.PositionY), p.Count);
                break;

            case "fever":
                MapData.NormalObjectlData f = new MapData.NormalObjectlData(_ObjectDataList[index]);
                retObj = CreateFever(new Vector2(f.PositionX, 600 - f.PositionY));
                break;

            case "double":
                MapData.NormalObjectlData d = new MapData.NormalObjectlData(_ObjectDataList[index]);
                retObj = CreateDoubleJump(new Vector2(d.PositionX, 600 - d.PositionY));
                break;

            case "niddle":
                MapData.NiddleObjectData n = new MapData.NiddleObjectData(_ObjectDataList[index]);
                retObj = CreateNiddle(new Vector2(n.PositionX - 50, 600 - n.PositionY), n.Count, n.IsFlip);
                break;

            case "spring":
                MapData.SpringObjectData s = new MapData.SpringObjectData(_ObjectDataList[index]);
                retObj = CreateSpring(new Vector2(s.PositionX, 600 - s.PositionY), s.Count, s.IsUpStart, s.SizeCount, GameObject.Find("Logic").GetComponent<MainLogic>()._DeltaPos);
                break;

            case "ground":
                MapData.NormalObjectlData g = new MapData.NormalObjectlData(_ObjectDataList[index]);
                retObj = CreateGround(new Vector2(g.PositionX, -500), g.Width);
                break;
        }

        return retObj;
    }

    public GameObject CreatePlatform(Vector2 position, int width)
    {
        GameObject platform = Instantiate(m_PlatformPrefab);
        platform.transform.localPosition = position;
        platform.GetComponent<Platform>().Width = 100 * width;
        platform.transform.SetParent(GameObject.Find("Canvas").transform);

        return platform;
    }

    public GameObject CreateGround(Vector2 position, int width)
    {
        GameObject ground = Instantiate(m_GroundPrefab);
        ground.transform.localPosition = position;
        ground.GetComponent<Ground>().Width = width;
        ground.transform.SetParent(GameObject.Find("Canvas").transform);

        return ground;
    }

    public GameObject CreateNiddle(Vector2 position, int count, bool isFlip)
    {
        GameObject niddle = Instantiate(m_NiddlePrefab);
        niddle.transform.localPosition = position;
        var n = niddle.GetComponent<Niddle>();
        n.Count = count;
        n.IsFlip = isFlip;
        niddle.transform.SetParent(GameObject.Find("Canvas").transform);

        return niddle;
    }

    public GameObject CreateFever(Vector2 position)
    {
        GameObject fever = Instantiate(m_FeverPrefab);
        fever.transform.localPosition = position;
        fever.transform.SetParent(GameObject.Find("Canvas").transform);

        return fever;
    }

    public GameObject CreateDoubleJump(Vector2 position)
    {
        GameObject jump = Instantiate(m_DoubleJumpPrefab);
        jump.transform.localPosition = position;
        jump.transform.SetParent(GameObject.Find("Canvas").transform);

        return jump;
    }

    public GameObject CreateSpring(Vector2 Position, int length, bool isUpStart, int scaleCount, Vector2 deltapos)
    {
        GameObject springobj = Instantiate(m_SpringPrefab);
        springobj.transform.localPosition = Position;
        Spring spring = springobj.GetComponent<Spring>();
        spring.DeltaPos = deltapos;
        spring.ScaleCount = scaleCount;
        spring.IsUpStart = isUpStart;
        spring.Length = length;

        return springobj;
    }
}
