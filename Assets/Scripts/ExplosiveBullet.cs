using UnityEngine;

public class ExplosiveBullet : MonoBehaviour
{
    public float explosionRadius = 1.5f;
    public LayerMask enemyLayer;
    public GameObject explosionPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Khi chạm enemy đầu tiên
        if (collision.GetComponent<EnemyHealth>() != null)
        {
            Explode();
        }
    }

    void Explode()
    {
        // Tạo hiệu ứng nổ
        if (explosionPrefab != null)
        {
            GameObject explosion = Instantiate(
                explosionPrefab,
                transform.position,
                Quaternion.identity
            );
            Destroy(explosion, 1f);
        }

        // Tìm tất cả enemy trong bán kính
        Collider2D[] enemies = Physics2D.OverlapCircleAll(
            transform.position,
            explosionRadius,
            enemyLayer
        );

        foreach (Collider2D enemy in enemies)
        {
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.SendMessage("Die", SendMessageOptions.DontRequireReceiver);
            }
        }

        // Hủy chính viên đạn
        Destroy(gameObject);
    }

    // (tùy chọn) Vẽ bán kính nổ để debug
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
