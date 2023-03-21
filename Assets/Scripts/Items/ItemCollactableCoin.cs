using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableCoin : ItemCollactableBase
{
    public float lerp = 9f;
    public float minDistance = 1f;
    public bool collect = false;

    protected override void OnCollect()
    {
        base.OnCollect();
        collect = true;
    }

    protected override void Collect()
    {
        OnCollect();
    }

    private void Update()
    {
        if (collect)
        {
            transform.position = Vector3.Lerp(transform.position, PlayerController.Instance.transform.position, lerp * Time.deltaTime);
            
            if (Vector3.Distance(transform.position, PlayerController.Instance.transform.position) < minDistance)
                HideItens();
        }
    }
}
