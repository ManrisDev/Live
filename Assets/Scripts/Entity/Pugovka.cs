using UnityEngine;

public class Pugovka : Entity
{
    [SerializeField] private GameObject pug;
    [SerializeField] private SpriteRenderer spritePug;

    public void MovePug()
    {
        pug.transform.position = new Vector2(0.88f, -72.64f);
        spritePug.flipX = false;
    }
}
