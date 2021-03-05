using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button[] Cells;
    public Sprite Tac;
    public Sprite Toe;

    private bool _flag = true;
    private int[] _flagsIntsTac = new int [9] {0, 0, 0, 0, 0, 0, 0, 0, 0};
    private int[] _flagsIntsToe = new int [9] {0, 0, 0, 0, 0, 0, 0, 0, 0};
    private int[] _check = new int[9] {1, 1, 1, 0, 0, 0, 0, 0, 0};

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
                if (_flagsIntsTac[i - 1] == 0 && _flagsIntsToe[i-1] == 0)
                {
                    Cells[i - 1].image.sprite = Tac;
                    _flag = false;
                    _flagsIntsTac[i - 1] = 1;
                }
                break;
            case false:
                if (_flagsIntsTac[i - 1] == 0 && _flagsIntsToe[i-1] == 0)
                {
                    Cells[i - 1].image.sprite = Toe;
                    _flag = true;
                    _flagsIntsToe[i - 1] = 2;
                }
                break;
        }
       if (_check.SequenceEqual(_flagsIntsTac))
        {
            
            print("it works!");
        }
    }
}
    