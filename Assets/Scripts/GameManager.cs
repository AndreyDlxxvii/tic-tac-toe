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
    public Sprite Cross;
    public Sprite Zero;

    private bool _flag = true;
    private bool _checkGameOver = true;
    private int[] _flagsIntsCross = new int [9] {0, 0, 0, 0, 0, 0, 0, 0, 0};
    private int[] _flagsIntsZero = new int [9] {0, 0, 0, 0, 0, 0, 0, 0, 0};
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
        for (int i = 0; i < Cells.Length; i++)
        {
            Cells[i].gameObject.SetActive(true);
        }
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
        if (_checkGameOver)
        {
            switch (_flag)
            {
                case true:
                    if (_flagsIntsCross[i - 1] == 0 && _flagsIntsZero[i - 1] == 0)
                    {
                        Cells[i - 1].image.sprite = Cross;
                        _flag = false;
                        _flagsIntsCross[i - 1] = 1;
                    }

                    break;
                case false:
                    if (_flagsIntsCross[i - 1] == 0 && _flagsIntsZero[i - 1] == 0)
                    {
                        Cells[i - 1].image.sprite = Zero;
                        _flag = true;
                        _flagsIntsZero[i - 1] = 1;
                    }

                    break;
            }

            for (int j = 0; j < 8; j++)
            {
                if (_checksList[j].SequenceEqual(_flagsIntsCross))
                {
                    print("it works, Cross win!");
                    _checkGameOver = false;
                }

                if (_checksList[j].SequenceEqual(_flagsIntsZero))
                {
                    print("it works Zero win!");
                    _checkGameOver = false;
                }
            }
        }
        

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

}
    