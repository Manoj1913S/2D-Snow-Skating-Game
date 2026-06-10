using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float restartDelay = 1f;
    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] PlayerController playerController;
    


void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {  
          int layerIndex = LayerMask.NameToLayer("Floor");
        if(collision.gameObject.layer == layerIndex)
        { 
            playerController.DisableControl();
            crashParticles.Play();
            Invoke("ReloadScene" , restartDelay);
            Debug.Log("You are crashed  because your head touched ground so play again baby");
             
        }
    }

    void ReloadScene()
    {
         SceneManager.LoadScene(0);
    }
}
