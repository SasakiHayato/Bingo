using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BingoManager : MonoBehaviour
{
    const int m_wide = 5;
    const int m_height = 5;
    [SerializeField] GameObject m_cell;

    CellClass[,] m_cells = new CellClass[m_wide, m_height];

    List<int> m_setNum = new List<int>();
    List<int> m_alreadyNum = new List<int>();

    int m_moveY = 0;

    void Start()
    {
        for (int count = 1; count <= 75; count++)
        {
            m_alreadyNum.Add(count);
        }
        
        CreateCell();
    }

    void CreateCell()
    {
        for (int x = 0; x < m_wide; x++)
        {
            for (int y = 0; y < m_height; y++)
            {
                GameObject cell = Instantiate(m_cell, transform);
                cell.name = $"cell :{x} :{y}";
                m_cells[x, y] = FindObjectOfType<CellClass>();
                if (x == 2 && y == 2)
                {
                    cell.GetComponent<CellClass>().SetText("B");
                    m_cells[x, y].SetStatus(CellStatus.Open);
                }
                else
                {
                    cell.GetComponent<CellClass>().SetText(SetNum(y).ToString());
                    m_cells[x, y].SetStatus(CellStatus.Close);
                }
            }
        }
    }

    int SetNum(int y)
    {
        int num = 0;
        switch (y)
        {
            case 0:
                num = Random.Range(1, 16);
                break;
            case 1:
                num = Random.Range(15, 31);
                break;
            case 2:
                num = Random.Range(30, 46);
                break;
            case 3:
                num = Random.Range(45, 61);
                break;
            case 4:
                num = Random.Range(60, 76);
                break;
        }
        int set = CheckNum(num, y);
        return set;
    }
    int CheckNum(int num, int select)
    {
        if (m_setNum.Count == 0)
        {
            m_setNum.Add(num);
            return num;
        }
        else
        {
            foreach (int checkNum in m_setNum)
            {
                if (checkNum == num)
                {
                    int set = SetNum(select);
                    return num = set;
                }
            }
            m_setNum.Add(num);
        }
        return num;
    }

    public void OnClick()
    {
        Debug.Log("押した");
        if (m_alreadyNum.Count == 0)
        {
            Debug.Log("全部出た");
            return;
        }
        SelectNum();
    }
    void SelectNum()
    {
        int num = Random.Range(0, 76);
        SetOpen(num);
    }
    
    void SetOpen(int num)
    {
        foreach (int set in m_alreadyNum)
        {
            if (num == set)
            {
                FindNum(num);
                m_alreadyNum.Remove(num);
                return;
            }

            
        }
        
        SelectNum();
        m_alreadyNum.Remove(num);
    }

    void FindNum(int targetNum)
    {
        for (int x = 0; x < m_wide; x++)
        {
            for (int y = 0; y < m_height; y++)
            {
                if (m_cells[x, y].RetuneStatus() == CellStatus.Open) continue;

                if (m_cells[x, y].RetuneNum() == targetNum)
                {
                    m_cells[x, y].SetStatus(CellStatus.Open);
                    CheckBingo();
                    return;
                }
            }
        }
        Debug.Log("no");
    }

    void CheckBingo()
    {
        Debug.Log("Check");
        CheckVertical();
    }

    void CheckVertical()
    {
        int count = 0;
        for (int x = 0; x < m_wide; x++)
        {
            if (m_cells[x, m_moveY].RetuneStatus() == CellStatus.Open)
            {
                count++;
                IsBingo(count);
            }
        }

        if (m_moveY != 5)
        {
            CheckVertical();
        }
    }

    void IsBingo(int count)
    {
        if (count == 5)
        {
            Debug.Log("BINGO");
        }
    }
}
