using UnityEngine;
using UnityEngine.UI;

public class Menu_Buttons : MonoBehaviour
{
    public Button playButton, xButton;
    public string website;
    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(GoToLink);
        xButton.onClick.AddListener(ExitMenu);
        gameObject.tag = "TempTag";
        GameObject[] panels = GameObject.FindGameObjectsWithTag("Panel");
        gameObject.tag = "Panel";
        foreach (GameObject panel in panels)
        {
            Destroy(panel);
        }
    }

    private void GoToLink()
    {
        Application.OpenURL(website);
    }

    private void ExitMenu()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
