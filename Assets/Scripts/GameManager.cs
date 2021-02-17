using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject backgroundImage;
    public GameObject startbutton;
    public GameObject title;
    public GameObject image;

    public GameObject canvas;
    public GameObject events;

    public GameObject dialogueBox;
    public GameObject dialogueText;

    // Start is called before the first frame update
    void Start() 
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(canvas);
            DontDestroyOnLoad(events);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static GameManager Instance { get; private set; }

    public void startButton()
    {
        startbutton.SetActive(false);
        title.SetActive(false);
        StartCoroutine(LoadYourAsyncScene("JungleScene"));
    }

    public void GameOver()
    {
        startbutton.SetActive(true);
        title.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(ColorLerp(new Color(1, 1, 1, 1), 1));
    }

    IEnumerator ColorLerp(Color endValue, float duration)
    {
        float time = 0;
        Image sprite = backgroundImage.GetComponent<Image>();
        Image snailImage = image.GetComponent<Image>();
        Color startValue = sprite.color;

        while (time < duration)
        {
            sprite.color = Color.Lerp(startValue, endValue, time / duration);
            snailImage.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        sprite.color = endValue;
    }

    IEnumerator LoadYourAsyncScene(string scene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        StartCoroutine(ColorLerp(new Color(1, 1, 1, 0), 3));

    }


    public void StartDialogue(string text)
    {
        dialogueBox.SetActive(true);
        dialogueText.GetComponent<TextMeshProUGUI>().text = text;
    }

    public void HideDialogue()
    {
        dialogueBox.SetActive(false);
    }



}
