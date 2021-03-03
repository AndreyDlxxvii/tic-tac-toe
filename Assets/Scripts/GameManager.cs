using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button[] Cells;
    public Sprite Tac;
    public Sprite Toe;

    private bool _flag = true;
    private int[] _flagsInts = new int [9] {0, 0, 0, 0, 0, 0, 0, 0, 0};

        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() 
    {
        
    }

    public  void OnClick(int i)
    {
        switch (_flag)
        {
            case true:
                if (_flagsInts[i - 1] == 0)
                {
                    Cells[i - 1].image.sprite = Tac;
                    _flag = false;
                    _flagsInts[i - 1] = 1;
                }
                break;
            case false:
                if (_flagsInts[i - 1] == 0)
                {
                    Cells[i - 1].image.sprite = Toe;
                    _flag = true;
                    _flagsInts[i - 1] = 2;
                }
                break;
        }



    }
}
    