using UnityEngine;
using System.Collections;

public class WordBubble : MenuPopup
{
    UILabel _Title;
    UILabel _Explane;
    [SerializeField]
    UILabel _ButtonText;

    public string Title { set { _Title.text = value; } }
    public string Explane { set { _Explane.text = value; } }
    public string ButtonText { set { _ButtonText.text = value; } }

    // Use this for initialization
    void Start () {
        _Title = gameObject.transform.FindChild("Title").gameObject.GetComponent<UILabel>();
        _Explane = gameObject.transform.FindChild("Explane").gameObject.GetComponent<UILabel>();
    }
}
