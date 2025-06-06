using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public partial class DialogueManager : MonoBehaviour
{

    [SerializeField] private TMPro.TMP_Text dialogueText;

    [SerializeField] private Animator dialogueAnimator;

    private Queue<string> sentences;

    [SerializeField] public float textSpeed;
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void ReadDescription(string description)
    {
        dialogueAnimator.SetBool("IsOpen", true);
        if (sentences != null)
        {
            sentences.Clear();
        }
        else
        {
            sentences = new Queue<string>();
        }

        sentences.Enqueue(description);

        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = sentence;
        dialogueText.ForceMeshUpdate();
        yield return null;
    }
    public void EndDialogue()
    {
        dialogueAnimator.SetBool("IsOpen", false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
