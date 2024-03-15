using UnityEngine;

public class AdviserAnomaly : MonoBehaviour
{
    public float defeatTimeout = 15f;
    public GameObject player;

    private PlayerHP playerHP;
    private bool hasBeenDefeated;

    void Start()
    {
        playerHP = player.GetComponent<PlayerHP>(); // Get the PlayerHP component from the player GameObject
        Invoke("Fail", defeatTimeout); // Invoke Fail once after defeatTimeout seconds
    }

    void Fail()
    {
        if (!hasBeenDefeated) // Check if the enemy hasn't been defeated yet
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
