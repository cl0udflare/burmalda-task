using System.Collections;
using UnityEngine;

namespace Services.CoroutineRunner
{
    public interface ICoroutineRunnerService
    {
        Coroutine StartCoroutine(IEnumerator routine);
    }
}