using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [Space(5f), Header("Map Scale")]
    [SerializeField] private int _width;
    [SerializeField] private int _height;

    [Space(5f), Header("Tile")]
    [SerializeField] private Tile _tile;

    [Space(5f), Header("Camera")]
    [SerializeField] private Transform _camera;
    public static Dictionary<Vector2, Tile> boardTiles = new Dictionary<Vector2, Tile>();
    // Start is called before the first frame update
    void Start()
    {
        GridGenerator();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GridGenerator()
    {
        for (int i = 0; i < _height; i++)
        {
            for (int j = 0; j < _width; j++)
            {
                var spawnedTile = Instantiate(_tile, new Vector3(j, i), Quaternion.identity);
                spawnedTile.name = $"Tile [{j}][{i}]";
                spawnedTile.InitTilePosition(j, i);
                spawnedTile.InitTileColor((i + j) % 2 == 0 ? true : false);
                if (i == 1)
                {
                    ChessPiece temp = Instantiate(UnitManager.Instance._pawnPrefab);
                    temp.InitChessPiece(PhotonNetwork.IsMasterClient ? Team.White : Team.Black, ChessPieces.Pawn, new Vector2(j, i));
                    spawnedTile.InitChessPiece(temp);
                }
                else if (i == 6)
                {
                    ChessPiece temp = Instantiate(UnitManager.Instance._pawnPrefab);
                    temp.InitChessPiece(PhotonNetwork.IsMasterClient ? Team.Black : Team.White, ChessPieces.Pawn, new Vector2(j, i));
                    spawnedTile.InitChessPiece(temp);
                }
                else if ((j == 0 || j == 7) && (i == 0 || i == 7))
                {
                    ChessPiece temp = Instantiate(UnitManager.Instance._pawnPrefab);
                    if (PhotonNetwork.IsMasterClient)
                        temp.InitChessPiece(i == 0 ? Team.White : Team.Black, ChessPieces.Rook, new Vector2(j, i));
                    else
                        temp.InitChessPiece(i == 0 ? Team.Black : Team.White, ChessPieces.Rook, new Vector2(j, i));
                    spawnedTile.InitChessPiece(temp);
                }
                else if ((j == 1 || j == 6) && (i == 0 || i == 7))
                {
                    ChessPiece temp = Instantiate(UnitManager.Instance._pawnPrefab);
                    if (PhotonNetwork.IsMasterClient)
                        temp.InitChessPiece(i == 0 ? Team.White : Team.Black, ChessPieces.Knight, new Vector2(j, i));
                    else
                        temp.InitChessPiece(i == 0 ? Team.Black : Team.White, ChessPieces.Knight, new Vector2(j, i));
                    spawnedTile.InitChessPiece(temp);
                }
                else if ((j == 2 || j == 5) && (i == 0 || i == 7))
                {
                    ChessPiece temp = Instantiate(UnitManager.Instance._pawnPrefab);
                    if (PhotonNetwork.IsMasterClient)
                        temp.InitChessPiece(i == 0 ? Team.White : Team.Black, ChessPieces.Bishop, new Vector2(j, i));
                    else
                        temp.InitChessPiece(i == 0 ? Team.Black : Team.White, ChessPieces.Bishop, new Vector2(j, i));
                    spawnedTile.InitChessPiece(temp);
                }
                else if ((j == 3 && i == 0) || (j == 4 && i == 7))
                {
                    ChessPiece temp = Instantiate(UnitManager.Instance._pawnPrefab);
                    if (PhotonNetwork.IsMasterClient)
                        temp.InitChessPiece(i == 0 ? Team.White : Team.Black, ChessPieces.Queen, new Vector2(j, i));
                    else
                        temp.InitChessPiece(i == 0 ? Team.Black : Team.White, ChessPieces.Queen, new Vector2(j, i));
                    spawnedTile.InitChessPiece(temp);
                }
                else if ((j == 4 && i == 0) || (j == 3 && i == 7))
                {
                    ChessPiece temp = Instantiate(UnitManager.Instance._pawnPrefab);
                    if (PhotonNetwork.IsMasterClient)
                        temp.InitChessPiece(i == 0 ? Team.White : Team.Black, ChessPieces.King, new Vector2(j, i));
                    else
                        temp.InitChessPiece(i == 0 ? Team.Black : Team.White, ChessPieces.King, new Vector2(j, i));
                    spawnedTile.InitChessPiece(temp);
                }
                boardTiles.Add(new Vector2(j, i), spawnedTile);
            }
        }
        AlignCamera();
    }

    void AlignCamera()
    {
        _camera.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10f);

    }
}

