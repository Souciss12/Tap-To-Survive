using UnityEngine;
using UnityEngine.UI;

public class TypingGame : MonoBehaviour
{
    public Text characterText; // Référence au texte à écrire
    public InputField inputField; // Champ de saisie
    public float characterSpeed = 5.0f; // Vitesse de descente
    public int playerHealth = 3; // Points de vie du joueur
    public Text PlayerHealth; // Texte des points de vie
    public float TimerCharacterInterval = 5.0f; // Intervalle pour ajouter un nouveau caractère

    private string currentCharacter; // Le caractère/mot en cours
    private Vector3 characterPosition; // Position du texte
    private float timer; // Minuteur pour ajouter un nouveau caractère

    void Start()
    {
        GenerateNewCharacter();
        PlayerHealth.text = "Health: " + playerHealth;
        timer = TimerCharacterInterval;
    }

    void Update()
    {
        characterPosition.y -= characterSpeed * Time.deltaTime;
        characterText.transform.position = characterPosition;

        if (characterPosition.y < 0)
        {
            playerHealth--;
            PlayerHealth.text = "Health: " + playerHealth;
            if (playerHealth <= 0)
            {
                GameOver();
            }
            else
            {
                GenerateNewCharacter();
            }
        }

        CheckInput();

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            GenerateNewCharacter();
            timer = TimerCharacterInterval;
        }
    }

    public void CheckInput()
    {
        if (inputField.text == currentCharacter)
        {
            inputField.text = "";
            GenerateNewCharacter();
        }
    }

    void GenerateNewCharacter()
    {
        currentCharacter = ((char)Random.Range(65, 91)).ToString(); // Caractère aléatoire A-Z
        characterText.text = currentCharacter;

        characterPosition = new Vector3(Random.Range(60, Screen.width - 60), Screen.height - Screen.height / 4, 0);
        characterText.transform.position = characterPosition;
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
    }
}
