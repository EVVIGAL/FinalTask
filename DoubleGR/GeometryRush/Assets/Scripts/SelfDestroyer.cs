using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyer : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
