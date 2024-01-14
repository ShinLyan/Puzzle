using UnityEngine;

/// <summary> Кусок пазла.</summary>
public class Piece : MonoBehaviour
{
    private enum PieceType
    {
        Corner,
        Edge,


    }

    [SerializeField] private PieceType type;




}
