using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CellStatus
{
    Open,
    Close,
}

public class CellClass : MonoBehaviour
{
    [SerializeField] Text m_numText;
    CellStatus m_status;

    public void SetText(string set) { m_numText.text = $"{set}"; }
    public void SetStatus(CellStatus status)
    { 
        m_status = status;
        ChengeColor();
    }
    void ChengeColor()
    {
        Image imageColer = GetComponent<Image>();
        if (m_status == CellStatus.Close) { imageColer.color = Color.red; }
        else if (m_status == CellStatus.Open) { imageColer.color = Color.green; }
    }

    public CellStatus RetuneStatus() { return m_status; }

    public int RetuneNum()
    {
        int num = int.Parse(m_numText.text);
        return num;
    }
}
