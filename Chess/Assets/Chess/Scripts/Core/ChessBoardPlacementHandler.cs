using System;
using UnityEngine;
using System.Diagnostics.CodeAnalysis;
using System.Collections;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public sealed class ChessBoardPlacementHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] _rowsArray;
    [SerializeField] private GameObject _highlightPrefab;
    [SerializeField] private GameObject _highlightPrefabRed;

    private GameObject[,] _chessBoard;

    HighligherClick highligherClick;
    internal static ChessBoardPlacementHandler Instance;

    private void Awake()
    {
        Instance = this;
        GenerateArray();
    }

    private void GenerateArray()
    {
        _chessBoard = new GameObject[8, 8];
        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                _chessBoard[i, j] = _rowsArray[i].transform.GetChild(j).gameObject;
            }
        }
    }

    internal GameObject GetTile(int i, int j)
    {
        try
        {
            return _chessBoard[i, j];
        }
        catch (Exception)
        {
            Debug.LogError("Invalid row or column.");
            return null;
        }
    }

    internal void Highlight(int row, int col , GameObject cameFrom)
    {
        var tile = GetTile(row, col).transform;
        if (tile == null)
        {
            Debug.LogError("Invalid row or column.");
            return;
        }

        GameObject highLighted = Instantiate(_highlightPrefab, tile.transform.position, Quaternion.identity, tile.transform);
        highligherClick = highLighted.GetComponent<HighligherClick>();
        highligherClick.cameFrom = cameFrom;
        highligherClick.assign(row,col);
       
    }
    internal void HighlightRed(int row, int col,GameObject cameFrom,GameObject killObject)
    {
        var tile = GetTile(row, col).transform;
        if (tile == null)
        {
            Debug.LogError("Invalid row or column.");
            return;
        }

        GameObject highLighted = Instantiate(_highlightPrefabRed, tile.transform.position, Quaternion.identity, tile.transform);
        highligherClick = highLighted.GetComponent<HighligherClick>();
        highligherClick.cameFrom = cameFrom;
        highligherClick.assign(row, col);
        highligherClick.killObject = killObject;
    }

    internal void ClearHighlights()
    {
        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                var tile = GetTile(i, j);
                if (tile.transform.childCount <= 0) continue;
                foreach (Transform childTransform in tile.transform)
                {
                    if (childTransform.gameObject.CompareTag("Piece")) continue;

                    Destroy(childTransform.gameObject);
                }
            }
        }
    }


    #region Highlight Testing

   
    #endregion
}