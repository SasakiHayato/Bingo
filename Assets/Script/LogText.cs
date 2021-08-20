using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogText : MonoBehaviour
{
    [SerializeField] Text m_logText;
    Transform m_parent;
    LogClass m_logClass;

    public void SetLogText(int num)
    {
        m_logText.text = $"Number :{num}がでました";
        m_logClass.AddList(gameObject);
        SetLog();
    }

    public void GetParent(Transform set) { m_parent = set; }
    public void GetLogClass(LogClass set) { m_logClass = set; }

    void SetLog() { Instantiate(gameObject, m_parent); }
}
