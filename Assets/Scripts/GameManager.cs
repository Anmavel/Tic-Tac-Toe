using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    [SerializeField] private Sprite circle;
    [SerializeField] private Sprite x;
    [SerializeField] private Text value;
    //private List<string> liste = new List<string>();

    // [SerializeField] private Sprite emptySprite;
    private int player = 1;
    private int[] field = new int[9];
    //private List<int> field = new List<int>(9);
    private int turn;
    [SerializeField] private Button[] buttons;


    public void ButtonClicked(Button button)
    {
       
        button.GetComponent<Image>().sprite = player == 1 ? x : circle;
        button.interactable = false;
        int number = int.Parse(button.GetComponentInChildren<Text>().text);
        field[number] = player;

        if (WinnerFlag())
        {
            // Spieler hat gewonnen 

            Win();
            return;

        }

        if (player == 2) player = 1;
        else player = 2;

        turn++;

        if (turn == 9)
        {
            value.gameObject.SetActive(true);
            value.text = "New Game"; // Meldung für den Spieler. Spiel ist vorbei.
        }

    }

    private bool WinnerFlag()
    {
        int sum = 0;
        for (int i = 0; i < 9; i += 3)
        {
            for (int j = i; j < i+3; j++) //Index des Arrays
            {
                if (field[j] == player)// Array wird überprüft
                    sum++;
            }
            if (sum == 3)
                return true;
            sum = 0;
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = i; j < 9; j += 3) //Index des Arrays
            {
                if (field[j] == player) // Array wird überprüft
                    sum++;
            }
            if (sum == 3)
                return true;
            sum = 0;
        }

        //(0) && (4) && (8) Stellen im array

        for (int i = 0; i < 9; i += 4)
        {
            if (field[i] == player)
            {
                sum++;
            }

        }


        if (sum == 3)
            return true;
        sum = 0;


        for (int i = 2; i < 7; i += 2)
        {
            if (field[i] == player)
            {
                sum++;
            }
            // if (sum == 3)
            //     return true;
            // else return false
        }
        return sum == 3;

    }

    private void Win()
    {



        for (int i = 0; i <buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }


        value.gameObject.SetActive(true);
        value.text += player.ToString(); // += addiert zum String "concatenate"
    }

    public void Restart()
    {
        SceneManager.LoadScene(0); // Alternative("GameScene")

    }
}


