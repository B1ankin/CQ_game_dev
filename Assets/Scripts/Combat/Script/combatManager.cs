/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class combatManager : MonoBehaviour
{
    #region Properties

    public GameObject backBtn;

    *//*    // 4 combate HUD
    public combat_HUD hud1;
    public combat_HUD hud2;
    public combat_HUD hud3;
    public combat_HUD hud4;*//*

    // Battle field unit
    public GameObject player1_UI;
    public GameObject player2_UI;
    public GameObject player3_UI;
    public GameObject player4_UI;

    public GameObject NPC1_UI;
    public GameObject NPC2_UI;
    public GameObject NPC3_UI;
    public GameObject NPC4_UI;

    public combat_char player1;
    public combat_char player2;
    public combat_char player3;
    public combat_char player4;

    //public List<combat_char> playerSide;

    public combat_char NPC1;   
    public combat_char NPC2;
    public combat_char NPC3;
    public combat_char NPC4;

    //public List<combat_char> enemySide;

    // select space
    public GameObject npcselect1;


    //info slots
    public GameObject stat;
    public GameObject item;
    public GameObject item2;
    public GameObject infoImage;

    //UI
    public GameObject charImage;
    public GameObject skipbtn;
    public GameObject skillbtn1;
    public GameObject skillbtn2;
    public GameObject skillbtn3;
    public GameObject skillbtn4;
    public GameObject skillbtn5;
    public GameObject skillbtn6;


    // PopUp dialog
    public Text dialogueText;

    //The states of the whole battle
    public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

    public BattleState state;

    public Queue<combat_char> battleQueue;

    private combat_char current_char;
    private GameObject current_char_pos;
    #endregion



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Battle Start -- 0");
        battleQueue = new Queue<combat_char>();
        state = BattleState.START;
        StartCoroutine(SetupBattle());
        
    }

    IEnumerator SetupBattle()
    {
        Debug.Log("Battle Setup -- 1");
        //read battle info from an initil
        *//* GameObject en



          GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
          enemyUnit = enemyGO.GetComponent<Unit>();

          //update pop dialog
          dialogueText.text = "A wild " + enemyUnit.unitName + " approaches...";

          playerHUD.SetHUD(playerUnit);
          enemyHUD.SetHUD(enemyUnit);*//*
        battleQueue.Enqueue(player1);
        player1_UI.GetComponent<combat_avatar>().setChar(player1);
        player1_UI.GetComponent<RawImage>().texture = player1.charAvatar;
        battleQueue.Enqueue(NPC4);
        NPC4_UI.GetComponent<combat_avatar>().setChar(NPC4);
        NPC4_UI.GetComponent<RawImage>().texture = NPC4.charAvatar;


        yield return new WaitForSeconds(2f);

        //check the queue
        checkNext();

    }
    
    IEnumerator EnemyTurn()
    {
        Debug.Log("EnemyTurn");
        yield return new WaitForSeconds(1f);

        // following ai perfrom actions
        player1.hp = player1.hp - 5;
        Debug.Log("Player take dmg 5");
        Debug.Log("Player current hp" + player1.hp);
    }   

    void PlayerTurn()
    {
        Debug.Log("PlayerTurn");
        Debug.Log("CurrentChar"+ current_char.charName);
        charImage.GetComponent<RawImage>().texture = current_char.charAvatar;

        *//* dialogueText.text = "你的回合";*//*
        //更新界面UI
        //skills
        List<Skill> skills = current_char.carrySkill;
        int len = skills.Count;
        if (skills[0]) skillbtn1.GetComponent<skill_button>().setCurSkill(skills[0]);
        //TODO other 5 skills
        //items



        // waiting action
        Debug.Log("Wating player action ........");

    }

    public void castSkill(int pos)
    {
        Debug.Log("Skill targeting" + pos);
        if (pos == 4) npcselect1.SetActive(false);

        Debug.Log("cast Damage 5 hp"); //TODO repalce with effect

        checkNext();
    }


    void checkNext()
    {
        current_char = battleQueue.Dequeue();
        Debug.Log(battleQueue.Count);
        if (current_char.ai_type != 0)
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn()); 
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }



    #region supports
    int checkChar() 
    {
        //check died
        if (current_char.char_data.hp <= 0) return 0;
        //check buff


        //return final state
        return 1;


        //rearrange the Queue when Player's or NPC's Speed changed
        static void Queue_Update()
        {
            
        }
    }
    #endregion



}
*/