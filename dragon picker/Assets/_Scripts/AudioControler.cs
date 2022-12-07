using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControler : MonoBehaviour
{
    public AudioSource auidio_;
    
    private void Start()
    {
        if(!PlayerPrefs.HasKey("volume"))
         {
            auidio_.volume = 1;
         }
    }

    // Update is called once per frame
    private void Update()
    {
        auidio_.volume = PlayerPrefs.GetFloat("volume");
    }
}
