using System.Collections;
using System.Collections.Generic;
using Chess.Scripts.Core;
using UnityEngine;

public class HighligherClick : MonoBehaviour
{
    public GameObject cameFrom;
    public GameObject killObject;
    ChessPlayerPlacementHandler chessPlayerPlacementHandler;
    int rowNumber,colNumber;

    public void assign(int rowNumber,int colNumber)
    {
        chessPlayerPlacementHandler = cameFrom.GetComponent<ChessPlayerPlacementHandler>();
        this.rowNumber = rowNumber;
        this.colNumber = colNumber;
    }

    private void OnMouseDown()
    {
        if (gameObject.layer.Equals(6))
            chessPlayerPlacementHandler.killPosition(killObject);
        chessPlayerPlacementHandler.changePosition(rowNumber,colNumber);
        ChessBoardPlacementHandler.Instance.ClearHighlights();
    }
}