using UnityEngine;

public class RookPossibleMoves : MonoBehaviour
{
    private void OnMouseDown()
    {
        ChessBoardPlacementHandler.Instance.ClearHighlights();
        PossibleMovesFinder.instanse.RookPossibleFinder(this.gameObject);
    }
}
