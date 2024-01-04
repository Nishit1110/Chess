using UnityEngine;

public class BishopPossibleMoves : MonoBehaviour
{
    private void OnMouseDown()
    {
        ChessBoardPlacementHandler.Instance.ClearHighlights();
        PossibleMovesFinder.instanse.BishopPossibleFinder(this.gameObject);
    }
}
