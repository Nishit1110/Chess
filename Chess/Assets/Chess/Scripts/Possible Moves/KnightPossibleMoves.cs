using UnityEngine;

public class KnightPossibleMoves : MonoBehaviour
{
    private void OnMouseDown()
    {
        ChessBoardPlacementHandler.Instance.ClearHighlights();
        PossibleMovesFinder.instanse.KnightPossibleFinder(this.gameObject);
    }
}
