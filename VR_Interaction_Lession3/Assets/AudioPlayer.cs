using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables;

public class AudioPlayer : MonoBehaviour
{
    public VRTK_BaseControllable scrubbingLever;
    public VRTK_SnapDropZone recordDropZone;
    public Record currentRecord;
    public AudioSource audioSource;

    public Animator lidAnimator;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        scrubbingLever.ValueChanged += Scrub;
        recordDropZone.ObjectSnappedToDropZone += RecordAdded;
        recordDropZone.ObjectUnsnappedFromDropZone += RecordRemoved;
    }

    private void RecordRemoved(object sender, SnapDropZoneEventArgs e)
    {
        currentRecord = null;
        audioSource.Stop();
        lidAnimator.SetBool("open",true);
    }

    private void RecordAdded(object sender, SnapDropZoneEventArgs e)
    {
        currentRecord = e.snappedObject.GetComponent<Record>();
        audioSource.clip = currentRecord.clip;
        lidAnimator.SetBool("open" ,false);

    }

    private void Scrub(object sender, ControllableEventArgs e)
    {
        Debug.Log(e.value*10f);
        audioSource.time = Mathf.Lerp(0,audioSource.clip.length,e.value);
        audioSource.Play();
    }
}
