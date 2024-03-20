using UnityEngine;

public class AdviserAnomaly : MonoBehaviour
{
    public float defeatTimeout = 15f;
    
    private GameObject player;
    private PlayerHP playerHP;
    private bool hasBeenDefeated;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHP = player.GetComponent<PlayerHP>(); 
        Invoke("Fail", defeatTimeout); 
    }

    void Fail()
    {
        if (!hasBeenDefeated) 
        {
            playerHP.ReduceToMinimumHealth();
        }
    }

    public void Defeated()
    {
        hasBeenDefeated = true;
        CancelInvoke("Fail");
    }
}
