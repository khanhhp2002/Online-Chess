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
            for (int count = 1, fail = 0; count < 8 && fail < 8; count++, fail = 0)
            {
                // chéo trên bên phải  
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + count, position.y + count)))
                {
                    GridManager.boardTiles[new Vector2(position.x + count, position.y + count)].HighLight(color);
                }
                else
                {
                    fail++;
                }
                // chéo xuống bên trái
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - count, position.y - count)))
                {
                    GridManager.boardTiles[new Vector2(position.x - count, position.y - count)].HighLight(color);
                }
                else
                {
                    fail++;
                }
                // chéo trên bên trái  
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - count, position.y + count)))
                {
                    GridManager.boardTiles[new Vector2(position.x - count, position.y + count)].HighLight(color);
                }
                else
                {
                    fail++;
                }
                // chéo xuống bên phải
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + count, position.y - count)))
                {
                    GridManager.boardTiles[new Vector2(position.x + count, position.y - count)].HighLight(color);
                }
                else
                {
                    fail++;
                }
                // trái
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - count, position.y)))
                {
                    GridManager.boardTiles[new Vector2(position.x - count, position.y)].HighLight(color);
                }
                else
                {
                    fail++;
                }
                // phải 
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + count, position.y)))
                {
                    GridManager.boardTiles[new Vector2(position.x + count, position.y)].HighLight(color);
                }
                else
                {
                    fail++;
                }
                // trên
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x, position.y + count)))
                {
                    GridManager.boardTiles[new Vector2(position.x, position.y + count)].HighLight(color);
                }
                else
                {
                    fail++;
                }
                // xuống 
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x, position.y - count)))
                {
                    GridManager.boardTiles[new Vector2(position.x, position.y - count)].HighLight(color);
                }
                else
                {
                    fail++;
                }
            }
        }
        else if (type == ChessPieces.Rook)
        {
            for (int count = 1, fail = 0; count < 8 && fail < 4; count++, fail = 0)
            {
                // trái
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - count, position.y)))
                {
                    GridManager.boardTiles[new Vector2(position.x - count, position.y)].HighLight(color);
                }
                else
                {
                    fail++;
                }
                // phải 
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + count, position.y)))
                {
                    GridManager.boardTiles[new Vector2(position.x + count, position.y)].HighLight(color);
                }
                else
                {
                    fail++;
                }
                // trên
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x, position.y + count)))
                {
                    GridManager.boardTiles[new Vector2(position.x, position.y + count)].HighLight(color);
                }
                else
                {
                    fail++;
                }
                // xuống 
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x, position.y - count)))
                {
                    GridManager.boardTiles[new Vector2(position.x, position.y - count)].HighLight(color);
                }
                else
                {
                    fail++;
                }
            }
        }
        else if (type == ChessPieces.Bishop)
        {
            for (int count = 1, fail = 0; count < 8 && fail < 4; count++, fail = 0)
            {
                // chéo trên bên phải  
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + count, position.y + count)))
                {
                    GridManager.boardTiles[new Vector2(position.x + count, position.y + count)].HighLight(color);
                }
                else
                {
                    fail++;
                }
                // chéo xuống bên trái
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - count, position.y - count)))
                {
                    GridManager.boardTiles[new Vector2(position.x - count, position.y - count)].HighLight(color);
                }
                else
                {
                    fail++;
                }
                // chéo trên bên trái  
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - count, position.y + count)))
                {
                    GridManager.boardTiles[new Vector2(position.x - count, position.y + count)].HighLight(color);
                }
                else
                {
                    fail++;
                }
                // chéo xuống bên phải
                if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + count, position.y - count)))
                {
                    GridManager.boardTiles[new Vector2(position.x + count, position.y - count)].HighLight(color);
                }
                else
                {
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

