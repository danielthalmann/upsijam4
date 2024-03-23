using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sound Data", menuName = "Scriptable Objets/Sound Data", order = 0)]
public class SoundDescriptor : ScriptableObject
{
    public AudioClip ambient;
    public AudioClip menu;
    public AudioClip fxChicken;
    public AudioClip fxPush;

}