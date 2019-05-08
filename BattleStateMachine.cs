using System;

public class BattleStateMachine {

  public enum BattleStates {
    START,
    PLAYER,
    ENEMY,
    ACTION,
    WIN,
    LOSE
  }

  private BattleStates currentState = BattleStates.START;

  public BattleStates CurrentState {
    get
    {
      return currentState;
    }
  }

  public void changeState() {
    if (currentState == BattleStates.START) {
      currentState = BattleStates.PLAYER;
      Console.WriteLine("State is now " + currentState + "\n");
    } else if (currentState == BattleStates.PLAYER) {
      currentState = BattleStates.ENEMY;
      Console.WriteLine("State is now " + currentState + "\n");
    } else if (currentState == BattleStates.ENEMY) {
      currentState = BattleStates.ACTION;
      Console.WriteLine("State is now " + currentState + "\n");
    } else if (currentState == BattleStates.ACTION) {
      currentState = BattleStates.PLAYER;
      Console.WriteLine("State is now " + currentState + "\n");
    }
  }

  public void changeState(bool victory) {
    if (victory == true) {
      currentState = BattleStates.WIN;
      Console.WriteLine("State is now " + currentState);
    } else if (victory == false) {
      currentState = BattleStates.LOSE;
      Console.WriteLine("State is now " + currentState);
    }
  }



}
