using System;
using System.Collections;
using UnityEngine;

namespace Infrastructure
{
    public class CoroutineRunner : MonoBehaviour
    {
        public void Run(IEnumerator enumerator)
        {
            if (enumerator == null) throw new ArgumentNullException(nameof(enumerator));
            StartCoroutine(enumerator);
        }

        public void Stop(IEnumerator enumerator)
        {
            StopCoroutine(enumerator);
        }
    }
}