using UnityEngine;
using System.Collections;


public class Health : MonoBehaviour
{
    public GameObject explosionPrefab;
    public int defaultHealthPoint = 3;

    private int healthPoint;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        healthPoint = defaultHealthPoint;
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public void TakeDamage(int damage)
    {
        if (healthPoint <= 0) return;

        healthPoint -= damage;

        StartCoroutine(FlashEffect());

        if (healthPoint <= 0)
            Die();
    }

    private IEnumerator FlashEffect()
    {
        for (int i = 0; i < 2; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);

            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
    }

    protected virtual void Die()
    {
        if (explosionPrefab != null)
        {
            GameObject explosion = Instantiate(
                explosionPrefab,
                transform.position,
                transform.rotation
            );

            Destroy(explosion, 1f);
        }

        Destroy(gameObject);
    }
    
}
