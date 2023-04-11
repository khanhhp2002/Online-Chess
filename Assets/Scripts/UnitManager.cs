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
                Selected.Add(GridManager.boardTiles[new Vector2(position.x, position.y + 1)]);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x, position.y + 2)))
            {
                GridManager.boardTiles[new Vector2(position.x, position.y + 2)].HighLight(color);
                Selected.Add(GridManager.boardTiles[new Vector2(position.x, position.y + 2)]);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + 1, position.y + 1)))
            {
                GridManager.boardTiles[new Vector2(position.x + 1, position.y + 1)].HighLight(color);
                Selected.Add(GridManager.boardTiles[new Vector2(position.x + 1, position.y + 1)]);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - 1, position.y + 1)))
            {
                GridManager.boardTiles[new Vector2(position.x - 1, position.y + 1)].HighLight(color);
                Selected.Add(GridManager.boardTiles[new Vector2(position.x - 1, position.y + 1)]);
            }
        }
        else if (type == ChessPieces.Knight)
        {
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + 2, position.y + 1)))
            {
                GridManager.boardTiles[new Vector2(position.x + 2, position.y + 1)].HighLight(color);
                Selected.Add(GridManager.boardTiles[new Vector2(position.x + 2, position.y + 1)]);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + 2, position.y - 1)))
            {
                GridManager.boardTiles[new Vector2(position.x + 2, position.y - 1)].HighLight(color);
                Selected.Add(GridManager.boardTiles[new Vector2(position.x + 2, position.y - 1)]);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - 2, position.y + 1)))
            {
                GridManager.boardTiles[new Vector2(position.x - 2, position.y + 1)].HighLight(color);
                Selected.Add(GridManager.boardTiles[new Vector2(position.x - 2, position.y + 1)]);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - 2, position.y - 1)))
            {
                GridManager.boardTiles[new Vector2(position.x - 2, position.y - 1)].HighLight(color);
                Selected.Add(GridManager.boardTiles[new Vector2(position.x - 2, position.y - 1)]);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + 1, position.y + 2)))
            {
                GridManager.boardTiles[new Vector2(position.x + 1, position.y + 2)].HighLight(color);
                Selected.Add(GridManager.boardTiles[new Vector2(position.x + 1, position.y + 2)]);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x + 1, position.y - 2)))
            {
                GridManager.boardTiles[new Vector2(position.x + 1, position.y - 2)].HighLight(color);
                Selected.Add(GridManager.boardTiles[new Vector2(position.x + 1, position.y - 2)]);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - 1, position.y + 2)))
            {
                GridManager.boardTiles[new Vector2(position.x - 1, position.y + 2)].HighLight(color);
                Selected.Add(GridManager.boardTiles[new Vector2(position.x - 1, position.y + 2)]);
            }
            if (GridManager.boardTiles.ContainsKey(new Vector2(position.x - 1, position.y - 2)))
            {
                GridManager.boardTiles[new Vector2(position.x - 1, position.y - 2)].HighLight(color);
                Selected.Add(GridManager.boardTiles[new Vector2(position.x - 1, position.y - 2)]);
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

