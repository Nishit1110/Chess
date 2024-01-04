using UnityEngine;
using Chess.Scripts.Core;

public class PossibleMovesFinder : MonoBehaviour
{
    internal static PossibleMovesFinder instanse;
    ChessPlayerPlacementHandler playerPlacementHandler;
    private int nextTileRow;
    int nextTileColumn;
    private int _loopCount = 1;
    private const int _MAX_BOUNDRY = 8;
    private const int _MIN_BOUNDRY = 0;

    private void Awake()
    {
        instanse = this;
    }


    //Returns 0 if peice is white and 1 if piece is black 
    private int IsPieceWhite(GameObject gameObject)   
    {
        if (gameObject.transform.GetChild(0).gameObject.layer.Equals(3))
        {
            return 0;
        }
        else if (gameObject.transform.GetChild(0).gameObject.layer.Equals(6))
        {
            return 1;
        }
        return 2;
    }

    //Check If can kill or not
    private void CanBlackKillOnLocation(GameObject gameObject, int nextTileRow, int nextTileColumn, GameObject cameFrom)
    {
        if (gameObject.transform.childCount >= 1 && IsPieceWhite(gameObject).Equals(0))
        {
            Debug.Log("Kill");
            ChessBoardPlacementHandler.Instance.HighlightRed(nextTileRow, nextTileColumn,cameFrom, gameObject.transform.GetChild(0).gameObject);
        }
    }

    //Check If can kill or not
    private void CanWhiteKillOnLocation(GameObject gameObject, int nextTileRow, int nextTileColumn, GameObject cameFrom)
    {
        if (gameObject.transform.childCount >= 1 && IsPieceWhite(gameObject).Equals(1))
        {
            ChessBoardPlacementHandler.Instance.HighlightRed(nextTileRow, nextTileColumn,cameFrom,gameObject.transform.GetChild(0).gameObject);
        }
    }

    //Rook's possible moves finding function
    internal void RookPossibleFinder(GameObject gameObject)
    {
        playerPlacementHandler = gameObject.GetComponent<ChessPlayerPlacementHandler>();

        nextTileRow = playerPlacementHandler.row + 1;
        while (nextTileRow < _MAX_BOUNDRY)
        {
            GameObject resultTile = ChessBoardPlacementHandler.Instance.GetTile(nextTileRow, playerPlacementHandler.column);

            if (gameObject.layer.Equals(3))
            {
                CanWhiteKillOnLocation(resultTile, nextTileRow, playerPlacementHandler.column,gameObject);
            }
            else
            {
                CanBlackKillOnLocation(resultTile, nextTileRow, playerPlacementHandler.column, gameObject);
            }
            if (resultTile.transform.childCount == 0 || resultTile.transform.GetChild(0).gameObject.name == "Highlighter(Clone)")
            {
                ChessBoardPlacementHandler.Instance.Highlight(nextTileRow, playerPlacementHandler.column,gameObject);
                nextTileRow += 1;
            }
            else
            {
                break;
            }
        } //Forword Possible Moves
        nextTileRow = playerPlacementHandler.row - 1;
        while (nextTileRow >= _MIN_BOUNDRY)
        {
            GameObject resultTile = ChessBoardPlacementHandler.Instance.GetTile(nextTileRow, playerPlacementHandler.column);

            if (gameObject.layer.Equals(3))
            {
                CanWhiteKillOnLocation(resultTile, nextTileRow, playerPlacementHandler.column, gameObject);
            }
            else
            {
                CanBlackKillOnLocation(resultTile, nextTileRow, playerPlacementHandler.column, gameObject);
            }
            if (resultTile.transform.childCount == 0 || resultTile.transform.GetChild(0).gameObject.name == "Highlighter(Clone)")
            {
                ChessBoardPlacementHandler.Instance.Highlight(nextTileRow, playerPlacementHandler.column,gameObject);
                nextTileRow -= 1;
            }
            else
            {
                break;
            }
        }//BackWord Possible Moves

        nextTileColumn = playerPlacementHandler.column + 1;
        while (nextTileColumn < _MAX_BOUNDRY)
        {
            GameObject resultTile = ChessBoardPlacementHandler.Instance.GetTile(playerPlacementHandler.row, nextTileColumn);

            if (gameObject.layer.Equals(3))
            {
                CanWhiteKillOnLocation(resultTile, playerPlacementHandler.row, nextTileColumn, gameObject);
            }
            else
            {
                CanBlackKillOnLocation(resultTile, playerPlacementHandler.row, nextTileColumn, gameObject);
            }
            if (resultTile.transform.childCount == 0 || resultTile.transform.GetChild(0).gameObject.name == "Highlighter(Clone)")
            {
                ChessBoardPlacementHandler.Instance.Highlight(playerPlacementHandler.row, nextTileColumn, gameObject);
                nextTileColumn += 1;
            }
            else
            {
                break;
            }
        }//RightSide Possible Moves
        
        nextTileColumn = playerPlacementHandler.column - 1;
        while (nextTileColumn >= _MIN_BOUNDRY)
        {
            GameObject resultTile = ChessBoardPlacementHandler.Instance.GetTile(playerPlacementHandler.row, nextTileColumn);

            if (gameObject.layer.Equals(3))
            {
                CanWhiteKillOnLocation(resultTile, playerPlacementHandler.row, nextTileColumn, gameObject);
            }
            else
            {
                CanBlackKillOnLocation(resultTile, playerPlacementHandler.row, nextTileColumn, gameObject);
            }
            if (resultTile.transform.childCount == 0 || resultTile.transform.GetChild(0).gameObject.name == "Highlighter(Clone)")
            {
                ChessBoardPlacementHandler.Instance.Highlight(playerPlacementHandler.row, nextTileColumn, gameObject);
                nextTileColumn -= 1;
            }
            else
            {
                break;
            }
        }
    }

