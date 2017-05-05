using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class MainLogic : MonoBehaviour {
    public GameObject _PlanetPrefab = null;

    public GameObject _Cosmos;

    public List<GameObject> _PlanetList = new List<GameObject>();

    
    public Vector2 _WorldSize;

    void Awake()
    {
        try
        {
            for(int i = 0; i < 10; i++)
            {
                var planet = Instantiate(_PlanetPrefab);
                planet.transform.SetParent(_Cosmos.transform);
                float scale = UnityEngine.Random.Range(200, 500);
                planet.transform.localScale = new Vector3(scale, scale, 100);
                planet.transform.position = new Vector3(UnityEngine.Random.Range(-_WorldSize.x / 2, _WorldSize.x / 2), 
                    UnityEngine.Random.Range(-_WorldSize.y / 2, _WorldSize.y / 2), -10);
                _PlanetList.Add(planet);
            }
        }
        catch(NullReferenceException e)
        {
            Debug.Log("Create Planet Error : " + e.Message);
        }
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
