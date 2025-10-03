using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject sword;

    private Vector3 getMouseDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        return mousePos - transform.position;
    }

    public void basicSwordAttack()
    {
        sword.transform.RotateAround(transform.position, Vector3.forward, 1);
        StartCoroutine(activateSword());
    }

    IEnumerator activateSword()
    {
        sword.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        sword.SetActive(false);
    }
}
