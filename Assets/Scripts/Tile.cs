using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [Space(5f), Header("Color")]
    [SerializeField] private Color _color1;
    [SerializeField] private Color _color2;
    [SerializeField] private Color _selectedColor;
    [SerializeField] private Color _navigatorColor;
    [SerializeField] private Color _enemyColor;

    [Space(5f), Header("SpriteRenderer")]
    [SerializeField] private SpriteRenderer _tileSpriteRenderer;
    [SerializeField] private GameObject _highLightRenderer;
    [SerializeField] private GameObject _statusRender;
    [SerializeField] private GameObject _lastMoveRender;

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

    public void SetLastMove(bool status)
    {
        this._lastMoveRender.gameObject.SetActive(status);
    }

    public ChessPiece GetChessPieces()
    {
        return this._chessPieces;
    }

    public void SetChessPieces(ChessPiece newChessPieces)
    {
        this._chessPieces = newChessPieces;
    }

    public Vector2 GetPosition()
    {
        return new Vector2(7 - _X, 7 - _Y);
    }
    public bool IsWall(Team Color)
    {
        if (this._chessPieces != null)
        {
            Debug.Log($"Found Pieces In {_X},{_Y}");
            if (this._chessPieces.GetPieceColor() != Color)
            {
                UnitManager.Instance.Selected.Add(GridManager.boardTiles[new Vector2(_X, _Y)]);
                this._statusRender.GetComponent<SpriteRenderer>().color = _enemyColor;
                this._statusRender.SetActive(true);
                return true; // this piece is enemy
            }
            else
            {
                return true; // this piece is our team
            }
        }
        UnitManager.Instance.Selected.Add(GridManager.boardTiles[new Vector2(_X, _Y)]);
        this._statusRender.GetComponent<SpriteRenderer>().color = _navigatorColor;
        this._statusRender.SetActive(true);
        return false; // this tile is empty
    }

    public bool IsWall(Team Color, bool IsSide)
    {
        if (this._chessPieces != null)
        {
            Debug.Log($"Found Pieces In {_X},{_Y}");
            if (this._chessPieces.GetPieceColor() != Color)
            {
                if (IsSide)
                {
                    UnitManager.Instance.Selected.Add(GridManager.boardTiles[new Vector2(_X, _Y)]);
                    this._statusRender.GetComponent<SpriteRenderer>().color = _enemyColor;
                    this._statusRender.SetActive(true);
                }
                return true; // this piece is enemy
            }
            else
            {
                return true; // this piece is our team
            }
        }
        if (!IsSide)
        {
            UnitManager.Instance.Selected.Add(GridManager.boardTiles[new Vector2(_X, _Y)]);
            this._statusRender.GetComponent<SpriteRenderer>().color = _navigatorColor;
            this._statusRender.SetActive(true);
        }
        return false; // this tile is empty
    }
    public void UnSelected()
    {
        this._statusRender.SetActive(false);
        UnitManager.Instance.selectedTile = null;
    }

    public void Reset()
    {
        this._chessPieces = null;
    }

    public void UnHighLight()
    {
        this._statusRender.SetActive(false);
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
        if(!GameManager.isYourTurn)
        {
            return;
        }
        if (UnitManager.Instance.selectedTile == null && _chessPieces != null && _chessPieces.GetPieceColor() == (PhotonNetwork.IsMasterClient ? Team.White : Team.Black))
        {
            Debug.Log("SELECTED");
            UnitManager.Instance.selectedTile = this;
            this._statusRender.GetComponent<SpriteRenderer>().color = _selectedColor;
            this._statusRender.SetActive(true);
            UnitManager.Instance.HighLight(_chessPieces.GetPieceType(), _chessPieces.GetPieceColor(), _chessPieces.gameObject.transform.position);

        }
        else if (UnitManager.Instance.selectedTile != null && UnitManager.Instance.selectedTile != this && _chessPieces != null && _chessPieces.GetPieceColor() == (PhotonNetwork.IsMasterClient ? Team.White : Team.Black))
        {
            Debug.Log("RE-SELECTED");
            UnitManager.Instance.selectedTile.UnSelected();
            UnitManager.Instance.UnHighLight();
            UnitManager.Instance.selectedTile = this;
            this._statusRender.GetComponent<SpriteRenderer>().color = _selectedColor;
            this._statusRender.SetActive(true);
            UnitManager.Instance.HighLight(_chessPieces.GetPieceType(), _chessPieces.GetPieceColor(), _chessPieces.gameObject.transform.position);
        }
        else if (UnitManager.Instance.selectedTile != null)
        {
            if (UnitManager.Instance.Selected.Contains(this))
            {
                if (this._chessPieces != null)
                {
                    Debug.Log("KILL");
                    Destroy(this._chessPieces.gameObject);
                }
                Debug.Log("MOVE");
                this._chessPieces = UnitManager.Instance.selectedTile.GetChessPieces();
                this._chessPieces.IsMove = true;
                Vector2 temp = UnitManager.Instance.selectedTile.GetPosition();
                UnitManager.Instance.selectedTile.Reset();
                this._chessPieces.gameObject.transform.position = this.transform.position;
                MatchManager.instance.PlayerMoveSend(temp, GetPosition());
                GameManager.isYourTurn = false;
            }
            Debug.Log("UNHIGHLIGHT");
            UnitManager.Instance.selectedTile.UnSelected();
            UnitManager.Instance.UnHighLight();
        }

    }
}
