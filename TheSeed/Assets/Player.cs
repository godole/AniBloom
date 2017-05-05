using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    MainLogic _MainLogic;
    GameObject _Cosmos;

    [SerializeField]
    float _PlayerSpeed;

    void Awake()
    {
        _MainLogic = GameObject.Find("Logic").GetComponent<MainLogic>();
        _Cosmos = GameObject.Find("Cosmos");
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 deltaPos = mousePos - (Vector2)gameObject.transform.position;
        deltaPos.Normalize();
        
        deltaPos = new Vector2(deltaPos.x * _PlayerSpeed, deltaPos.y * _PlayerSpeed);

        _Cosmos.transform.position -= (Vector3)deltaPos * Time.deltaTime;
        float angle = Mathf.Atan2(deltaPos.y, deltaPos.x);
        gameObject.transform.eulerAngles = new Vector3(0, 0, angle * Mathf.Rad2Deg - 90);
    }
}
