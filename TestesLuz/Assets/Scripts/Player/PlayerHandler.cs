using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] Player player;

    [HideInInspector]
    public bool hasShotgun = false;

    private void Update()
    {
        if (hasShotgun)
        {
            this.transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    public void GetShotgun()
    {
        hasShotgun = true;
    }
}
