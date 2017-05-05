using UnityEngine;
using System.Collections;

public class JumpCheck : MonoBehaviour {

    public static int m_ColliderCount = 0;
    [SerializeField]
    UILabel _JumpCount;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if(_JumpCount != null)
            _JumpCount.text = m_ColliderCount.ToString();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        var pc = GameObject.Find("Player").GetComponent<PlayerControl>();
        
        switch (other.gameObject.tag)
        {
            case "Ground":
                m_ColliderCount++;
                pc.JumpCount = 1;
                pc.GroundCollision(other);
                break;

            case "Slide":
                m_ColliderCount++;
                pc.JumpCount = 1;
                pc.SlideCollision(other);
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        /*switch (other.gameObject.tag)
        {
            case "Ground":
                var pc = GameObject.Find("Player").GetComponent<PlayerControl>();
                m_ColliderCount++;
                pc.JumpCount = 1;
                pc.GroundCollision(other);
                break;
        }*/
    }

    void OnTriggerExit2D(Collider2D other)
    {
        var pc = GameObject.Find("Player").GetComponent<PlayerControl>();
        switch (other.gameObject.tag)
        {
            case "Ground":
                m_ColliderCount--;
                if (m_ColliderCount <= 0)
                {
                    pc.JumpCount = 0;
                    pc.GroundCollisionExit(other);
                }
                break;

            case "Slide":
                m_ColliderCount--;
                if(m_ColliderCount <= 0)
                {
                    pc.JumpCount = 0;
                    pc.SlideCollisionExit(other);
                }
                break;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        /*switch (other.gameObject.tag)
        {
            case "Ground":
                var pc = GameObject.Find("Player").GetComponent<PlayerControl>();
                m_ColliderCount--;
                if (m_ColliderCount <= 0)
                {
                    pc.JumpCount = 0;
                    pc.GroundCollisionExit(other);
                }
                break;
        }*/
    }
}
