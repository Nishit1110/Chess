using UnityEngine;

public class KingPossibleMoves : MonoBehaviour
{
    private void OnMouseDown()
    {
        ChessBoardPlacementHandler.Instance.ClearHighlights();
        PossibleMovesFinder.instanse.KingPossibleFinder(this.gameObject);
    }
}
