using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] private RectTransform storyPanel;
    [SerializeField] private RectTransform settingsPanel;
    [SerializeField] private RectTransform creditsPanel;

    [Header("Settings")]
    private Vector2 storyPanelOpenedPosition;
    private Vector2 storyPanelClosedPosition;
    private Vector2 settingsPanelOpenedPosition;
    private Vector2 settingsPanelClosedPosition;
    private Vector2 creditsPanelOpenedPosition;
    private Vector2 creditsPanelClosedPosition;


    private void Start()
    {
        StoryPanelInitialize();
        SettingsPanelInitialize();
        CreditsPanelInitialize();
    }

    private void StoryPanelInitialize()
    {
        storyPanel.gameObject.SetActive(false);

        storyPanelOpenedPosition = Vector2.zero;
        storyPanelClosedPosition = new Vector2(-storyPanel.rect.width, 0);

        storyPanel.anchoredPosition = storyPanelClosedPosition;
    }

    public void StoryPanelCallback()
    {
        storyPanel.gameObject.SetActive(true);

        LeanTween.cancel(storyPanel);
        LeanTween.move(storyPanel, storyPanelOpenedPosition, 0.3f).setEase(LeanTweenType.easeInOutSine);
    }

    public void CloseStoryPanel()
    {
        LeanTween.cancel(storyPanel);
        LeanTween.move(storyPanel, storyPanelClosedPosition, 0.3f).setEase(LeanTweenType.easeInOutSine);

        LeanTween.delayedCall(0.3f, () => storyPanel.gameObject.SetActive(false));
    }

    private void SettingsPanelInitialize()
    {
        settingsPanel.gameObject.SetActive(false);

        settingsPanelOpenedPosition = Vector2.zero;
        settingsPanelClosedPosition = new Vector2(-settingsPanel.rect.width, 0);

        settingsPanel.anchoredPosition = settingsPanelClosedPosition;
    }

    public void SettingsPanelCallback()
    {
        settingsPanel.gameObject.SetActive(true);

        LeanTween.cancel(settingsPanel);
        LeanTween.move(settingsPanel, settingsPanelOpenedPosition, 0.3f).setEase(LeanTweenType.easeInOutSine);
    }

    public void CloseSettingsPanel()
    {
        LeanTween.cancel(settingsPanel);
        LeanTween.move(settingsPanel, settingsPanelClosedPosition, 0.3f).setEase(LeanTweenType.easeInOutSine);

        LeanTween.delayedCall(0.3f, () => settingsPanel.gameObject.SetActive(false));
    }

    private void CreditsPanelInitialize()
    {
        creditsPanel.gameObject.SetActive(false);

        creditsPanelOpenedPosition = Vector2.zero;
        creditsPanelClosedPosition = new Vector2(-creditsPanel.rect.width, 0);

        creditsPanel.anchoredPosition = creditsPanelClosedPosition;
    }

    public void CreditsPanelCallback()
    {
        creditsPanel.gameObject.SetActive(true);

        LeanTween.cancel(creditsPanel);
        LeanTween.move(creditsPanel, creditsPanelOpenedPosition, 0.3f).setEase(LeanTweenType.easeInOutSine);
    }

    public void CloseCreditsPanel()
    {
        LeanTween.cancel(creditsPanel);
        LeanTween.move(creditsPanel, creditsPanelClosedPosition, 0.3f).setEase(LeanTweenType.easeInOutSine);

        LeanTween.delayedCall(0.3f, () => creditsPanel.gameObject.SetActive(false));
    }
}
