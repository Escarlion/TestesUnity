using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    GameObject player;

    [HideInInspector]
    public bool hasShotgun = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (hasShotgun)
        {
            player.transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    public void GetShotgun()
    {
        hasShotgun = true;
    }
}
