using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LopeManager {

    private static LopeManager instance;

    public static LopeManager getInstance()
    {
        if (instance == null)
            instance = new LopeManager();

        return instance;
    }

    private LopeManager()
    {

    }

    private List<Rope> m_Lopes = new List<Rope>();

    public void AddLope(Rope lope)
    {
        m_Lopes.Add(lope);
    }

    public List<Rope> getLopeList()
    {
        return m_Lopes;
    }

    public void Clear()
    {
        m_Lopes.Clear();
    }
}
