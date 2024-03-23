using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{

    public SoundDescriptor descriptor;
    private AudioSource source;
    public bool playMenu;
    public bool playAmbient;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        if (source == null)
            source = gameObject.AddComponent<AudioSource>();

        if (playMenu)
            source.clip = descriptor.menu;
        else if (playAmbient)
            source.clip = descriptor.ambient;

        source.loop = true;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
