using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BingoManager : MonoBehaviour
{
    [SerializeField] private GameObject bingoPrefab;
    [SerializeField] private GridLayoutGroup m_group;

    const int row = 5;
    const int column = 5;

    private Cell[,] cells = new Cell[row, column];

    void Start()
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                CreateCell(i, j, cells);
            }
        }
    }

    private void CreateCell(int x, int y, object[,] cells)
    {
        var cell = Instantiate(bingoPrefab);
        var parent = m_group.gameObject.transform;
        cell.transform.SetParent(parent);

        cells[x, y] = cell;
    }
}
