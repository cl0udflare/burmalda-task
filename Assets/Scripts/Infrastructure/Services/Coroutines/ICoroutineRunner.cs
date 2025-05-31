using System.Collections;
using UnityEngine;

namespace Infrastructure.Services.Coroutines
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator routine);
    }
}