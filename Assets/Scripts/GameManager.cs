using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    private int[] _check1 = new int[9] {1, 0, 0, 1, 0, 0, 1, 0, 0};
    private int[] _check2 = new int[9] {0, 0, 0, 0, 0, 0, 1, 1, 1};
    private int[] _check3 = new int[9] {1, 0, 0, 0, 1, 0, 0, 0, 1};
    private int[] _check4 = new int[9] {0, 1, 0, 0, 1, 0, 0, 1, 0};
    private int[] _check5 = new int[9] {0, 0, 1, 0, 1, 0, 1, 0, 0};
    private int[] _check6 = new int[9] {0, 0, 0, 1, 1, 1, 0, 0, 0};
    private int[] _check7 = new int[9] {0, 0, 1, 0, 0, 1, 0, 0, 1};

    private List<int[]> _checksList = new List<int[]>();

    // Start is called before the first frame update
    void Start()
    {
        _checksList.Add(_check);
        _checksList.Add(_check1);
        _checksList.Add(_check2);
        _checksList.Add(_check3);
        _checksList.Add(_check4);
        _checksList.Add(_check5);
        _checksList.Add(_check6);
        _checksList.Add(_check7);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick(int i)
    {
        switch (_flag)
        {
            case true:
                if (_flagsIntsTac[i - 1] == 0 && _flagsIntsToe[i - 1] == 0)
                {
                    Cells[i - 1].image.sprite = Tac;
                    _flag = false;
                    _flagsIntsTac[i - 1] = 1;
                }

                break;
            case false:
                if (_flagsIntsTac[i - 1] == 0 && _flagsIntsToe[i - 1] == 0)
                {
                    Cells[i - 1].image.sprite = Toe;
                    _flag = true;
                    _flagsIntsToe[i - 1] = 1;
                }

                break;
        }

        for (int j = 0; j < 8; j++)
        {
            if (_checksList[j].SequenceEqual(_flagsIntsTac))
            {
                print("it works, tac win!");
            }

            if (_checksList[j].SequenceEqual(_flagsIntsToe))
            {
                print("it works toe win!");
            }
        }

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

}
    