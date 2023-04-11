using System.Collections.Generic;
using UnityEngine;

public enum ChessPieces{
    Queen, // Hậu
    King, // Vua 
    Knight, // Mã
    Bishop, // Tượng 
    Rook, // Xe 
    Pawn, // Tốt 
    None
}

public enum Team{
    White,
    Black,
    None
}

public class SpriteManager : Singleton<SpriteManager>
{
    public UnityEngine.Sprite []_PawnSprite = new UnityEngine.Sprite[6];
}
