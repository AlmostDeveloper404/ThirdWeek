using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoardGenerator : MonoBehaviour
{
    public GameObject ChessSquarePrefab;
    public Material WhiteMat;
    public Material BlackMat;
    int boardSize = 8;
    void Start()
    {
        for (int y = 0; y < boardSize; y++)
        {
            for (int x = 0; x < boardSize; x++)
            {

                GameObject chessSquareGO= Instantiate(ChessSquarePrefab,new Vector2(y,x),Quaternion.identity);
                if (y % 2 == 0 && x%2==0)
                {
                    chessSquareGO.GetComponent<MeshRenderer>().material= WhiteMat;
                }
                else if(y % 2 == 1 && x % 2==1 )
                {
                    chessSquareGO.GetComponent<MeshRenderer>().material = WhiteMat;
                }else if (y % 2 == 1 && x%2==0)
                {
                    chessSquareGO.GetComponent<MeshRenderer>().material = BlackMat;
                }else if(y % 2 == 0 && x%2==1)
                {
                    chessSquareGO.GetComponent<MeshRenderer>().material = BlackMat;
                }
                
                
            }
        }
    }

    
}
