using System;
using UnityEngine;

namespace Chess.Scripts.Core
{
    public class ChessPlayerPlacementHandler : MonoBehaviour
    {
        [SerializeField] public int row, column;
        GameObject parentTile;
        int nextRow;
        int nextColumn;

        private void Start()
        {
            transform.position = ChessBoardPlacementHandler.Instance.GetTile(row, column).transform.position;
            transform.parent = ChessBoardPlacementHandler.Instance.GetTile(row, column).transform;
        }

        public void changePosition(int row,int column)
        {
            transform.position = ChessBoardPlacementHandler.Instance.GetTile(row, column).transform.position;
            transform.parent = ChessBoardPlacementHandler.Instance.GetTile(row, column).transform;
            this.row = row;
            this.column = column;
        }
        public void killPosition(GameObject gameObject)
        {
            Destroy(gameObject);
        }
    }
}