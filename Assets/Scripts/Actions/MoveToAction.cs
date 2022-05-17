using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class MoveToAction : CutsceneAction
{
    [SerializeField]
    GameObject _subject;

    [SerializeField]
    Vector3 _target;

    [SerializeField]
    float _speed;

    public override IEnumerator Execute(CutsceneContext context)
    {
        while (Vector3.Distance(_subject.transform.position, _target) != 0)
        {
            yield return null;
            _subject.transform.position = Vector3.MoveTowards(_subject.transform.position, _target, _speed * Time.deltaTime);
        }
    }
}
