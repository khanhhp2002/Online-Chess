using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [Space(5f), Header("Color")]
    [SerializeField] private Color _color1;
    [SerializeField] private Color _color2;

    [Space(5f), Header("SpriteRenderer")]
    [SerializeField] private SpriteRenderer _tileSpriteRenderer;
    [SerializeField] private GameObject _highLightRenderer;
    [SerializeField] private SpriteRenderer _chessPiecesRenderer;

    [Space(5f), Header("Chess Pieces Type")]
    [SerializeField] private ChessPieces _chessPiecesType;
    [SerializeField] private Team _chessPiecesColor;

    [Space(5f), Header("Position")]
    [SerializeField] private int _X;
    [SerializeField] private int _Y;

    [SerializeField] private ChessPiece _chessPieces;
    // Start is called before the first frame update

    public void InitTileColor(bool isOdd)
    {
        if (isOdd)
        {
            _tileSpriteRenderer.color = _color1;
        }
        else
        {
            _tileSpriteRenderer.color = _color2;
        }
    }

    public void InitTilePosition(int x, int y)
    {
        _X = x;
        _Y = y;
    }
    public void InitChessPiece(ChessPiece chessPiece)
    {
        this._chessPieces = chessPiece;
    }

    public void HighLight(Team color)
    {
        if (_chessPieces == null || _chessPieces.GetPieceColor() != color)
        {
            _highLightRenderer.SetActive(true);
            UnitManager.Instance.Selected.Add(GridManager.boardTiles[new Vector2(_X, _Y)]);
        }
    }

    public ChessPiece GetChessPieces()
    {
        return this._chessPieces;
    }

    public void Reset()
    {
        this._chessPieces = null;
    }

    public void UnHighLight()
    {
        _highLightRenderer.SetActive(false);
    }

    void OnMouseEnter()
    {
        _highLightRenderer.SetActive(true);
    }

    void OnMouseExit()
    {
        _highLightRenderer.SetActive(false);
    }
    void OnMouseDown()
    {
        if (UnitManager.Instance.selectedTile == null && _chessPieces != null)
        {
            UnitManager.Instance.selectedTile = this;
            UnitManager.Instance.HighLight(_chessPieces.GetPieceType(), _chessPieces.GetPieceColor(), _chessPieces.gameObject.transform.position);

        }
        else
        {
            if (UnitManager.Instance.Selected.Contains(this))
            {
                this._chessPieces = UnitManager.Instance.selectedTile.GetChessPieces();
                this._chessPieces.isMove = true;
                UnitManager.Instance.selectedTile.Reset();
                UnitManager.Instance.selectedTile = null;
                this._chessPieces.gameObject.transform.position = this.transform.position;
            }
            else
            {
                UnitManager.Instance.selectedTile = null;
            }
            UnitManager.Instance.UnHighLight();
        }

    }
}