    //Bishop's possible moves finding function
    internal void BishopPossibleFinder(GameObject gameObject)
    {
        playerPlacementHandler = gameObject.GetComponent<ChessPlayerPlacementHandler>();

        nextTileRow = playerPlacementHandler.row + 1;
        nextTileColumn = playerPlacementHandler.column + 1;
        while (nextTileRow < _MAX_BOUNDRY && nextTileColumn < _MAX_BOUNDRY)
        {
            GameObject resultTile = ChessBoardPlacementHandler.Instance.GetTile(nextTileRow, nextTileColumn);

            if (gameObject.layer.Equals(3))
            {
                CanWhiteKillOnLocation(resultTile, nextTileRow, nextTileColumn, gameObject);
            }
            else
            {
                CanBlackKillOnLocation(resultTile, nextTileRow, nextTileColumn, gameObject);
            }
            if (resultTile.transform.childCount == 0 || resultTile.transform.GetChild(0).gameObject.name == "Highlighter(Clone)")
            {
                ChessBoardPlacementHandler.Instance.Highlight(nextTileRow, nextTileColumn, gameObject);
                nextTileRow += 1;
                nextTileColumn += 1;
            }
            else
            {
                break;
            }
        } //Forword Right Possible Moves

        nextTileRow = playerPlacementHandler.row - 1;
        nextTileColumn = playerPlacementHandler.column + 1;
        while (nextTileRow >= _MIN_BOUNDRY && nextTileColumn < _MAX_BOUNDRY)
        {
            GameObject resultTile = ChessBoardPlacementHandler.Instance.GetTile(nextTileRow, nextTileColumn);

            if (gameObject.layer.Equals(3))
            {
                CanWhiteKillOnLocation(resultTile, nextTileRow, nextTileColumn, gameObject);
            }
            else
            {
                CanBlackKillOnLocation(resultTile, nextTileRow, nextTileColumn, gameObject);
            }
            if (resultTile.transform.childCount == 0 || resultTile.transform.GetChild(0).gameObject.name == "Highlighter(Clone)")
            {
                ChessBoardPlacementHandler.Instance.Highlight(nextTileRow, nextTileColumn, gameObject);
                nextTileRow -= 1;
                nextTileColumn += 1;
            }
            else
            {
                break;
            }
        }//BackWord Right Possible Moves

        nextTileRow = playerPlacementHandler.row + 1;
        nextTileColumn = playerPlacementHandler.column - 1;
        while (nextTileColumn >= _MIN_BOUNDRY && nextTileRow < _MAX_BOUNDRY)
        {
            GameObject resultTile = ChessBoardPlacementHandler.Instance.GetTile(nextTileRow, nextTileColumn);

            if (gameObject.layer.Equals(3))
            {
                CanWhiteKillOnLocation(resultTile, nextTileRow, nextTileColumn, gameObject);
            }
            else
            {
                CanBlackKillOnLocation(resultTile, nextTileRow, nextTileColumn, gameObject);
            }
            if (resultTile.transform.childCount == 0 || resultTile.transform.GetChild(0).gameObject.name == "Highlighter(Clone)")
            {
                ChessBoardPlacementHandler.Instance.Highlight(nextTileRow, nextTileColumn, gameObject);
                nextTileRow += 1;
                nextTileColumn -= 1;

            }
            else
            {
                break;
            }
        }//Forward Left Possible Moves

        nextTileRow = playerPlacementHandler.row - 1;
        nextTileColumn = playerPlacementHandler.column - 1;
        while (nextTileColumn >= _MIN_BOUNDRY && nextTileRow >= _MIN_BOUNDRY)
        {
            GameObject resultTile = ChessBoardPlacementHandler.Instance.GetTile(nextTileRow, nextTileColumn);

            if (gameObject.layer.Equals(3))
            {
                CanWhiteKillOnLocation(resultTile, nextTileRow, nextTileColumn, gameObject);
            }
            else
            {
                CanBlackKillOnLocation(resultTile, nextTileRow, nextTileColumn, gameObject);
            }
            if (resultTile.transform.childCount == 0 || resultTile.transform.GetChild(0).gameObject.name == "Highlighter(Clone)")
            {
                ChessBoardPlacementHandler.Instance.Highlight(nextTileRow, nextTileColumn, gameObject);
                nextTileRow -= 1;
                nextTileColumn -= 1;
            }
            else
            {
                break;
            }
        }//Backword Left Possible Moves
    }

