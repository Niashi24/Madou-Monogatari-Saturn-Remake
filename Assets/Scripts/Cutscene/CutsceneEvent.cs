using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CutsceneEvent : ICutsceneRunner
{
    [SerializeReference]
    List<CutsceneAction> _actions;

    MonoBehaviour subjectMonobehavior;

    public IEnumerator Invoke(MonoBehaviour subject)
    {
        subjectMonobehavior = subject;

        CutsceneContext context = new()
        {
            Controller = this,
            actions = this._actions,
            currentIndex = 0
        };
        
        if (_actions.Count == 0)
            yield break;

        while (context.currentIndex < _actions.Count)
        {
            var action = _actions[context.currentIndex];

            // CurrentAction = action;

            yield return action.Execute(context);
            
            context.currentIndex = action.GetNextActionIndex(context);
        }
    }

    public Coroutine StartCoroutine(IEnumerator routine)
    {
        if (subjectMonobehavior is null)
        {
            Debug.LogError("Cannot start coroutine: subjectMonobehavior has not been assigned");
            return null;
        }

        return subjectMonobehavior.StartCoroutine(routine);
    }

    public void StopCutscene()
    {
        if (subjectMonobehavior is null)
            Debug.LogError("Cannot stop cutscene: subjectMonobehavior has not been assigned");
        else
            subjectMonobehavior.StopCoroutine(nameof(Invoke));
    }
}
