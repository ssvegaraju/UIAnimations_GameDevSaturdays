using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour {

    public int currentIndex = 0;
    [SerializeField] int maxIndices;
    bool keyDown = false;
    public TMP_Dropdown resolutions;

    public GameObject startMenu;
    public GameObject optionsMenu;

    private int lastRes = 0;

    public static MainMenuManager instance;

    private void Awake() {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start() {
        resolutions = FindObjectOfType<TMP_Dropdown>();
        StartMenu();
    }

    // Update is called once per frame
    void Update () {
        float vertical = Input.GetAxis("Vertical");

        if (vertical != 0) {
            if (!keyDown) {
                if (vertical > 0) {
                    if (currentIndex == 0) {
                        currentIndex = maxIndices;
                    } else {
                        currentIndex--;
                    }
                } else {
                    if (currentIndex < maxIndices) {
                        currentIndex++;
                    } else {
                        currentIndex = 0;
                    }
                }
                keyDown = true;
            }
        } else {
            keyDown = false;
        }
	}

    public void NewGame() {
        StartCoroutine(StartNewGame());
    }

    public void Quit() {
        StartCoroutine(QuitGame());
    }

    public void Options() {
        optionsMenu.SetActive(true);
        startMenu.SetActive(false);
    }

    public void StartMenu() {
        startMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void OnMasterVolumeUpdate(float value) {
        // Adjust audio levels
    }

    public void SetFullscreen(bool value) {
        if (value) {
            resolutions.interactable = false;
            Resolution[] allResolution = Screen.resolutions;
            Resolution maxRes = allResolution[allResolution.Length - 1];
            Screen.SetResolution(maxRes.width, maxRes.height, true);
        } else {
            resolutions.interactable = true;
            SetScreenResolution(lastRes);
        }
    }

    public void SetScreenResolution(int index) {
        string[] res = resolutions.options[index].text.Split('x');
        Screen.SetResolution(int.Parse(res[0].Trim()), int.Parse(res[1].Trim()), false);
        lastRes = index;
    }

    IEnumerator StartNewGame() {
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene("Level1");
    }

    IEnumerator QuitGame() {
        yield return new WaitForSeconds(0.6f);
        Application.Quit();
    }
}
