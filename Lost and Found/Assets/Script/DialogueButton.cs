using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueButton : MonoBehaviour
{
    public Coroutine co;
    public Text displayText;
    public GameObject characterButton;

    private enum MessageState { Empty, Typing, Complete }
    private MessageState currentState;
    private string sentence;

    private void Awake()
    {
        currentState = MessageState.Empty;
    }

    private void OnEnable()
    {
        currentState = MessageState.Empty;
    }

    public void OnClick()
    {
        if (currentState == MessageState.Empty)
        {
            sentence = DialogueManager.Instance.GetNextSentence();
            currentState = MessageState.Typing;
            co = StartCoroutine(DisplayMessage(sentence));
        }
        else if (currentState == MessageState.Typing)
        {
            displayText.text = sentence;
            currentState = MessageState.Complete;
            StopCoroutine(co);
        }
        else
        {
            currentState = MessageState.Empty;
            characterButton.GetComponent<Button>().interactable = true;
            gameObject.SetActive(false);
        }
    }

    IEnumerator DisplayMessage(string message)
    {
        int i = 1;
        string display = "";
        while (display != message)
        {
            display = message.Substring(0, i);
            displayText.text = display;
            i++;
            yield return new WaitForSecondsRealtime(0.02f);
        }
            currentState = MessageState.Complete;
        yield return null;
    }
}
