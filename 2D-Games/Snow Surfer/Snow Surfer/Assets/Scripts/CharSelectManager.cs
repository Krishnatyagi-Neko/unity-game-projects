using UnityEngine;
using UnityEngine.U2D.IK;

public class CharSelectManager : MonoBehaviour
{

    [SerializeField] GameObject scoreCanvas;
    [SerializeField] GameObject dinoSprite;
    [SerializeField] GameObject yumikoSprite;

    void Start()
    {
        Time.timeScale = 0;
    }

    void BeginGame()
    {
        Time.timeScale = 1f;
        scoreCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ChooseDino()
    {
        dinoSprite.SetActive(true);
        BeginGame();
        scoreCanvas.SetActive(true);
    }

    public void ChooseYumiko()
    {
        yumikoSprite.SetActive(true);
        BeginGame();
        scoreCanvas.SetActive(true);
    }
}
