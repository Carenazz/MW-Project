using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunDust : MonoBehaviour
{
    Animator anim;

    [SerializeField]
    PlayerControls player;

    public GameObject play;

    void Start()
    {
        player = play.GetComponent<PlayerControls>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

    }
}
