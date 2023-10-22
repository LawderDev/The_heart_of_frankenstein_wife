using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;

    [SerializeField] private Transform projectilePoint;
    [SerializeField] private GameObject[] projectiles;

    [SerializeField] private float attackTensionDecrementation = 0;
    [SerializeField] private float skillTensionDecrementation = 5;
    [SerializeField] private float ultiTensionDecrementation = 100;
    private float cooldownAttackTimer = Mathf.Infinity;
    private float cooldownDashTimer = Mathf.Infinity;
    private float cooldownUltiTimer = Mathf.Infinity;
    private CooldownSkillUi cooldownSkillUi;
    private CooldownUltiUi cooldownUltiUi;
    private Rigidbody2D rb;
    private BoxCollider2D[] colliders;
    private BoxCollider2D dashCollider;
    private PlayerHealth playerHealth;
    private GameObject[] objectsWithTag;
    private PlayerTension playerTension;

    [SerializeField] private bool canDash = true;
    [SerializeField] private bool isDashing = false;

    [SerializeField] private float dashingDamage = 65f;
    [SerializeField] private float dashingPower = 24f;
    [SerializeField] private float dashingTime = 0f;
    [SerializeField] private float dashingDuration = 0.5f;
    [SerializeField] private float dashCooldown = 1f;
    [SerializeField] private float ultiCooldown = 5f;
    [SerializeField] private float ultiDammage = 100f;

    public float getDashingDamage(){
        return dashingDamage;
    }

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        rb = GetComponent<Rigidbody2D>();
        colliders = GetComponents<BoxCollider2D>();
        playerTension = GetComponent<PlayerTension>();
        cooldownSkillUi = GetComponent<CooldownSkillUi>();
        cooldownUltiUi = GetComponent<CooldownUltiUi>();
        foreach (BoxCollider2D collider in colliders)
        {
            if (collider.isTrigger)
            {
                dashCollider = collider;
            }
        }
    }

    private void Update()
    {
        if(isDashing){
            if(transform.localScale.x > 0)
                rb.velocity = new Vector2(dashingPower, rb.velocity.y);
            else
                rb.velocity = new Vector2(-dashingPower, rb.velocity.y);

            dashingTime += Time.deltaTime;
            if(dashingTime > dashingDuration){
                isDashing = false;
                dashCollider.enabled = false;
                dashingTime = 0;
            }
        }else{
            if (Input.GetMouseButton(0) && cooldownAttackTimer > attackCooldown)
                Attack();
            if (Input.GetMouseButtonDown(1) && cooldownDashTimer > dashCooldown)
                Skill();
            if(Input.GetKeyDown(KeyCode.R) && cooldownUltiTimer > ultiCooldown)
                Ulti();
        }

        cooldownUltiTimer += Time.deltaTime;
        cooldownAttackTimer += Time.deltaTime;
        cooldownDashTimer += Time.deltaTime;
    }

    private void Attack()
    {
        cooldownAttackTimer = 0;

        projectiles[FindProjectile()].transform.position = projectilePoint.position;
        projectiles[FindProjectile()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindProjectile()
    {
        for (int i = 0; i < projectiles.Length; i++)
        {
            if (!projectiles[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    private void Skill()
    {   
        playerTension.decrementTension(skillTensionDecrementation);
        playerHealth.setInvinsibility(true);
        dashCollider.enabled = true;
        isDashing = true;
        cooldownDashTimer = 0;
        cooldownSkillUi.SetCooldown(dashCooldown);
    }

    private void Ulti()
    {
        playerTension.decrementTension(ultiTensionDecrementation);

        Camera mainCamera = Camera.main;
        Vector3 cameraPosition = mainCamera.transform.position;
        Vector2 cameraSize = new Vector2(mainCamera.orthographicSize * 2 * mainCamera.aspect, mainCamera.orthographicSize * 2);

        Vector2 cameraPosition2D = new Vector2(cameraPosition.x, cameraPosition.y); // Conversion en Vector2
        Collider2D[] colliders = Physics2D.OverlapAreaAll(cameraPosition2D - cameraSize / 2, cameraPosition2D + cameraSize / 2);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Ennemy"))
            {
                EnnemySimple enemySimple = collider.GetComponent<EnnemySimple>();
                enemySimple.TakeDamage(ultiDammage);
                Destroy(collider.gameObject);
            }
        }

        cooldownUltiTimer = 0;
        cooldownUltiUi.SetCooldown(ultiCooldown);
    }
}
