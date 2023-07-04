using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static bool isYourTurn = false;
    public static Tile tileFrom = null;
    public static Tile tileTo = null;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            isYourTurn = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayerMove(Vector2 from, Vector2 to)
    {
        if(tileFrom != null)
        {
            tileFrom.SetLastMove(false);
        }
        tileFrom = GridManager.boardTiles[from];
        ChessPiece movePiece = tileFrom.GetChessPieces();
        tileFrom.SetLastMove(true);
        movePiece.IsMove = true;
        tileFrom.Reset();
        if(tileTo != null)
        {
            tileTo.SetLastMove(false);
        }
        tileTo = GridManager.boardTiles[to];
        if(tileTo.GetChessPieces() != null)
        {
            Destroy(tileTo.GetChessPieces().gameObject);
        }
        tileTo.SetLastMove(true);
        tileTo.SetChessPieces(movePiece);
        movePiece.transform.position = to;
    }
}
