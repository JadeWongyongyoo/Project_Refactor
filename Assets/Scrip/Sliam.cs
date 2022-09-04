using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliam : MonoBehaviour
{
    public int HP = 2;    

    public void TakeDamage(int damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D hitinfo)
    {
        Move_character player = hitinfo.GetComponent<Move_character>();
        if (player != null)
        {
            player.TargetDamage();
        }              

    }
   

}
