using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterByLetter : MonoBehaviour {

    public Text displayText;
    public float textSpeed = 1f;
    public float delayToNewPhrase = 3f;
    public List<string> phrases;


    public void PlayText()
    {
        displayText.text = "";
        StartCoroutine("ComposeText");
    }

    IEnumerator ComposeText()
    {
        foreach (var phrase in phrases)
        {
            string finalText = "";
            char[] charArray = new char[phrase.Length];

            for (int i = 0; i < charArray.Length; i++)
            {
                charArray[i] = phrase[i];

                finalText = finalText + charArray[i];
                displayText.text = finalText;

                yield return new WaitForSeconds(textSpeed);
            }

            yield return new WaitForSeconds(delayToNewPhrase);
        }

        


    }
}
