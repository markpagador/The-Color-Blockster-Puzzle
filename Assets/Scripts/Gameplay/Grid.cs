using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int columns = 0;
    public int rows = 0;
    public float squaresGap = 0.1f;
    public GameObject gridSquere;
    public Vector2 startPosition = new Vector2(x: 0.0f, 0.0f);
    public float squareScale = 0.5f;
    public float everySquareOffset = 0.0f;

    private Vector2 _offset = new Vector2(0.0f, 0.0f);
    private List<GameObject> _gridSqueres = new List<GameObject>();

    void Start()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        SpawnGridSquares();
        SetGridSquarePositions();
    }

    private void SpawnGridSquares()
    {
        //0, 1, 2, 3, 4,
        //5, 6, 7, 8, 9

        int square_index = 0;

        for (var row = 0; row < rows; ++row)
        {
            for(var column = 0; column < columns; ++column)
            {
                _gridSqueres.Add(Instantiate(gridSquere) as GameObject);
                _gridSqueres[_gridSqueres.Count - 1].transform.SetParent(this.transform);
                _gridSqueres[_gridSqueres.Count - 1].transform.localScale = new Vector3(x:squareScale, y:squareScale, z:squareScale);
                _gridSqueres[_gridSqueres.Count - 1].GetComponent<GridSquare>().setImage(square_index % 2 == 0);

            }
        }
    }

    private void SetGridSquarePositions()
    {
        int column_number = 0;  
        int row_number = 0;
        Vector2 square_gap_number = new Vector2(x: 0.0f, y:0.0f);
        bool row_moved = false;

        var square_rect = _gridSqueres[0].GetComponent<RectTransform>();

        _offset.x = square_rect.rect.width * square_rect.transform.localScale.x + everySquareOffset;
        _offset.y = square_rect.rect.height * square_rect.transform.localScale.y + everySquareOffset;

        foreach (GameObject Square in _gridSqueres)
        {
            if (column_number + 1 > columns)
            {
                square_gap_number.x = 0;
                //
                column_number = 0;
                row_number++;
                row_moved = false;
            }

            var pos_x_offset = _offset.x * column_number + (square_gap_number.x * squaresGap);
            var pos_y_offset = _offset.y * row_number + (square_gap_number.y * squaresGap);

            if (column_number > 0 && column_number % 3 == 0)
            {
                square_gap_number.x++;
                pos_x_offset += squaresGap;
            }

            if (row_number > 0 && row_number % 3 == 0 && row_moved == false)
            {
                row_moved = true;
                square_gap_number.y++;
                pos_y_offset += squaresGap;
            }

            Square.GetComponent<RectTransform>().anchoredPosition = new Vector2(x:startPosition.x + pos_x_offset, y:startPosition.y - pos_y_offset);

            Square.GetComponent<RectTransform>().localPosition = new Vector3(x: startPosition.x + pos_x_offset, y: startPosition.y - pos_y_offset, z:0.0f);

            column_number++;
        }

    }
    
}
