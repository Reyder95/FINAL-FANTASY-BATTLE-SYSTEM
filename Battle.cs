using System;

public class Battle {
  BattleStateMachine battleStates = new BattleStateMachine();
  private int playerHealth;
  private int enemyHealth;
  private int playerAttack;
  private int enemyAttack;
  private string playerAction;
  private string enemyAction;
  private bool battleEnd;
  private bool playerWin;

  public Battle(int pHealth, int pAttack, int eHealth, int eAttack)
  {
    playerHealth = pHealth;
    playerAttack = pAttack;
    playerAction = string.Empty;

    enemyHealth = eHealth;
    enemyAttack = eAttack;
    enemyAction = string.Empty;

    battleEnd = false;
    playerWin = false;
  }

  public void initiateBattle() {
    while (battleStates.CurrentState != BattleStateMachine.BattleStates.WIN || battleStates.CurrentState != BattleStateMachine.BattleStates.LOSE) {
      if (battleEnd == false) {
        battleStates.changeState();
      } else if (battleEnd == true) {
        battleStates.changeState(playerWin);
      }

      if (battleStates.CurrentState == BattleStateMachine.BattleStates.PLAYER) {
        Console.WriteLine("TEST: Player Turn");
        playerTurn();
      } else if (battleStates.CurrentState == BattleStateMachine.BattleStates.ENEMY) {
        Console.WriteLine("TEST: Enemy Turn");
        enemyTurn();
      } else if (battleStates.CurrentState == BattleStateMachine.BattleStates.ACTION) {
        battleStates.changeState();
      }
    }
  }

  public void playerTurn() {
    playerMenu();
  }

  public void enemyTurn() {
    attack("enemy");
  }

  public void playerMenu() {
    Console.WriteLine("It is your turn! Select an option from the list!\n");

    Console.WriteLine("Your Health: " + playerHealth);

    Console.WriteLine("Opponent Health: " + enemyHealth + "\n");

    Console.WriteLine("1. Attack [Not done]");
    Console.WriteLine("2. Guard [Not done]");
    Console.WriteLine("3. Item [Not Done]");
    Console.WriteLine("4. Run Away [Not Done]");
    string playerChoice = Console.ReadLine();

    if (playerChoice == "1") {
      attack("player");
    } else if (playerChoice == "2") {
      // Guard method here
    } else if (playerChoice == "3") {
      // Item method here
    } else if (playerChoice == "4") {
      // Run away method here
    }
  }

  public void attack(string attacker) {
    if (attacker == "player") {
      enemyHealth -= playerAttack;
      Console.WriteLine("You dealt " + playerAttack + " damage to the enemy!");
    } else if (attacker =="enemy") {
      playerHealth -= enemyAttack;
      Console.WriteLine("Enemy dealt " + enemyAttack + " damage to you");
    }

    battleCheck();
  }

  public void battleCheck() {
    if (playerHealth == 0) {
      playerWin = false;
      battleEnd = true;
    } else if (enemyHealth == 0) {
      playerWin = true;
      battleEnd = true;
    }
  }
}
