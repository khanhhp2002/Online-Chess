using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : Singleton<UnitManager>
{
    public bool IsMove = false;
    public ChessPiece _pawnPrefab;
    public Tile selectedTile;
    public List<Tile> Selected = new List<Tile>();

    public void HighLight(ChessPieces type, Team color, Vector2 position)
    {
        if (type == ChessPieces.Pawn)
        {
            bool status = true;
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x, position.y + 1)))
            {
                status = GridManager.boardTiles[new Vector2(position.x, position.y + 1)].IsWall(color,false);
            }
            if (!selectedTile.GetChessPieces().IsMove && !status && GridManager.boardTiles.ContainsKey(new Vector2(position.x, position.y + 2)))
            {
                GridManager.boardTiles[new Vector2(position.x, position.y + 2)].IsWall(color, false);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + 1, position.y + 1)))
            {
                GridManager.boardTiles[new Vector2(position.x + 1, position.y + 1)].IsWall(color, true);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - 1, position.y + 1)))
            {
                GridManager.boardTiles[new Vector2(position.x - 1, position.y + 1)].IsWall(color, true);
            }
        }
        else if (type == ChessPieces.Knight)
        {
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + 2, position.y + 1)))
            {
                GridManager.boardTiles[new Vector2(position.x + 2, position.y + 1)].IsWall(color);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + 2, position.y - 1)))
            {
                GridManager.boardTiles[new Vector2(position.x + 2, position.y - 1)].IsWall(color);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - 2, position.y + 1)))
            {
                GridManager.boardTiles[new Vector2(position.x - 2, position.y + 1)].IsWall(color);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - 2, position.y - 1)))
            {
                GridManager.boardTiles[new Vector2(position.x - 2, position.y - 1)].IsWall(color);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + 1, position.y + 2)))
            {
                GridManager.boardTiles[new Vector2(position.x + 1, position.y + 2)].IsWall(color);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + 1, position.y - 2)))
            {
                GridManager.boardTiles[new Vector2(position.x + 1, position.y - 2)].IsWall(color);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - 1, position.y + 2)))
            {
                GridManager.boardTiles[new Vector2(position.x - 1, position.y + 2)].IsWall(color);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - 1, position.y - 2)))
            {
                GridManager.boardTiles[new Vector2(position.x - 1, position.y - 2)].IsWall(color);
            }
        }
        else if (type == ChessPieces.King)
        {
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x, position.y + 1)))
            {
                GridManager.boardTiles[new Vector2(position.x, position.y + 1)].IsWall(color);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x, position.y - 1)))
            {
                GridManager.boardTiles[new Vector2(position.x, position.y - 1)].IsWall(color);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + 1, position.y)))
            {
                GridManager.boardTiles[new Vector2(position.x + 1, position.y)].IsWall(color);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - 1, position.y)))
            {
                GridManager.boardTiles[new Vector2(position.x - 1, position.y)].IsWall(color);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + 1, position.y + 1)))
            {
                GridManager.boardTiles[new Vector2(position.x + 1, position.y + 1)].IsWall(color);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + 1, position.y - 1)))
            {
                GridManager.boardTiles[new Vector2(position.x + 1, position.y - 1)].IsWall(color);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - 1, position.y + 1)))
            {
                GridManager.boardTiles[new Vector2(position.x - 1, position.y + 1)].IsWall(color);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - 1, position.y - 1)))
            {
                GridManager.boardTiles[new Vector2(position.x - 1, position.y - 1)].IsWall(color);
            }
        }
        else if (type == ChessPieces.Queen)
        {
            bool frontWall = false, backWall = false, leftWall = false, rightWall = false, frontLeftWall = false, backLeftWall = false, frontRightWall = false, backRightWall = false;
            for (int count = 1, fail = 0; count < 8 && fail < 8; count++, fail = 0)
            {
                // trên
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x, position.y + count)) && !frontWall)
                    frontWall = GridManager.boardTiles[new Vector2(position.x, position.y + count)].IsWall(color);
                else
                {
                    frontWall = true;
                    fail++;
                }
                // xuống
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x, position.y - count)) && !backWall)
                    backWall = GridManager.boardTiles[new Vector2(position.x, position.y - count)].IsWall(color);
                else
                {
                    backWall = true;
                    fail++;
                }
                // bên trái  
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - count, position.y)) && !leftWall)
                    leftWall = GridManager.boardTiles[new Vector2(position.x - count, position.y)].IsWall(color);
                else
                {
                    leftWall = true;
                    fail++;
                }
                // bên phải
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + count, position.y)) && !rightWall)
                    rightWall = GridManager.boardTiles[new Vector2(position.x + count, position.y)].IsWall(color);
                else
                {
                    rightWall = true;
                    fail++;
                }
                // chéo trên bên phải  
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + count, position.y + count)) && !frontRightWall)
                    frontRightWall = GridManager.boardTiles[new Vector2(position.x + count, position.y + count)].IsWall(color);
                else
                {
                    frontRightWall = true;
                    fail++;
                }
                // chéo xuống bên trái
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - count, position.y - count)) && !backLeftWall)
                    backLeftWall = GridManager.boardTiles[new Vector2(position.x - count, position.y - count)].IsWall(color);
                else
                {
                    backLeftWall = true;
                    fail++;
                }
                // chéo trên bên trái  
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - count, position.y + count)) && !frontLeftWall)
                    frontLeftWall = GridManager.boardTiles[new Vector2(position.x - count, position.y + count)].IsWall(color);
                else
                {
                    frontLeftWall = true;
                    fail++;
                }
                // chéo xuống bên phải
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + count, position.y - count)) && !backRightWall)
                   backRightWall = GridManager.boardTiles[new Vector2(position.x + count, position.y - count)].IsWall(color);
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
            for (int count = 1, fail = 0; count < 8 && fail < 4; count++, fail = 0)
            {
                // trên
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x, position.y + count)) && !frontWall)
                    frontWall = GridManager.boardTiles[new Vector2(position.x, position.y + count)].IsWall(color);
                else
                {
                    frontWall = true;
                    fail++;
                }
                // xuống
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x, position.y - count)) && !backWall)
                    backWall = GridManager.boardTiles[new Vector2(position.x, position.y - count)].IsWall(color);
                else
                {
                    backWall = true;
                    fail++;
                }
                // bên trái  
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - count, position.y)) && !leftWall)
                    leftWall = GridManager.boardTiles[new Vector2(position.x - count, position.y)].IsWall(color);
                else
                {
                    leftWall = true;
                    fail++;
                }
                // bên phải
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + count, position.y)) && !rightWall)
                    rightWall = GridManager.boardTiles[new Vector2(position.x + count, position.y)].IsWall(color);
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
            for (int count = 1, fail = 0; count < 8 && fail < 4; count++, fail = 0)
            {
                // chéo trên bên phải  
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + count, position.y + count)) && !frontRightWall)
                    frontRightWall = GridManager.boardTiles[new Vector2(position.x + count, position.y + count)].IsWall(color);
                else
                {
                    frontRightWall = true;
                    fail++;
                }
                // chéo xuống bên trái
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - count, position.y - count)) && !backLeftWall)
                    backLeftWall = GridManager.boardTiles[new Vector2(position.x - count, position.y - count)].IsWall(color);
                else
                {
                    backLeftWall = true;
                    fail++;
                }
                // chéo trên bên trái  
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - count, position.y + count)) && !frontLeftWall)
                    frontLeftWall = GridManager.boardTiles[new Vector2(position.x - count, position.y + count)].IsWall(color);
                else
                {
                    frontLeftWall = true;
                    fail++;
                }
                // chéo xuống bên phải
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + count, position.y - count)) && !backRightWall)
                    backRightWall = GridManager.boardTiles[new Vector2(position.x + count, position.y - count)].IsWall(color);
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