    //Knight's possible moves finding function
    internal void KnightPossibleFinder(GameObject gameObject)
    {
        playerPlacementHandler = gameObject.GetComponent<ChessPlayerPlacementHandler>();

        nextTileRow = playerPlacementHandler.row + 2;
        nextTileColumn = playerPlacementHandler.column + 1;
        for (int i = 0; i < 2; i++)
        {
            if (nextTileRow < _MAX_BOUNDRY && nextTileColumn >= _MIN_BOUNDRY && nextTileColumn < _MAX_BOUNDRY)
            {
                GameObject resultTile = ChessBoardPlacementHandler.Instance.GetTile(nextTileRow, nextTileColumn);

                if (gameObject.layer.Equals(3))
                {
                    CanWhiteKillOnLocation(resultTile, nextTileRow, nextTileColumn, gameObject);
                }
                else
                {
                    CanBlackKillOnLocation(resultTile, nextTileRow, nextTileColumn, gameObject);
                }
                if (resultTile.transform.childCount == 0 || resultTile.transform.GetChild(0).gameObject.name == "Highlighter(Clone)")
                {
                    ChessBoardPlacementHandler.Instance.Highlight(nextTileRow, nextTileColumn, gameObject);
                }
            }
            nextTileColumn -= 2;
        } //Forword Possible Moves

        nextTileRow = playerPlacementHandler.row - 2;
        nextTileColumn = playerPlacementHandler.column + 1;
        for (int i = 0; i < 2; i++)
        {
            if (nextTileRow >= _MIN_BOUNDRY && nextTileColumn >= _MIN_BOUNDRY && nextTileColumn < _MAX_BOUNDRY)
            {
                GameObject resultTile = ChessBoardPlacementHandler.Instance.GetTile(nextTileRow, nextTileColumn);

                if (gameObject.layer.Equals(3))
                {
                    CanWhiteKillOnLocation(resultTile, nextTileRow, nextTileColumn, gameObject);
                }
                else
                {
                    CanBlackKillOnLocation(resultTile, nextTileRow, nextTileColumn, gameObject);
                }
                if (resultTile.transform.childCount == 0 || resultTile.transform.GetChild(0).gameObject.name == "Highlighter(Clone)")
                {
                    ChessBoardPlacementHandler.Instance.Highlight(nextTileRow, nextTileColumn, gameObject);
                    nextTileColumn -= 2;
                }
            }
            else
            {
                nextTileColumn -= 2;
            }
        }//BackWord Possible Moves

        nextTileRow = playerPlacementHandler.row + 1;
        nextTileColumn = playerPlacementHandler.column - 2;
        for (int i = 0; i < 2; i++)
        {
            if (nextTileRow >= _MIN_BOUNDRY && nextTileRow < _MAX_BOUNDRY && nextTileColumn >= _MIN_BOUNDRY)
            {
                GameObject resultTile = ChessBoardPlacementHandler.Instance.GetTile(nextTileRow, nextTileColumn);

                if (gameObject.layer.Equals(3))
                {
                    CanWhiteKillOnLocation(resultTile, nextTileRow, nextTileColumn, gameObject);
                }
                else
                {
                    CanBlackKillOnLocation(resultTile, nextTileRow, nextTileColumn, gameObject);
                }
                if (resultTile.transform.childCount == 0 || resultTile.transform.GetChild(0).gameObject.name == "Highlighter(Clone)")
                {
                    ChessBoardPlacementHandler.Instance.Highlight(nextTileRow, nextTileColumn, gameObject);
                    nextTileRow -= 2;
                }
            }
            else
            {
                nextTileRow -= 2;
            }
        }//Forward Left Possible Moves

        nextTileRow = playerPlacementHandler.row + 1;
        nextTileColumn = playerPlacementHandler.column + 2;

        for (int i = 0; i < 2; i++)
        {
            if (nextTileRow >= _MIN_BOUNDRY && nextTileRow < _MAX_BOUNDRY && nextTileColumn < _MAX_BOUNDRY)
            {
                GameObject resultTile = ChessBoardPlacementHandler.Instance.GetTile(nextTileRow, nextTileColumn);

                if (gameObject.layer.Equals(3))
                {
                    CanWhiteKillOnLocation(resultTile, nextTileRow, nextTileColumn, gameObject);
                }
                else
                {
                    CanBlackKillOnLocation(resultTile, nextTileRow, nextTileColumn, gameObject);
                }
                if (resultTile.transform.childCount == 0 || resultTile.transform.GetChild(0).gameObject.name == "Highlighter(Clone)")
                {
                    ChessBoardPlacementHandler.Instance.Highlight(nextTileRow, nextTileColumn, gameObject);
                    nextTileRow -= 2;
                }
            }
            else
            {
                nextTileRow -= 2;
            }
        }
        //Backword Left Possible Moves
    }

