using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoadingMap : MonoBehaviour {
    [SerializeField]
    GameObject _Background;
    [SerializeField]
    private int _BPM;
    [SerializeField]
    private float JumpPower;
    // Use this for initialization
    void Awake () {
        Time.timeScale = 1.0f;

        ChangeValue();


        /*MapData data = LoadFromMapData("stage1");

        float t = 60.0f / data.BPM / 2;
        float dy = 280;
        float a = 2 * dy / Mathf.Pow(t, 2);
        float movespeed = Mathf.Pow((data.BPM / 60.0f), 2.0f) * 150;

        PlayerControl pc = GameObject.Find("Player").GetComponent<PlayerControl>();
        pc.GravityScale = a;
        pc.JumpForce = -(dy - (a * t * 0.5f)) / t;
        pc.setMoveSpeed(movespeed);

        float movedelta = 60.0f / data.BPM * movespeed;
        GameObject.Find("Logic").GetComponent<MainLogic>()._DeltaPos = new Vector2(movedelta, 275);
        
        ObstacleManager obsManager = GameObject.Find("Obstacle Manager").GetComponent<ObstacleManager>();

        foreach (var d in data.NormalObjectList)
            obsManager.AddObjectData(d.ToObjectData());

        foreach (var d in data.GroundObjectList)
            obsManager.AddObjectData(d.ToObjectData());

        foreach (var d in data.NiddleObjectList)
            obsManager.AddObjectData(d.ToObjectData());

        foreach (var d in data.RopeObjectList)
            obsManager.AddObjectData(d.ToObjectData());

        foreach (var d in data.SpringObjectList)
            obsManager.AddObjectData(d.ToObjectData());

        foreach (var d in data.PlatformObjectList)
            obsManager.AddObjectData(d.ToObjectData());

        obsManager.Sort();

        obsManager.StartUp();

        CutsceneManager cutsceneManager = GameObject.Find("CutsceneManager").GetComponent<CutsceneManager>();
        cutsceneManager._CutsceneData = data._CutsceneData;*/
    }

    public void OnValidate()
    {
        ChangeValue();
    }

    void ChangeValue()
    {
        PlayerControl pc = GameObject.Find("Player").GetComponent<PlayerControl>();

        float t = 60.0f / _BPM / 2;
        float a = 2 * JumpPower / Mathf.Pow(t, 2);
        float movespeed = Mathf.Pow((_BPM / 60.0f), 2.0f) * 200;

        pc.GravityScale = a;
        pc.JumpForce = -(JumpPower - (a * t * 0.5f)) / t;
        pc.setMoveSpeed(movespeed);
    }

    MapData LoadFromMapData(string name)
    {
        TextAsset text = (TextAsset)Resources.Load("Map/" + name + "/data", typeof(TextAsset));

        string saveData = text.text;

        return JsonUtility.FromJson<MapData>(saveData);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
