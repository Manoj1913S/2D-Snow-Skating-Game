using UnityEngine;

public class CharacterSelectionManager : MonoBehaviour
{
    [SerializeField] GameObject scoreCanvas; //component get  through refrence 
    [SerializeField] GameObject boySprite;
    [SerializeField] GameObject girlSprite;
    void Start()
    {
        Time.timeScale = 0; //for control game speed;
    }

  
   void ResumeGame()
    {
        Time.timeScale = 1f;
        scoreCanvas.SetActive(true);
        gameObject.SetActive(false);
    }
 
 public void ChooseBoyCharacter()
    {
        boySprite.SetActive(true);
        ResumeGame();
    }

    public void ChooseGirlCharacter()
    {
         girlSprite.SetActive(true);
         ResumeGame();
    }




}