using UnityEngine;
using UnityEngine.InputSystem.Interactions;


public class Fight
{
    private Inhabitant attacker;
    private Inhabitant defender;
    private Monster theMonster;

    private bool fightOver = false;
    private GameObject playerGO;
    private GameObject monsterGO;

    public Fight(Monster m)
    {
        this.theMonster = m;

        //initially determine who goes first
        int roll = Random.Range(0, 20) + 1;
        if (roll <= 10)
        {
            Debug.Log("Monster goes first");
            this.attacker = m;
            this.defender = Core.thePlayer;
        }
        else
        {
            Debug.Log("Player goes first");
            this.attacker = Core.thePlayer;
            this.defender = m;
        }

    }
    
 public void startFight(GameObject playerGameObject, GameObject monsterGameObject)
    {
        this.playerGO = playerGameObject;
        this.monsterGO = monsterGameObject;
    }

 

    public void takeASwing ()
    {
        if (fightOver) return;

            int attackRoll = Random.Range(0, 20) + 1;
            Debug.Log("Attack Roll: " + attackRoll);
            Debug.Log("Defender AC: " + this.defender.getAC());

            
            if(attackRoll >= this.defender.getAC())
            {
                //attacker hits the defender
                int damage = Random.Range(1, 6); //1 to 5 damage

                this.defender.takeDamage(damage);
                Debug.Log(this.attacker.getName() + " hits " + this.defender.getName() + " for " + damage + " damage!");

                if(this.defender.isDead())
                {
                    this.fightOver = true;
                    Debug.Log(this.attacker.getName() + " killed " + this.defender.getName());
                    if(this.defender is Player)
                    {
                        //player died
                        Debug.Log("Player died");
                        //end the game
                        playerGO.SetActive(false); //hide the player
                    }
                    else
                    {
                    Debug.Log("Monster died");
                        GameObject.Destroy(monsterGO);
                    }
                   return;
                }
            }
            else
            {
                Debug.Log(this.attacker.getName() + " missed " + this.defender.getName());
            }
            Inhabitant temp = this.attacker;
            this.attacker = this.defender;
            this.defender = temp;
        }
        public bool isFightOver()
        {
            return this. fightOver;
        }
}
