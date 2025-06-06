using UnityEngine;
using UnityEngine.Events;

public partial class DialogueManager
{
    [System.Serializable]
    public struct DialoguePiece
    {
        public string name;
        
        public GameObject dialogueBox;
        
        public UnityEvent sentenceStartEvent;
        
        public UnityEvent sentenceEndEvent;
        
        public bool hasEvent;

        [TextArea(3, 10)]
        public string sentence;
    }
}
