using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAttack : MonoBehaviour
{
    public GameObject sword;
    public GameObject swordSprite;

    public GameObject scythe;
    public GameObject scytheSprite;

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
        swordSprite.transform.RotateAround(transform.position, Vector3.forward, angle);
        StartCoroutine(activateSword());
    }

    IEnumerator activateSword()
    {
        sword.SetActive(true);
        swordSprite.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        sword.SetActive(false);
        yield return new WaitForSeconds(0.05f);
        swordSprite.SetActive(false);
    }

    public void scytheAttack()
    {
        Vector3 rotation = scythe.transform.right;
        float angle = Vector3.Angle(rotation, getMouseDirection());
        Vector3 cross = Vector3.Cross(rotation, getMouseDirection());
        if (cross.z < 0)
        {
            angle = -angle;
        }

        scythe.transform.RotateAround(transform.position, Vector3.forward, angle);
        scytheSprite.transform.RotateAround(transform.position, Vector3.forward, angle);
        StartCoroutine(activateScythe());
    }

    IEnumerator activateScythe()
    {
        scythe.SetActive(true);
        scytheSprite.SetActive(true);

        int numLoops = 10;
        int angleDelta = 7;
        for (int i = 0; i < numLoops; i++)
        {
            yield return new WaitForSeconds(0.005f);
            scytheSprite.transform.RotateAround(transform.position, Vector3.forward, -angleDelta);
        }

        yield return new WaitForSeconds(0.05f);
        scythe.SetActive(false);

        yield return new WaitForSeconds(0.05f);
        scytheSprite.transform.RotateAround(transform.position, Vector3.forward, angleDelta * numLoops);
        scytheSprite.SetActive(false);
    }
}
