using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AICharacterController : MonoBehaviour
{
    [SerializeField]
    CharacterController2D characterController;
    Movement atks;

    GameObject Player;

    [SerializeField]
    GameObject target;

    GameObject temp;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        target = Player;
    }

    private void Update()
    {
        if (target != null)
        {
            if (target.transform.position.x < gameObject.transform.position.x)
            {
                //characterController.Flip();
                transform.rotation = Quaternion.Euler(0, 0, 0);
                characterController.m_FacingRight = false;
            }
            else
            {
                characterController.m_FacingRight = true;
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 2 * Time.deltaTime);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(gameObject.tag == "Player"))
        {
            int atknum = UnityEngine.Random.Range(0, 3);

            if (atknum == 0)
            {
                atks.jump = true;
            }
            else if (atknum == 1)
            {
                atks.atk = true;
            }
            else if (atknum == 2)
            {
                atks.special = true;
            }
        }
    }


}

