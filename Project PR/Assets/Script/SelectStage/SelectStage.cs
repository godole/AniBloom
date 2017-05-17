using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SelectStage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangePlayScene()
    {
        SceneManager.LoadScene("Test");
    }
}
