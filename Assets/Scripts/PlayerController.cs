using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    void Update()
    {
        Interaction();
    }

    private void Interaction()
    {
        RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());

        foreach (RaycastHit item in hits)
        {
            OnHit target = item.transform.GetComponent<OnHit>();

            if (target == null)
            {
                continue;
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Gun>().Fire(item.point);
            }

        }
    }

    private static Ray GetMouseRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}
