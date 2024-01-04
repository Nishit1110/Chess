using UnityEngine;

public class PawnPossibleMoves : MonoBehaviour
{
    private void OnMouseDown()
    {
        ChessBoardPlacementHandler.Instance.ClearHighlights();
        PossibleMovesFinder.instanse.PawnPossibleMovesFinder(this.gameObject);
        PossibleMovesFinder.instanse.PawnPossibleKillMoves(gameObject);
    }
}
