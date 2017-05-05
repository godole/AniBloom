using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
    private List<string> m_lItemNames = new List<string>();

    private List<string> m_ItemNames = new List<string>();

    private List<UISprite> m_Sprites = new List<UISprite>();

    public GameObject m_gObjSampleItem;

    public UIScrollView m_scrollView;

    public UITable m_grid;

	// Use this for initialization
	void Start () {
        m_lItemNames.Add("material1");
        m_lItemNames.Add("material2");
        m_lItemNames.Add("material3");
        m_lItemNames.Add("material4");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.I))
            AddItem();
	}

    private void AddItem()
    {
        int nRandomIndex = Random.Range(0, m_lItemNames.Count);

        GameObject gObjItem = NGUITools.AddChild(m_grid.gameObject, m_gObjSampleItem);

        UISprite itemScript = gObjItem.GetComponent<UISprite>();

        itemScript.spriteName = m_lItemNames[nRandomIndex];

        m_grid.Reposition();

        m_scrollView.ResetPosition();
    }
}
