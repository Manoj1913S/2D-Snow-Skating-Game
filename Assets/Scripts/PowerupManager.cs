using UnityEngine;

public class PowerupManager : MonoBehaviour
{
  [SerializeField] PowerupSO powerup;

   PlayerController player;
   SpriteRenderer spriteRenderer;
   float timeLeft;


  void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        timeLeft = powerup.GetTime(); //time start
    }

    void Update()
    {
       CountDownTimer();
    }

    void CountDownTimer()
    {
          if(spriteRenderer.enabled == false)
        {
            if(timeLeft > 0)
            {
                 timeLeft -= Time.deltaTime;
                 if(timeLeft <= 0)
                {
                    print("Times UP");  //Deactivate the power
                    player.DeactivatePowerup(powerup);
                }
            }
           
        }
    }

   
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player"); //to check player touch Power-up or not 
        if(collision.gameObject.layer == layerIndex && spriteRenderer.enabled == true)
        {
            spriteRenderer.enabled = false;
             //Activate the power-up
             player.ActivatePowerup(powerup);
        }
    }
}
