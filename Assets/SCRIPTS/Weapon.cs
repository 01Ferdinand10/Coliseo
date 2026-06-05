using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject Melee;
    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D polygonCollider;

    private int damage = 1;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        polygonCollider = GetComponent<PolygonCollider2D>();
        Melee.SetActive(false);

    }

    public void SetWeapon(Sprite newSprite, int newDamage)
    {
        spriteRenderer.sprite = newSprite;
        damage = newDamage;

        if (polygonCollider != null)
        {
            Destroy(polygonCollider);
        }

        polygonCollider = spriteRenderer.gameObject.AddComponent<PolygonCollider2D>();
        polygonCollider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyIosh enemy = collision.GetComponent<EnemyIosh>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }
}
