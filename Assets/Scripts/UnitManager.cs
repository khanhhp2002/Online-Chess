using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : Singleton<UnitManager>
{
    public ChessPiece _pawnPrefab;
    public Tile selectedTile;
    public List<Tile> Selected = new List<Tile>();

    public void HighLight(ChessPieces type, Team color, Vector2 position)
    {
        if (type == ChessPieces.Pawn)
        {
            int status;
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x, position.y + 1)))
            {
                GridManager.boardTiles[new Vector2(position.x, position.y + 1)].HighLight(color);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x, position.y + 2)))
            {
                GridManager.boardTiles[new Vector2(position.x, position.y + 2)].HighLight(color);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + 1, position.y + 1)))
            {
                GridManager.boardTiles[new Vector2(position.x + 1, position.y + 1)].HighLight(color);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - 1, position.y + 1)))
            {
                GridManager.boardTiles[new Vector2(position.x - 1, position.y + 1)].HighLight(color);
            }
        }
        else if (type == ChessPieces.Knight)
        {
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + 2, position.y + 1)))
            {
                GridManager.boardTiles[new Vector2(position.x + 2, position.y + 1)].HighLight(color);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + 2, position.y - 1)))
            {
                GridManager.boardTiles[new Vector2(position.x + 2, position.y - 1)].HighLight(color);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - 2, position.y + 1)))
            {
                GridManager.boardTiles[new Vector2(position.x - 2, position.y + 1)].HighLight(color);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - 2, position.y - 1)))
            {
                GridManager.boardTiles[new Vector2(position.x - 2, position.y - 1)].HighLight(color);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + 1, position.y + 2)))
            {
                GridManager.boardTiles[new Vector2(position.x + 1, position.y + 2)].HighLight(color);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + 1, position.y - 2)))
            {
                GridManager.boardTiles[new Vector2(position.x + 1, position.y - 2)].HighLight(color);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - 1, position.y + 2)))
            {
                GridManager.boardTiles[new Vector2(position.x - 1, position.y + 2)].HighLight(color);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - 1, position.y - 2)))
            {
                GridManager.boardTiles[new Vector2(position.x - 1, position.y - 2)].HighLight(color);
            }
        }
        else if (type == ChessPieces.King)
        {
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x, position.y + 1)))
            {
                GridManager.boardTiles[new Vector2(position.x, position.y + 1)].HighLight(color);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x, position.y - 1)))
            {
                GridManager.boardTiles[new Vector2(position.x, position.y - 1)].HighLight(color);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + 1, position.y)))
            {
                GridManager.boardTiles[new Vector2(position.x + 1, position.y)].HighLight(color);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - 1, position.y)))
            {
                GridManager.boardTiles[new Vector2(position.x - 1, position.y)].HighLight(color);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + 1, position.y + 1)))
            {
                GridManager.boardTiles[new Vector2(position.x + 1, position.y + 1)].HighLight(color);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + 1, position.y - 1)))
            {
                GridManager.boardTiles[new Vector2(position.x + 1, position.y - 1)].HighLight(color);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - 1, position.y + 1)))
            {
                GridManager.boardTiles[new Vector2(position.x - 1, position.y + 1)].HighLight(color);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - 1, position.y - 1)))
            {
                GridManager.boardTiles[new Vector2(position.x - 1, position.y - 1)].HighLight(color);
            }
        }
        else if (type == ChessPieces.Queen)
        {
            bool frontWall = false, backWall = false, leftWall = false, rightWall = false, frontLeftWall = false, backLeftWall = false, frontRightWall = false, backRightWall = false;
            for (int count = 1, fail = 0, status = 0; count < 8 && fail < 8; count++, fail = 0)
            {
                // trên
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x, position.y + count)) && !frontWall)
                {
                    status = GridManager.boardTiles[new Vector2(position.x, position.y + count)].IsWall(color);
                    if (status == 1)
                    {
                        frontWall = true;
                        GridManager.boardTiles[new Vector2(position.x, position.y + count)].HighLight(color);
                    }
                    else if (status == 2)
                    {
                        frontWall = true;
                    }
                    else
                        GridManager.boardTiles[new Vector2(position.x, position.y + count)].HighLight(color);
                }
                else
                {
                    frontWall = true;
                    fail++;
                }
                // xuống
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x, position.y - count)) && !backWall)
                {
                    status = GridManager.boardTiles[new Vector2(position.x, position.y - count)].IsWall(color);
                    if (status == 1)
                    {
                        backWall = true;
                        GridManager.boardTiles[new Vector2(position.x, position.y - count)].HighLight(color);
                    }
                    else if (status == 2)
                    {
                        backWall = true;
                    }
                    else
                        GridManager.boardTiles[new Vector2(position.x, position.y - count)].HighLight(color);
                }
                else
                {
                    backWall = true;
                    fail++;
                }
                // bên trái  
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - count, position.y)) && !leftWall)
                {
                    status = GridManager.boardTiles[new Vector2(position.x - count, position.y)].IsWall(color);
                    if (status == 1)
                    {
                        leftWall = true;
                        GridManager.boardTiles[new Vector2(position.x - count, position.y)].HighLight(color);
                    }
                    else if (status == 2)
                    {
                        leftWall = true;
                    }
                    else
                        GridManager.boardTiles[new Vector2(position.x - count, position.y)].HighLight(color);
                }
                else
                {
                    leftWall = true;
                    fail++;
                }
                // bên phải
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + count, position.y)) && !rightWall)
                {
                    status = GridManager.boardTiles[new Vector2(position.x + count, position.y)].IsWall(color);
                    if (status == 1)
                    {
                        rightWall = true;
                        GridManager.boardTiles[new Vector2(position.x + count, position.y)].HighLight(color);
                    }
                    else if (status == 2)
                    {
                        rightWall = true;
                    }
                    else
                        GridManager.boardTiles[new Vector2(position.x + count, position.y)].HighLight(color);
                }
                else
                {
                    rightWall = true;
                    fail++;
                }
                // chéo trên bên phải  
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + count, position.y + count)) && !frontRightWall)
                {
                    status = GridManager.boardTiles[new Vector2(position.x + count, position.y + count)].IsWall(color);
                    if (status == 1)
                    {
                        frontRightWall = true;
                        GridManager.boardTiles[new Vector2(position.x + count, position.y + count)].HighLight(color);
                    }
                    else if (status == 2)
                    {
                        frontRightWall = true;
                    }
                    else
                        GridManager.boardTiles[new Vector2(position.x + count, position.y + count)].HighLight(color);

                }
                else
                {
                    frontRightWall = true;
                    fail++;
                }
                // chéo xuống bên trái
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - count, position.y - count)) && !backLeftWall)
                {
                    status = GridManager.boardTiles[new Vector2(position.x - count, position.y - count)].IsWall(color);
                    if (status == 1)
                    {
                        backLeftWall = true;
                        GridManager.boardTiles[new Vector2(position.x - count, position.y - count)].HighLight(color);
                    }
                    else if (status == 2)
                    {
                        backLeftWall = true;
                    }
                    else
                        GridManager.boardTiles[new Vector2(position.x - count, position.y - count)].HighLight(color);
                }
                else
                {
                    backLeftWall = true;
                    fail++;
                }
                // chéo trên bên trái  
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - count, position.y + count)) && !frontLeftWall)
                {
                    status = GridManager.boardTiles[new Vector2(position.x - count, position.y + count)].IsWall(color);
                    if (status == 1)
                    {
                        frontLeftWall = true;
                        GridManager.boardTiles[new Vector2(position.x - count, position.y + count)].HighLight(color);
                    }
                    else if (status == 2)
                    {
                        frontLeftWall = true;
                    }
                    else
                        GridManager.boardTiles[new Vector2(position.x - count, position.y + count)].HighLight(color);
                }
                else
                {
                    frontLeftWall = true;
                    fail++;
                }
                // chéo xuống bên phải
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + count, position.y - count)) && !backRightWall)
                {
                    status = GridManager.boardTiles[new Vector2(position.x + count, position.y - count)].IsWall(color);
                    if (status == 1)
                    {
                        backRightWall = true;
                        GridManager.boardTiles[new Vector2(position.x + count, position.y - count)].HighLight(color);
                    }
                    else if (status == 2)
                    {
                        backRightWall = true;
                    }
                    else
                        GridManager.boardTiles[new Vector2(position.x + count, position.y - count)].HighLight(color);
                }
                else
                {
                    backRightWall = true;
                    fail++;
                }
            }
        }
        else if (type == ChessPieces.Rook)
        {
            bool frontWall = false, backWall = false, leftWall = false, rightWall = false;
            for (int count = 1, fail = 0, status = 0; count < 8 && fail < 4; count++, fail = 0)
            {
                // trên
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x, position.y + count)) && !frontWall)
                {
                    status = GridManager.boardTiles[new Vector2(position.x, position.y + count)].IsWall(color);
                    if (status == 1)
                    {
                        frontWall = true;
                        GridManager.boardTiles[new Vector2(position.x, position.y + count)].HighLight(color);
                    }
                    else if (status == 2)
                    {
                        frontWall = true;
                    }
                    else
                        GridManager.boardTiles[new Vector2(position.x, position.y + count)].HighLight(color);

                }
                else
                {
                    frontWall = true;
                    fail++;
                }
                // xuống
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x, position.y - count)) && !backWall)
                {
                    status = GridManager.boardTiles[new Vector2(position.x, position.y - count)].IsWall(color);
                    if (status == 1)
                    {
                        backWall = true;
                        GridManager.boardTiles[new Vector2(position.x, position.y - count)].HighLight(color);
                    }
                    else if (status == 2)
                    {
                        backWall = true;
                    }
                    else
                        GridManager.boardTiles[new Vector2(position.x, position.y - count)].HighLight(color);
                }
                else
                {
                    backWall = true;
                    fail++;
                }
                // bên trái  
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - count, position.y)) && !leftWall)
                {
                    status = GridManager.boardTiles[new Vector2(position.x - count, position.y)].IsWall(color);
                    if (status == 1)
                    {
                        leftWall = true;
                        GridManager.boardTiles[new Vector2(position.x - count, position.y)].HighLight(color);
                    }
                    else if (status == 2)
                    {
                        leftWall = true;
                    }
                    else
                        GridManager.boardTiles[new Vector2(position.x - count, position.y)].HighLight(color);
                }
                else
                {
                    leftWall = true;
                    fail++;
                }
                // bên phải
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + count, position.y)) && !rightWall)
                {
                    status = GridManager.boardTiles[new Vector2(position.x + count, position.y)].IsWall(color);
                    if (status == 1)
                    {
                        rightWall = true;
                        GridManager.boardTiles[new Vector2(position.x + count, position.y)].HighLight(color);
                    }
                    else if (status == 2)
                    {
                        rightWall = true;
                    }
                    else
                        GridManager.boardTiles[new Vector2(position.x + count, position.y)].HighLight(color);
                }
                else
                {
                    rightWall = true;
                    fail++;
                }
            }
        }
        else if (type == ChessPieces.Bishop)
        {
            bool frontLeftWall = false, backLeftWall = false, frontRightWall = false, backRightWall = false;
            for (int count = 1, fail = 0, status = 0; count < 8 && fail < 4; count++, fail = 0)
            {
                // chéo trên bên phải  
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + count, position.y + count)) && !frontRightWall)
                {
                    status = GridManager.boardTiles[new Vector2(position.x + count, position.y + count)].IsWall(color);
                    if (status == 1)
                    {
                        frontRightWall = true;
                        GridManager.boardTiles[new Vector2(position.x + count, position.y + count)].HighLight(color);
                    }
                    else if (status == 2)
                    {
                        frontRightWall = true;
                    }
                    else
                        GridManager.boardTiles[new Vector2(position.x + count, position.y + count)].HighLight(color);

                }
                else
                {
                    frontRightWall = true;
                    fail++;
                }
                // chéo xuống bên trái
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - count, position.y - count)) && !backLeftWall)
                {
                    status = GridManager.boardTiles[new Vector2(position.x - count, position.y - count)].IsWall(color);
                    if (status == 1)
                    {
                        backLeftWall = true;
                        GridManager.boardTiles[new Vector2(position.x - count, position.y - count)].HighLight(color);
                    }
                    else if (status == 2)
                    {
                        backLeftWall = true;
                    }
                    else
                        GridManager.boardTiles[new Vector2(position.x - count, position.y - count)].HighLight(color);
                }
                else
                {
                    backLeftWall = true;
                    fail++;
                }
                // chéo trên bên trái  
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - count, position.y + count)) && !frontLeftWall)
                {
                    status = GridManager.boardTiles[new Vector2(position.x - count, position.y + count)].IsWall(color);
                    if (status == 1)
                    {
                        frontLeftWall = true;
                        GridManager.boardTiles[new Vector2(position.x - count, position.y + count)].HighLight(color);
                    }
                    else if (status == 2)
                    {
                        frontLeftWall = true;
                    }
                    else
                        GridManager.boardTiles[new Vector2(position.x - count, position.y + count)].HighLight(color);
                }
                else
                {
                    frontLeftWall = true;
                    fail++;
                }
                // chéo xuống bên phải
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + count, position.y - count)) && !backRightWall)
                {
                    status = GridManager.boardTiles[new Vector2(position.x + count, position.y - count)].IsWall(color);
                    if (status == 1)
                    {
                        backRightWall = true;
                        GridManager.boardTiles[new Vector2(position.x + count, position.y - count)].HighLight(color);
                    }
                    else if (status == 2)
                    {
                        backRightWall = true;
                    }
                    else
                        GridManager.boardTiles[new Vector2(position.x + count, position.y - count)].HighLight(color);
                }
                else
                {
                    backRightWall = true;
                    fail++;
                }
            }
        }
    }


    public void UnHighLight()
    {
        foreach (var tile in Selected)
        {
            tile.UnHighLight();
        }
        Selected.Clear();
    }
}

