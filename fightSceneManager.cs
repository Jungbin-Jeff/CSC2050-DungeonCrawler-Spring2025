
using UnityEngine;

public class FightSceneManager : MonoBehaviour
{
    public GameObject player;
    public GameObject monster;

private Fight fight;
private float timeSinceLastAttack = 0f;

void Start()
{
    Monster monsterScript = monster. GetComponent<Monster>();
    fight = new Fight (monsterScript);
    fight.startFight(player, monster);

    Debug.Log("Player AC: " + Core.thePlayer.getAC());
    Debug.Log("Monster AC: " + monsterScript.getAC());
    
}

void Update()
{
    if (fight.isFightOver()) return;

    timeSinceLastAttack += Time.deltaTime;
    
    if (timeSinceLastAttack >= 1.0f)
    {
    
            fight.takeASwing();
            timeSinceLastAttack = 0f;
        }
    }

}

    
