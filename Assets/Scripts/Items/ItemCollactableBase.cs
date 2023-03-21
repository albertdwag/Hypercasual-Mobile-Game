using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem particles;
    public float timeToHide = 3f;
    public GameObject graphicItem;

    [Header("Sounds")]
    public AudioSource audioSource;

    private void Awake()
    {
        //if (particles != null) particles.transform.SetParent(null);
    }

    protected void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(compareTag))
            Collect();

        //gameObject.GetComponent<Collider>().enabled = false;
    }

    protected virtual void HideItens()
    {
        if (graphicItem != null) graphicItem.SetActive(false);
        Invoke("HideObject", timeToHide);
    }

    protected virtual void Collect()
    {
        HideItens();
        OnCollect();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {
        if (particles != null) particles.Play();
        if (audioSource != null) audioSource.Play();
    }
}
