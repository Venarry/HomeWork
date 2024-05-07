using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private const int CounterStep = 1;
    private const float StepCooldown = 0.5f;

    private int _count;
    private Coroutine _activeCoroutine;
    private WaitForSeconds _waitForSeconds = new(StepCooldown);

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _activeCoroutine = StartCoroutine(Counting());
        }
    }

    private IEnumerator Counting()
    {
        while (enabled)
        {
            yield return _waitForSeconds;
            _count += CounterStep;
        }
    }
}
