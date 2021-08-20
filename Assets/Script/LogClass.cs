using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LogClass : MonoBehaviour
{
    [SerializeField] LogText m_log;
    [SerializeField] Button m_selectButton;
    [SerializeField] Button m_logButton;
    GameObject m_textSpase;

    List<GameObject> m_logList = new List<GameObject>(); 

    void Start()
    {
        m_log.GetLogClass(this);
        m_textSpase = GameObject.Find("TextSpase");
        m_log.GetParent(m_textSpase.transform);
        gameObject.SetActive(false);
    }

    public void AddList(GameObject set)
    {
        m_logList.Add(set);
        if (m_logList.Count > 10)
        {
            //RemoveList();
        }
    }

    void RemoveList()
    {
        m_logList.Remove(m_logList.First());
        Destroy(m_textSpase.transform.GetChild(0));
    }

    public void OnClickToLog() 
    {
        m_selectButton.enabled = false;
        m_logButton.enabled = false;
        gameObject.SetActive(true); 
    }
    public void OnClickToBack()
    {
        m_selectButton.enabled = true;
        m_logButton.enabled = true;
        gameObject.SetActive(false);
    }
}