    //King's possible moves finding function
    internal void KingPossibleFinder(GameObject gameObject)
    {
        playerPlacementHandler = gameObject.GetComponent<ChessPlayerPlacementHandler>();

        nextTileRow = playerPlacementHandler.row + 1;
        nextTileColumn = playerPlacementHandler.column + 1;
        for (int i = 0; i < 3; i++)
        {
            if (nextTileRow < _MAX_BOUNDRY && nextTileColumn >= _MIN_BOUNDRY && nextTileColumn < _MAX_BOUNDRY)
            {
                GameObject resultTile = ChessBoardPlacementHandler.Instance.GetTile(nextTileRow, nextTileColumn);

                if (gameObject.layer.Equals(3))
                {
                    CanWhiteKillOnLocation(resultTile, nextTileRow, nextTileColumn, gameObject);
                }
                else
                {
                    CanBlackKillOnLocation(resultTile, nextTileRow, nextTileColumn, gameObject);
                }
                if (resultTile.transform.childCount == 0 || resultTile.transform.GetChild(0).gameObject.name == "Highlighter(Clone)")
                {
                    ChessBoardPlacementHandler.Instance.Highlight(nextTileRow, nextTileColumn, gameObject);
                }
            }
            nextTileColumn -= 1;

        } //Forword Possible Moves

        nextTileRow = playerPlacementHandler.row - 1;
        nextTileColumn = playerPlacementHandler.column + 1;
        for (int i = 0; i < 3; i++)
        {
            if (nextTileRow >= _MIN_BOUNDRY && nextTileColumn >= _MIN_BOUNDRY && nextTileColumn < _MAX_BOUNDRY)
            {
                GameObject resultTile = ChessBoardPlacementHandler.Instance.GetTile(nextTileRow, nextTileColumn);

                if (gameObject.layer.Equals(3))
                {
                    CanWhiteKillOnLocation(resultTile, nextTileRow, nextTileColumn, gameObject);
                }
                else
                {
                    CanBlackKillOnLocation(resultTile, nextTileRow, nextTileColumn, gameObject);
                }
                if (resultTile.transform.childCount == 0 || resultTile.transform.GetChild(0).gameObject.name == "Highlighter(Clone)")
                {
                    ChessBoardPlacementHandler.Instance.Highlight(nextTileRow, nextTileColumn, gameObject);
                }
            }
            nextTileColumn -= 1;
        }//BackWord Possible Moves

        nextTileColumn = playerPlacementHandler.column + 1;
        if (nextTileColumn < _MAX_BOUNDRY)
        {
            GameObject resultTile = ChessBoardPlacementHandler.Instance.GetTile(playerPlacementHandler.row, nextTileColumn);

            CanBlackKillOnLocation(resultTile, playerPlacementHandler.row, nextTileColumn, gameObject);
            if (resultTile.transform.childCount == 0 || resultTile.transform.GetChild(0).gameObject.name == "Highlighter(Clone)")
            {
                ChessBoardPlacementHandler.Instance.Highlight(playerPlacementHandler.row, nextTileColumn, gameObject);
            }
        }//Right Side Possible Moves

        nextTileColumn = playerPlacementHandler.column - 1;
        if (nextTileColumn < _MAX_BOUNDRY)
        {
            GameObject resultTile = ChessBoardPlacementHandler.Instance.GetTile(playerPlacementHandler.row, nextTileColumn);

            CanBlackKillOnLocation(resultTile, playerPlacementHandler.row, nextTileColumn, gameObject);
            if (resultTile.transform.childCount == 0 || resultTile.transform.GetChild(0).gameObject.name == "Highlighter(Clone)")
            {
                ChessBoardPlacementHandler.Instance.Highlight(playerPlacementHandler.row, nextTileColumn, gameObject);
            }
        }//Left Side Possible Moves
    }

