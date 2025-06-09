using System;
using System.Collections.Generic;
using UnityEngine;
using static DialogueManager;
using UnityEngine.Events;

[Serializable]
public struct Dialogue
{
        [SerializeField] private List<DialoguePiece> _dialogues;
        public readonly List<DialoguePiece> Dialogues => _dialogues;

        [SerializeField] private UnityEvent _onDialogueEnd;
        public readonly void InvokeOnDialogueEnd() => _onDialogueEnd?.Invoke();

        [SerializeField] private bool _ignoreEffects;
        public readonly bool IgnoreEffects => _ignoreEffects;
}
