using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BingoManager : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup bingoField;
    [SerializeField] private GameObject bingoPrefab;

    private Cell[,] cell;
    int r = 5;
    int c = 5;
    private void Start()
    {
        cell = new Cell[r, c];
        for (int row = 0; row < r; row++)
        {
            for (int column = 0; column < c; column++)
            {
                CreateBingo(row, column, cell);
            }
        }
    }

    void CreateBingo(int x, int y, object[,] cell)
    {
        var bingo = Instantiate(bingoPrefab);
        var parent = bingoField.gameObject.transform;
        bingo.transform.SetParent(parent);

        cell[x, y] = bingo;
    }
}
