using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCounter : MonoBehaviour
{
    [SerializeField]
    int keys;
    Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        text.text = keys.ToString();
    }

    public int GetKeys()
    {
        return keys;
    }

    public void AddKey()
    {
        keys++;
    }

    public void ResetKeys()
    {
        keys = 0;
    }
}
