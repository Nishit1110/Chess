using UnityEngine;

public class QueenPossibleMoves : MonoBehaviour
{
    private void OnMouseDown()
    {
        ChessBoardPlacementHandler.Instance.ClearHighlights();
        PossibleMovesFinder.instanse.RookPossibleFinder(this.gameObject);
        PossibleMovesFinder.instanse.BishopPossibleFinder(this.gameObject);
    }
}
