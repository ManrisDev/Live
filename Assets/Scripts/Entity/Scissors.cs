using UnityEngine;

public class Scissors : Entity
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Hero hero))
        {
            hero.Take_Damage(3);
        }
    }
}