    //Pawn's possible moves finding function
    internal void PawnPossibleMovesFinder(GameObject gameObject)
    {
        playerPlacementHandler = gameObject.GetComponent<ChessPlayerPlacementHandler>();
        if (gameObject.layer.Equals(3))
        {
            nextTileRow = playerPlacementHandler.row - 1;
        }
        else
        {
            nextTileRow = playerPlacementHandler.row + 1;
        }

        if (playerPlacementHandler.row == 1 && gameObject.layer.Equals(6) || playerPlacementHandler.row == 6 && gameObject.layer.Equals(3))
        {
            _loopCount = 2;
        }
        else
            _loopCount = 1;

        for (int i = 0; i < _loopCount && nextTileRow < _MAX_BOUNDRY && nextTileRow >= _MIN_BOUNDRY; i++)
        {
            GameObject resultTile = ChessBoardPlacementHandler.Instance.GetTile(nextTileRow, playerPlacementHandler.column);

            if (resultTile.transform.childCount == 0 || resultTile.transform.GetChild(0).gameObject.name == "Highlighter(Clone)")
            {

                ChessBoardPlacementHandler.Instance.Highlight(nextTileRow, playerPlacementHandler.column, gameObject);
                if (gameObject.layer.Equals(3))
                {
                    nextTileRow -= 1;
                }
                else
                {
                    nextTileRow += 1;
                }
            }
            else
            {
                break;
            }
        }
    }

    //Pawn's possible kills kinding function
    internal void PawnPossibleKillMoves(GameObject gameObject)
    {
        playerPlacementHandler = gameObject.GetComponent<ChessPlayerPlacementHandler>();

        if (gameObject.layer.Equals(3))
        {
            nextTileRow = playerPlacementHandler.row - 1;
        }
        else
        {
            nextTileRow = playerPlacementHandler.row + 1;
        }
        nextTileColumn = playerPlacementHandler.column + 1;

        for (int i = 0; i < 2 && nextTileRow < _MAX_BOUNDRY && nextTileRow >= _MIN_BOUNDRY; i++)
        {
            if (nextTileColumn >= _MIN_BOUNDRY && nextTileColumn < _MAX_BOUNDRY)
            {
                GameObject resultTile = ChessBoardPlacementHandler.Instance.GetTile(nextTileRow, nextTileColumn);
                if (gameObject.layer.Equals(3))
                {
                    CanWhiteKillOnLocation(resultTile, nextTileRow, nextTileColumn, gameObject);
                }
                else
                {
                    CanBlackKillOnLocation(resultTile, nextTileRow, nextTileColumn, gameObject);
                }
            }
            nextTileColumn -= 2;
        }
    }
}
