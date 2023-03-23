using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelPieceBasedSetup : ScriptableObject
{
    public ArtManager.ArtType artType;

    [Header("Level Pieces")]
    public List<LevelPieceBase> levelsPiecesStart;
    public List<LevelPieceBase> levelsPieces;
    public List<LevelPieceBase> levelsPiecesEnd;

    public int piecesStartNumber = 3;
    public int piecesNumber = 5;
    public int piecesEndNumber = 1;
}
