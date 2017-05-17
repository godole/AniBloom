using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SelectRegion : MonoBehaviour {
    List<string> _UnlockRegionList = new List<string>();
    [SerializeField]
    public List<Region> _RegionList = new List<Region>();

    public string SelectedRegion { get; set; }

    void Awake()
    {
        _UnlockRegionList.Add("keisan");

        foreach(var unlock in _UnlockRegionList)
        {
            foreach(var region in _RegionList)
            {
                if(unlock.Equals(region._StageName))
                    region.Unlock();
            }
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeSelectStageScene()
    {
        SceneManager.LoadScene("SelectStage");
    }
}

