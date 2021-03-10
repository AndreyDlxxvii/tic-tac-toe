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
    public Sprite CrossSprite;
    public Sprite ZeroSprite;
    public Button StartButton;
    public Button ChangeWhoFirst;

    private bool _flagWhoFirst = true;
    private int _countCross = 0;
    private int _countZero = 0;
    private bool _checkGameOver = true;
    private readonly int[] _flagsIntsCross = new int [9] {0, 0, 0, 0, 0, 0, 0, 0, 0};
    private readonly int[] _flagsIntsZero = new int [9] {0, 0, 0, 0, 0, 0, 0, 0, 0};
    private readonly int[] _check = new int[9] {1, 1, 1, 0, 0, 0, 0, 0, 0};
    private readonly int[] _check1 = new int[9] {1, 0, 0, 1, 0, 0, 1, 0, 0};
    private readonly int[] _check2 = new int[9] {0, 0, 0, 0, 0, 0, 1, 1, 1};
    private readonly int[] _check3 = new int[9] {1, 0, 0, 0, 1, 0, 0, 0, 1};
    private readonly int[] _check4 = new int[9] {0, 1, 0, 0, 1, 0, 0, 1, 0};
    private readonly int[] _check5 = new int[9] {0, 0, 1, 0, 1, 0, 1, 0, 0};
    private readonly int[] _check6 = new int[9] {0, 0, 0, 1, 1, 1, 0, 0, 0};
    private readonly int[] _check7 = new int[9] {0, 0, 1, 0, 0, 1, 0, 0, 1};

    private readonly List<int[]> _checksList = new List<int[]>();

    // Start is called before the first frame update
    void Start()
    {
        ChangeWhoFirst.image.sprite = CrossSprite;
        _checksList.Add(_check);
        _checksList.Add(_check1);
        _checksList.Add(_check2);
        _checksList.Add(_check3);
        _checksList.Add(_check4);
        _checksList.Add(_check5);
        _checksList.Add(_check6);
        _checksList.Add(_check7);
    }

    public void WhoStartFirst()
    {
        if (_flagWhoFirst)
        {
            ChangeWhoFirst.image.sprite = ZeroSprite;
            _flagWhoFirst = false;
        }
        else
        {
            ChangeWhoFirst.image.sprite = CrossSprite;
            _flagWhoFirst = true;
        }

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick(int i)
    {
        if (_checkGameOver)
        {
            switch (_flagWhoFirst)
            {
                case true:
                    if (_flagsIntsCross[i - 1] == 0 && _flagsIntsZero[i - 1] == 0)
                    {
                        Cells[i - 1].image.sprite = CrossSprite;
                        _flagWhoFirst = false;
                        _flagsIntsCross[i - 1] = 1;
                    }
                    break;
                case false:
                    if (_flagsIntsCross[i - 1] == 0 && _flagsIntsZero[i - 1] == 0)
                    {
                        Cells[i - 1].image.sprite = ZeroSprite;
                        _flagWhoFirst = true;
                        _flagsIntsZero[i - 1] = 1;
                    }
                    break;
            }
            CheckToWin();
        }
    }

    private void CheckToWin()
    {
        for (int j = 0; j < 8; j++)
        {
            _countCross = 0;
            _countZero = 0;
            for (int k = 0; k < 9; k++)
            {
                if (_checksList[j][k]==_flagsIntsCross[k] && _checksList[j][k]==1)
                {
                    _countCross++;
                }
                if (_checksList[j][k]==_flagsIntsZero[k] && _checksList[j][k]==1)
                {
                    _countZero++;
                }
                if (_countCross==3)
                {
                    print("it works, Cross win!");
                    _checkGameOver = false;
                    break;
                }
                    
                if (_countZero==3)
                {
                    print("it works Zero win!");
                    _checkGameOver = false;
                    break;
                }
            }
                
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void SetButtonActive()
    {
        foreach (var t in Cells)
        {
            t.gameObject.SetActive(true);
        }
        StartButton.gameObject.SetActive(false);
        ChangeWhoFirst.gameObject.SetActive(false);
    }

}
    