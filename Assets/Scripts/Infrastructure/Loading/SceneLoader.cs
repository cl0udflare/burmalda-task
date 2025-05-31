﻿using System;
using System.Collections;
using Infrastructure.Services.Coroutines;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Loading
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner) => 
            _coroutineRunner = coroutineRunner;

        public void LoadScene(string name, Action onLoaded = null) => 
            _coroutineRunner.StartCoroutine(Load(name, onLoaded));

        private IEnumerator Load(string nextScene, Action onLoaded)
        {
            if (SceneManager.GetActiveScene().name == nextScene)
            {
                onLoaded?.Invoke();
                yield break;
            }

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

            while (waitNextScene is { isDone: false })
                yield return null;

            onLoaded?.Invoke();
        }
    }
}