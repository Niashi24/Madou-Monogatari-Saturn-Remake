using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Script")]
public class DialogueScript : ScriptableObject
{
    [SerializeField]
    List<LocalizedPiece> _script;

    public List<LocalizedPiece> Script => _script;
}
