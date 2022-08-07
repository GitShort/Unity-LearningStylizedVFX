using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class CharacterController : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] VisualEffect[] effect;

    [SerializeField] VisualEffect swordSlashVFX;
    [SerializeField] VisualEffect swordHitVFX;

    bool isCastingAbility = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (anim != null)
        {
            if (!isCastingAbility)
            {
                ButtonPress(KeyCode.Space, "levelUp", 0);
                ButtonPress(KeyCode.Q, "qCast", 1);
                ButtonPress(KeyCode.W, "wCast", 2);
                ButtonPress(KeyCode.E, "eCast", 3);
                ButtonPress(KeyCode.R, "rCast", 4);
            }
        }
    }

    void ButtonPress(KeyCode button, string trigger, int effectNum)
    {
        if(Input.GetKeyDown(button))
        {
            anim.SetTrigger(trigger);
            if (effect[effectNum] != null)
                effect[effectNum].Play();

            isCastingAbility = true;
            StartCoroutine(AbilityCooldown());
        }
    }

    IEnumerator AbilityCooldown()
    {
        yield return new WaitForSeconds(2f);
        isCastingAbility = false;
    }

    public void SwordEffect()
    {
        if (swordSlashVFX != null)
            swordSlashVFX.Play();
    }

    public void SwordHitEffect()
    {
        if (swordHitVFX != null)
            swordHitVFX.Play();
    }
}
