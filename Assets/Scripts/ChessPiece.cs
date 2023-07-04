using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    [SerializeField]
    private Team pieceColor;

    [SerializeField]
    private ChessPieces pieceType;

    [SerializeField]
    private Sprite pieceSprite;

    public bool IsMove = false;
    public void Selection()
    {

    }

    public void Deselection()
    {

    }

    public void Promotion()
    {

    }

    public Team GetPieceColor()
    {
        return this.pieceColor;
    }

    public ChessPieces GetPieceType()
    {
        return this.pieceType;
    }
    

    public void InitChessPiece(Team color, ChessPieces type, Vector2 position)
    {
        this.gameObject.transform.position = position;
        this.pieceColor = color;
        this.pieceType = type;
        if (color == Team.White)
        {
            if (this.pieceType == ChessPieces.Bishop)
                this.pieceSprite = SpriteManager.Instance._PawnSprite[6];
            else if (this.pieceType == ChessPieces.King)
                this.pieceSprite = SpriteManager.Instance._PawnSprite[7];
            else if (this.pieceType == ChessPieces.Knight)
                this.pieceSprite = SpriteManager.Instance._PawnSprite[8];
            else if (this.pieceType == ChessPieces.Pawn)
                this.pieceSprite = SpriteManager.Instance._PawnSprite[9];
            else if (this.pieceType == ChessPieces.Queen)
                this.pieceSprite = SpriteManager.Instance._PawnSprite[10];
            else if (this.pieceType == ChessPieces.Rook)
                this.pieceSprite = SpriteManager.Instance._PawnSprite[11];
        }
        else
        {
            if (this.pieceType == ChessPieces.Bishop)
                this.pieceSprite = SpriteManager.Instance._PawnSprite[0];
            else if (this.pieceType == ChessPieces.King)
                this.pieceSprite = SpriteManager.Instance._PawnSprite[1];
            else if (this.pieceType == ChessPieces.Knight)
                this.pieceSprite = SpriteManager.Instance._PawnSprite[2];
            else if (this.pieceType == ChessPieces.Pawn)
                this.pieceSprite = SpriteManager.Instance._PawnSprite[3];
            else if (this.pieceType == ChessPieces.Queen)
                this.pieceSprite = SpriteManager.Instance._PawnSprite[4];
            else if (this.pieceType == ChessPieces.Rook)
                this.pieceSprite = SpriteManager.Instance._PawnSprite[5];
        }
        this.GetComponent<SpriteRenderer>().sprite = this.pieceSprite;
    }
}
