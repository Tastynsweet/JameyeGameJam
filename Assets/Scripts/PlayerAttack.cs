using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject sword;

    private Vector3 getMouseDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.x -= Screen.width/2;
        mousePos.y -= Screen.height/2;
        return mousePos - transform.position;
    }

    public void basicSwordAttack()
    {
        Vector3 rotation = sword.transform.right;
        float angle = Vector3.Angle(rotation, getMouseDirection());
        Vector3 cross = Vector3.Cross(rotation, getMouseDirection());
        if (cross.z < 0)
        {
            angle = -angle;
        }

        sword.transform.RotateAround(transform.position, Vector3.forward, angle);
        StartCoroutine(activateSword());
    }

    IEnumerator activateSword()
    {
        sword.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        sword.SetActive(false);
    }
}
