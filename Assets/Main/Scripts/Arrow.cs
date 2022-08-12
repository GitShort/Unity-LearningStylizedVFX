using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Arrow : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] VisualEffect arrowVFX;
    [SerializeField] VisualEffect arrowDissolve;
    [SerializeField] VisualEffect hitWallVFX;
    bool isWallHit = false;

    Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!isWallHit)
        {
            isWallHit = true;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            if (hitWallVFX != null)
                hitWallVFX.Play();
            DestroyArrow();
        }
    }

    void DestroyArrow()
    {
        StartCoroutine(DissolveArrow());
        Destroy(this.gameObject, 15f);
    }

    IEnumerator DissolveArrow()
    {
        yield return new WaitForSeconds(2f);
        anim.SetTrigger("DissolveArrow");
        arrowDissolve.Play();
        arrowVFX.enabled = false;
    }
}
