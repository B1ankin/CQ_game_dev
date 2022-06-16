using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    #region UI matching element
    public GameObject battlePosition1;
    public GameObject battlePosition2;
    public GameObject battlePosition3;
    public GameObject battlePosition4;
    public GameObject battlePosition5;
    public GameObject battlePosition6;
    public GameObject battlePosition7;
    public GameObject battlePosition8;

    public GameObject charSelectPosition1;
    public GameObject charSelectPosition2;
    public GameObject charSelectPosition3;
    public GameObject charSelectPosition4;
    public GameObject charSelectPosition5;
    public GameObject charSelectPosition6;
    public GameObject charSelectPosition7;
    public GameObject charSelectPosition8;
    
    public GameObject backButton;
    public GameObject skipButton;

    public GameObject ItemSlot;
    public GameObject statBlock;

    public GameObject skillButton1;
    public GameObject skillButton2;
    public GameObject skillButton3;
    public GameObject skillButton4;
    public GameObject skillButton5;
    public GameObject skillButton6;
    
    public GameObject itemButton1;
    public GameObject itemButton2;
    public GameObject itemButton3;
    public GameObject itemButton4;
    public GameObject itemButton5;
    public GameObject itemButton6;
    public GameObject itemButton7;
    public GameObject itemButton8;
    public GameObject itemButton9;
    public GameObject itemButton10;
    public GameObject itemButton11;
    public GameObject itemButton12;




    public GameObject charImage;

    public GameObject dialogueText;

    #endregion

    #region properties
    public List<CharacterData> playerdatas;
    public List<CharacterData> enemydatas;
    public List<GameObject> testList;

    public enum BattleState { START, PLAYERTURN, ENEMYTUYRN, WON, LOST}
    public BattleState state;
    public Queue<int> characterIndex;

    private CharacterData currentCharacter;
    private GameObject currentPos;
    private int currentPosIndex;
    characterCollection cc;

    #endregion

    void Start()
    {
        Debug.Log("Battle Start");
        characterIndex = new Queue<int>();
        cc = new characterCollection();

        state = BattleState.START;
        StartCoroutine(SetupBattle());

    }

    IEnumerator SetupBattle()
    {
        Debug.Log("Battle Setup");
        // load data from character, NPC & Enviroment
        //TEMP hard code
        playerdatas = new List<CharacterData>();
        playerdatas.Add(cc.Dict[0]);
        playerdatas.Add(cc.Dict[1]);
        playerdatas.Add(cc.Dict[2]);
        playerdatas.Add(cc.Dict[3]);
        enemydatas = new List<CharacterData>();
        enemydatas.Add(cc.Dict[6]);
        enemydatas.Add(cc.Dict[7]);
        enemydatas.Add(cc.Dict[8]);
        enemydatas.Add(cc.Dict[9]);
        yield return new WaitForSeconds(1);

        sortQueue();
        // check the next queue
        checkNext();
    }

    void checkNext()
    {
        int temp_pos = characterIndex.Dequeue();
        if (temp_pos < 5)
        {
            // player side
            currentCharacter = playerdatas[temp_pos];
            state = BattleState.PLAYERTURN;
            playerTurn();
        }
        else if (temp_pos > 5 & temp_pos < 9)
        {
            // enemy side
            currentCharacter = enemydatas[temp_pos - 4];
            StartCoroutine(EnemyTurn());
        }

    }

    void sortQueue()
    {
        for(int i =1; i < 9;i++)
        {
            characterIndex.Enqueue(i);
        }
    }

    void playerTurn()
    {
        Debug.Log("----------player turn");
        Debug.Log("Current player:: " + currentCharacter.Name);

        //dialogueText.GetComponent<Text>().text = "ÄãµÄ»ØºÏ";

        // update UI
        // skills - 6`
        List<Skill> skills = currentCharacter.skills; // TODO add skills to characte data
        /*if (skills[0]) skillButton1.GetComponent<SkillButton>().UpdateButton(skills[0]);
        if (skills[1]) skillButton2.GetComponent<SkillButton>().UpdateButton(skills[1]);
        if (skills[2]) skillButton3.GetComponent<SkillButton>().UpdateButton(skills[2]);
        if (skills[3]) skillButton4.GetComponent<SkillButton>().UpdateButton(skills[3]);
        if (skills[4]) skillButton5.GetComponent<SkillButton>().UpdateButton(skills[4]);
        if (skills[5]) skillButton6.GetComponent<SkillButton>().UpdateButton(skills[5]);*/

        // items - 10
        /*List<Item> items = currentCharacter.items;
        if( items[0]) itemButton1.GetComponent<ItemButton>().UpdateButton(items[0]);
        if( items[1]) itemButton2.GetComponent<ItemButton>().UpdateButton(items[1]);
        if( items[2]) itemButton3.GetComponent<ItemButton>().UpdateButton(items[2]);
        if( items[3]) itemButton4.GetComponent<ItemButton>().UpdateButton(items[3]);
        if( items[4]) itemButton5.GetComponent<ItemButton>().UpdateButton(items[4]);
        if( items[5]) itemButton6.GetComponent<ItemButton>().UpdateButton(items[5]);
        if( items[6]) itemButton7.GetComponent<ItemButton>().UpdateButton(items[6]);
        if( items[7]) itemButton8.GetComponent<ItemButton>().UpdateButton(items[7]);
        if( items[8]) itemButton9.GetComponent<ItemButton>().UpdateButton(items[8]);
        if( items[9]) itemButton10.GetComponent<ItemButton>().UpdateButton(items[9]);*/

        // Wating player action
        Debug.Log("Waiting player action");

   
    }

    // Will be called by skill button Onclick event from outside
    public void castSkill()
    {
        Debug.Log("Player casted spells");
        // hide all select support highlighters
        charSelectPosition1.SetActive(false);
        charSelectPosition2.SetActive(false);
        charSelectPosition3.SetActive(false);
        charSelectPosition4.SetActive(false);
        charSelectPosition5.SetActive(false);
        charSelectPosition6.SetActive(false);
        charSelectPosition7.SetActive(false);
        charSelectPosition8.SetActive(false);

        // move on next character
        checkNext();

    }


    IEnumerator EnemyTurn()
    {
        //check if enemy dead

        //check if all dead
        //if all dead , jump to winlost pause 
        yield return new WaitForSeconds(1);
        // perform action by data designed 
/*        switch(currentCharacter.ai){ //  TODO add ai 
            case 0:
                // random pick a player to cast skill
                Random.Range(1, 8);

                break;
            case 1:
                break;

        }*/


        checkNext();
    }



    #region support method

    #endregion
}
