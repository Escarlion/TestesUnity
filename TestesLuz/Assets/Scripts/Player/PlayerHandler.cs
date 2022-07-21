using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    //Objetos
    GameObject player;

    //Variaveis 
    [HideInInspector]
    public bool hasShotgun = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (hasShotgun == true)
        {
            player.transform.GetChild(2).gameObject.SetActive(true);
        }
    }


    //Usado por outros scripts para ativar a shotgun
    public void GetShotgun()
    {
        hasShotgun = true;
        player.transform.GetChild(2).gameObject.SetActive(true);
    }
}
