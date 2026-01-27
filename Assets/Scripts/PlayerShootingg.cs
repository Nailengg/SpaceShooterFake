using UnityEngine;
using TMPro;

public class PlayerShootingg : MonoBehaviour
{
    [Header("Bullet Prefabs")]
    public GameObject centerBulletPrefab;
    public GameObject sideBulletPrefab;

    [Header("Fire Points")]
    public Transform firePointLeft;
    public Transform firePointRight;

    [Header("Center Bullet Offset")]
    public Vector3 bulletOffset;

    [Header("Fire Rate")]
    public float leftMouseInterval;
    public float rightMouseInterval;

    [Header("UI")]
    public TMP_Text centerSkillCooldownText;

    private float lastLeftShotTime;
    private float lastRightShotTime;

    void Update()
    {
        HandleLeftMouse();
        HandleRightMouse();
        UpdateCenterSkillUI();
    }

    void HandleLeftMouse()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time - lastLeftShotTime > leftMouseInterval)
            {
                ShootSideBullets();
                lastLeftShotTime = Time.time;
            }
        }
    }

    void HandleRightMouse()
    {
        if (Input.GetMouseButton(1))
        {
            if (Time.time - lastRightShotTime > rightMouseInterval)
            {
                ShootCenterBullet();
                lastRightShotTime = Time.time;
            }
        }
    }

    void ShootSideBullets()
    {
        Instantiate(sideBulletPrefab, firePointLeft.position, firePointLeft.rotation);
        Instantiate(sideBulletPrefab, firePointRight.position, firePointRight.rotation);
    }

    void ShootCenterBullet()
    {
        Instantiate(centerBulletPrefab, transform.position + bulletOffset, transform.rotation);
    }

    void UpdateCenterSkillUI()
    {
        float cooldownLeft = rightMouseInterval - (Time.time - lastRightShotTime);

        if (cooldownLeft <= 0)
        {
            centerSkillCooldownText.text = "Special Skill: READY";
            centerSkillCooldownText.color = Color.green;
        }
        else
        {
            centerSkillCooldownText.text = "Special Skill: " + cooldownLeft.ToString("0.0") + "s";
            centerSkillCooldownText.color = Color.red;
        }
    }
}
