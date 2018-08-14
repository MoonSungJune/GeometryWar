using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntropyManager : MonoBehaviour {

    public int entropyMax = 9999;
    public Text entropyText;
    public float entropyUpDelay = 1f;

    public static int entropy = 0;


    private void Start()
    {
        Invoke("EntropyUp", entropyUpDelay);

    }

    void EntropyUp()
    {
        if (entropy < entropyMax)
        {
            entropy++;
        }
        Invoke("EntropyUp", entropyUpDelay);
    }

    void Update()
    {
        entropyText.text = entropy.ToString();
    }

}
