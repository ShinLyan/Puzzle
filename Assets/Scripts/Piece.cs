using UnityEngine;

/// <summary> ����� �����.</summary>
public class Piece : MonoBehaviour
{
    private enum PieceType
    {
        Corner,
        Edge,


    }

    [SerializeField] private PieceType type;




}
