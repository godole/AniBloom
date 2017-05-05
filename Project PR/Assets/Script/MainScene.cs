using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeSceneToGame()
    {
        SceneManager.LoadScene("InGame");
    }

    public void ChangeSceneToEdit()
    {
        SceneManager.LoadScene("Edit Mode");
    }
}
