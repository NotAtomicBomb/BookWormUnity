using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainController : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI attackWord;

    public TextMeshProUGUI p1Hp;
    public TextMeshProUGUI p2Hp;
    public TextAsset wordlist;

    public List<Button> allButtons;
    string[] upletters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    string[] rndletters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "QU" };
    string[] lowletters = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
    double[] weights = new double[] { 1, 1.25, 1.25, 1, 1, 1.25, 1, 1.25, 1, 1.75, 1.75, 1, 1.25, 1, 1, 1.25, 1.75, 1, 1, 1, 1, 1.5, 1.5, 2, 1.5, 2 };
    public int rnd, turn = 1;
    public string currentLetter;
    public double p1Health = 20, p2Health = 20, wordWeight = 0, attackStrength;
    private int f = 0;
    public string word;
    public bool result;
    public bool attackButtonOnOff = false;
    void Start()
    {
        allButtons[0].GetComponentInParent<Button>().onClick.AddListener(() => ButtonClicked(0));
        allButtons[1].GetComponentInParent<Button>().onClick.AddListener(() => ButtonClicked(1));
        allButtons[2].GetComponentInParent<Button>().onClick.AddListener(() => ButtonClicked(2));
        allButtons[3].GetComponentInParent<Button>().onClick.AddListener(() => ButtonClicked(3));
        allButtons[4].GetComponentInParent<Button>().onClick.AddListener(() => ButtonClicked(4));
        allButtons[5].GetComponentInParent<Button>().onClick.AddListener(() => ButtonClicked(5));
        allButtons[6].GetComponentInParent<Button>().onClick.AddListener(() => ButtonClicked(6));
        allButtons[7].GetComponentInParent<Button>().onClick.AddListener(() => ButtonClicked(7));
        allButtons[8].GetComponentInParent<Button>().onClick.AddListener(() => ButtonClicked(8));
        allButtons[9].GetComponentInParent<Button>().onClick.AddListener(() => ButtonClicked(9));
        allButtons[10].GetComponentInParent<Button>().onClick.AddListener(() => ButtonClicked(10));
        allButtons[11].GetComponentInParent<Button>().onClick.AddListener(() => ButtonClicked(11));
        allButtons[12].GetComponentInParent<Button>().onClick.AddListener(() => ButtonClicked(12));
        allButtons[13].GetComponentInParent<Button>().onClick.AddListener(() => ButtonClicked(13));
        allButtons[14].GetComponentInParent<Button>().onClick.AddListener(() => ButtonClicked(14));
        allButtons[15].GetComponentInParent<Button>().onClick.AddListener(() => ButtonClicked(15));
        allButtons[16].GetComponentInParent<Button>().onClick.AddListener(() => ButtonClicked(16));
        allButtons[17].GetComponentInParent<Button>().onClick.AddListener(() => ButtonClicked(17));
        allButtons[18].GetComponentInParent<Button>().onClick.AddListener(() => ButtonClicked(18));
        allButtons[19].GetComponentInParent<Button>().onClick.AddListener(() => ButtonClicked(19));
        allButtons[20].GetComponentInParent<Button>().onClick.AddListener(() => ButtonClicked(20));
        


        updateHealth();


        for (int i = 0; i < 16; i++)
        {
            allButtons[i].GetComponentInParent<Button>().interactable = false;

        }

        Letter_Gen();

    }
    // Update is called once per frame
    void Update()
    {

    }
    void updateHealth()
    {
        p1Hp.text = p1Health.ToString();
        p2Hp.text = p2Health.ToString();



    }
    void ButtonClicked(int buttonNumber)
    {
        if (buttonNumber == 17) { wordReset(); }
        if (buttonNumber == 18)
        {
            for (int i = 0; i < 16; i++)
            {
                allButtons[i].GetComponentInParent<Button>().interactable = false;
            }
            Letter_Gen();
            if (turn == 1)
            {

                turn = 2;

            }
            else if (turn == 2)
            {

                turn = 1;
            }
        }
        if(buttonNumber == 20){
           

        }
        if (buttonNumber == 16)
        {
            if (attackButtonOnOff == true)
            {
                attackStrength = wordWeight;

                if (attackStrength > 0)
                {
                    for (int i = 0; i < 16; i++)
                    {    //Amethyst calculations
                        if (!allButtons[i].GetComponentInParent<Button>().interactable && allButtons[i].GetComponentInParent<Button>().colors.normalColor == Color.magenta)
                        {
                            attackStrength = attackStrength * 1.15;
                            ColorBlock colors = allButtons[i].GetComponentInParent<Button>().colors;
                            colors.normalColor = Color.white;
                            allButtons[i].GetComponentInParent<Button>().colors = colors;

                        }
                        //Emerald Calculations
                        if (!allButtons[i].GetComponentInParent<Button>().interactable && allButtons[i].GetComponentInParent<Button>().colors.normalColor == Color.green)
                        {
                            attackStrength = attackStrength * 1.20;
                            ColorBlock colors = allButtons[i].GetComponentInParent<Button>().colors;
                            colors.normalColor = Color.white;
                            allButtons[i].GetComponentInParent<Button>().colors = colors;

                            if (turn == 1)
                            {
                                p1Health = p1Health + 2;
                                //p1hp.Width = Convert.ToInt32(122 * (p1Health / 20));
                            }
                            if (turn == 2)
                            {
                                p2Health = p2Health + 2;
                                // p2hp.Width = Convert.ToInt32(122 * (p2Health / 20));
                            }
                        }
                        //Sapphire Calculations
                        if (!allButtons[i].GetComponentInParent<Button>().interactable && allButtons[i].GetComponentInParent<Button>().colors.normalColor == Color.blue)
                        {
                            attackStrength = attackStrength * 1.25;
                            ColorBlock colors = allButtons[i].GetComponentInParent<Button>().colors;
                            colors.normalColor = Color.white;
                            allButtons[i].GetComponentInParent<Button>().colors = colors;

                        }
                        //Garnet Calculations
                        if (!allButtons[i].GetComponentInParent<Button>().interactable && allButtons[i].GetComponentInParent<Button>().colors.normalColor == new Color(277, 100, 16))
                        {
                            attackStrength = attackStrength * 1.30;
                            ColorBlock colors = allButtons[i].GetComponentInParent<Button>().colors;
                            colors.normalColor = Color.white;
                            allButtons[i].GetComponentInParent<Button>().colors = colors;

                        }
                        //Ruby Calculations
                        if (!allButtons[i].GetComponentInParent<Button>().interactable && allButtons[i].GetComponentInParent<Button>().colors.normalColor == Color.red)
                        {
                            attackStrength = attackStrength * 1.35;
                            ColorBlock colors = allButtons[i].GetComponentInParent<Button>().colors;
                            colors.normalColor = Color.white;
                            allButtons[i].GetComponentInParent<Button>().colors = colors;

                        }
                        //Crystal Calculations
                        if (!allButtons[i].GetComponentInParent<Button>().interactable && allButtons[i].GetComponentInParent<Button>().colors.normalColor == new Color(237, 85, 85))
                        {
                            attackStrength = attackStrength * 1.50;
                            ColorBlock colors = allButtons[i].GetComponentInParent<Button>().colors;
                            colors.normalColor = Color.white;
                            allButtons[i].GetComponentInParent<Button>().colors = colors;

                        }
                        //Diamond Calculations
                        if (!allButtons[i].GetComponentInParent<Button>().interactable && allButtons[i].GetComponentInParent<Button>().colors.normalColor == Color.cyan)
                        {
                            attackStrength = attackStrength * 2;
                            ColorBlock colors = allButtons[i].GetComponentInParent<Button>().colors;
                            colors.normalColor = Color.white;
                            allButtons[i].GetComponentInParent<Button>().colors = colors;

                        }
                    }
                }//Gem addition
                if (attackStrength > 0)
                {
                    if (word.Length == 5)
                    {
                        addGemAmethyst();
                    }
                    if (word.Length == 6)
                    {
                        addGemEmerald();
                    }
                    if (word.Length == 7)
                    {
                        addGemSaphire();
                    }
                    if (word.Length == 8)
                    {
                        addGemGarnet();
                    }
                    if (word.Length == 9)
                    {
                        addGemRuby();
                    }
                    if (word.Length == 10)
                    {
                        addGemCrystal();
                    }
                    if (word.Length >= 11)
                    {
                        addGemDiamond();
                    }
                }
                switch (turn)
                {
                    case 1:

                        p2Health = p2Health - attackStrength;
                        //p2hp.Width = Convert.ToInt32(122 * (p2Health / 20));
                        //pictureBox2.Image = mikeWazokOof;
                        //label2.Text = ((p2Health / 20) * 100).ToString()+"%" ;

                        //timer1.Enabled = true;
                        attackButtonOnOff = false;
                        //turner.Text = "→";
                        turn = 2;
                        Debug.Log(turn.ToString());

                        break;

                    case 2:
                        p1Health = p1Health - attackStrength;
                        // p1hp.Width = Convert.ToInt32(122 * (p1Health / 20));
                        //pictureBox1.Image = sansOof;
                        //label1.Text = ((p1Health / 20) * 100).ToString() + "%";

                        // timer1.Enabled = true;
                        attackButtonOnOff = false;
                        //turner.Text = "←";
                        turn = 1;
                        Debug.Log(turn.ToString());
                        break;


                }


                if (p2Health <= 0)
                {
                    p2Health = 0;

                    attackWord.text = "PLAYER ONE WINS!";
                    for (int sans = 0; sans < 19; sans++)
                    {
                        allButtons[sans].GetComponentInParent<Button>().interactable = false;
                    }
                    allButtons[19].GetComponentInParent<Image>().enabled = true;
                    allButtons[19].GetComponentInChildren<TextMeshProUGUI>().enabled = true;
                    allButtons[20].GetComponentInParent<Image>().enabled = true;
                    allButtons[20].GetComponentInChildren<TextMeshProUGUI>().enabled = true;
                   
                    
                }
                if (p1Health <= 0)
                {
                    p1Health = 0;

                    attackWord.text = "PLAYER TWO WINS!";
                    for (int sans = 0; sans < 19; sans++)
                    {
                        allButtons[sans].GetComponentInParent<Button>().interactable = false;
                    }
                    allButtons[19].GetComponentInParent<Image>().enabled = true;
                    allButtons[19].GetComponentInChildren<TextMeshProUGUI>().enabled = true;
                    allButtons[20].GetComponentInParent<Image>().enabled = true;
                    allButtons[20].GetComponentInChildren<TextMeshProUGUI>().enabled = true;
                    
                }
                if (p1Health != 0 && p2Health != 0){
                Letter_Gen();}
                updateHealth();
                
            }
        }



        if (allButtons[buttonNumber].GetComponentInParent<Button>().interactable == true && buttonNumber <= 15)
        {
            attackWord.text = attackWord.text + allButtons[buttonNumber].GetComponentInChildren<TextMeshProUGUI>().text;
            allButtons[buttonNumber].GetComponentInParent<Button>().interactable = false;
            wordUpdate();
        }


    }
    private void wordReset()
    {
        //Resets the word, used very often
        attackWord.text = "";
        for (int i = 0; i < 16; i++)
        {
            allButtons[i].GetComponentInParent<Button>().interactable = true;
        }
        wordWeight = 0;
        attackButtonOff();
    }
    private void Letter_Gen()
    {//Generate letters only for tiles used last turn
        for (int i = 0; i < 16; i++)
        {


            if (allButtons[i].GetComponentInParent<Button>().interactable == false)
            {
                rnd = UnityEngine.Random.Range(0, 26);
                allButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = rndletters[rnd];
            }
        }
        wordReset();
    }
    private void attackButtonOn()
    {
        //Switch the attack button to on
        wordWeight = 0;
        attackButtonOnOff = true;

        ColorBlock colors = allButtons[16].GetComponentInParent<Button>().colors;
        colors.normalColor = Color.green;
        allButtons[16].GetComponentInParent<Button>().colors = colors;
        // attackButton.BackColor = Color.Lime;
        // attackButton.ForeColor = Color.Black;
    }
    private void attackButtonOff()
    {
        //Sets the attack button to off
        attackButtonOnOff = false;
        ColorBlock colors = allButtons[16].GetComponentInParent<Button>().colors;
        colors.normalColor = Color.red;
        allButtons[16].GetComponentInParent<Button>().colors = colors;

    }
    private void wordUpdate()
    {


        //Check for a real word


        switch (checkWord())
        {


            case true:
                {
                    if (word.Length > 2)
                    {
                        attackButtonOn();

                        for (int k = 0; k < word.Length; k++)
                        {
                            currentLetter = word.Substring(k, 1);
                            for (int frick = 0; frick < upletters.Length; frick++)
                            {
                                if (currentLetter == upletters[frick] || currentLetter == lowletters[frick])
                                {
                                    wordWeight = wordWeight + weights[frick];

                                }
                            }
                        }
                    }
                    break;
                }
            case false:

                attackButtonOff();
                break;

        }

    }


    private bool checkWord()
    {

        string[] words = wordlist.text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        word = attackWord.text;
        word = word.ToLower();

        for (int i = 0; i < words.Length; i++)
        {
            result = (word == words[i]);
            if (result == true)
            {

                break;


            }



        }
        return result;
    }
    private void addGemAmethyst()
    {
        //Add amethyst gem to a random tile
        rnd = UnityEngine.Random.Range(0, 16);
        ColorBlock colors = allButtons[rnd].GetComponentInParent<Button>().colors;
        colors.normalColor = Color.magenta;
        allButtons[rnd].GetComponentInParent<Button>().colors = colors;
    }
    private void addGemDiamond()
    {
        //Add diamond gem to a random tile
        rnd = UnityEngine.Random.Range(0, 16);

        ColorBlock colors = allButtons[rnd].GetComponentInParent<Button>().colors;
        colors.normalColor = Color.cyan;
        allButtons[rnd].GetComponentInParent<Button>().colors = colors;
    }

    private void addGemCrystal()
    {
        //Add crystal gem to a random tile
        rnd = UnityEngine.Random.Range(0, 16);
        ColorBlock colors = allButtons[rnd].GetComponentInParent<Button>().colors;
        colors.normalColor = new Color(237, 85, 85);
        allButtons[rnd].GetComponentInParent<Button>().colors = colors;
    }
    private void addGemRuby()
    {
        //Add ruby gem to a random tile
        rnd = UnityEngine.Random.Range(0, 16);
        ColorBlock colors = allButtons[rnd].GetComponentInParent<Button>().colors;
        colors.normalColor = Color.red;
        allButtons[rnd].GetComponentInParent<Button>().colors = colors;
    }

    private void addGemGarnet()
    {
        //Add garnet gem to a random tile
        rnd = UnityEngine.Random.Range(0, 16);
        ColorBlock colors = allButtons[rnd].GetComponentInParent<Button>().colors;
        colors.normalColor = new Color(277, 100, 16);
        allButtons[rnd].GetComponentInParent<Button>().colors = colors;
    }

    private void addGemSaphire()
    {
        //Add saphire gem to a random tile
        rnd = UnityEngine.Random.Range(0, 16);
        ColorBlock colors = allButtons[rnd].GetComponentInParent<Button>().colors;
        colors.normalColor = Color.blue;
        allButtons[rnd].GetComponentInParent<Button>().colors = colors;
    }

    private void addGemEmerald()
    {
        //Add emerald gem to a random tile
        rnd = UnityEngine.Random.Range(0, 16);
        ColorBlock colors = allButtons[rnd].GetComponentInParent<Button>().colors;
        colors.normalColor = Color.green;
        allButtons[rnd].GetComponentInParent<Button>().colors = colors;
    }

}
