using System.Collections;
using TMPro;
using UnityEngine;

public class TypeWriter : MonoBehaviour
{
    public TextMeshProUGUI storyText;
    [TextArea(5, 10)] public string fullText;
    public float charDelay = 0.05f;
    public float sentenceDelay = 1f;

    public AudioClip typeSound;
    public AudioClip sentenceEndSound;
    public GameObject uiPanelToClose;

    private AudioSource audioSource;
    private string cursorChar = "|";
    private Coroutine blinkCoroutine;
    private bool cursorVisible = true;

    public ParallelInputManager inputManager;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(TypeSentences());
    }

    IEnumerator TypeSentences()
    {
        storyText.text = "";
        string[] sentences = fullText.Split('\n');

        for (int i = 0; i < sentences.Length; i++)
        {
            string sentence = sentences[i].Trim();

            if (typeSound != null)
            {
                audioSource.clip = typeSound;
                audioSource.loop = true;
                audioSource.Play();
            }

            yield return StartCoroutine(TypeSentence(sentence));

            audioSource.Stop();

            if (sentenceEndSound != null)
                audioSource.PlayOneShot(sentenceEndSound);

            yield return new WaitForSeconds(sentenceDelay);

            if (i == sentences.Length - 1 && uiPanelToClose != null)
            {
                uiPanelToClose.SetActive(false);

                if (inputManager != null)
                    inputManager.EnableClones();
            }
        }

        StopCoroutine(blinkCoroutine);
        storyText.text = storyText.text.Replace(cursorChar, "");
    }

    IEnumerator TypeSentence(string sentence)
    {
        storyText.text = "";
        blinkCoroutine = StartCoroutine(CursorBlink());

        for (int i = 0; i <= sentence.Length; i++)
        {
            storyText.text = sentence.Substring(0, i) + (cursorVisible ? cursorChar : "");
            yield return new WaitForSeconds(charDelay);
        }

        StopCoroutine(blinkCoroutine);
        storyText.text = sentence;
    }

    IEnumerator CursorBlink()
    {
        while (true)
        {
            cursorVisible = !cursorVisible;
            yield return new WaitForSeconds(0.4f);
        }
    }
}
