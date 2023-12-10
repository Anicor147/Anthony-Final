using Runtime.Enemies;
using Runtime.Extensions;
using Runtime.Managers;
using Runtime.ScriptableObjects.SOScripts;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class EnemyRangeController : EnemyBase
{
    [SerializeField] private EnemyStatsSOScritps _enemyStatsSoScritps;
    [SerializeField] private LootManager loot;
    [SerializeField] private GameObject bulletPrefab;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private GameObject player;
    private float timer = 1f;


    public void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        MaxEHealth = _enemyStatsSoScritps.MaxEHealth;
        ESpeed = _enemyStatsSoScritps.Espeed;
        EDamage = _enemyStatsSoScritps.EDamage;
        ERange = 10;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        timer -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        EnemyMovement();
        FlipSprite();
    }

    public override void TakeDamage(int value)
    {
        Debug.Log("Should get it");
        MaxEHealth -= value;
        _spriteRenderer.material.SetFloat("_HitValue", 1);
        //Timer extensions , set material value to 0
        this.StartTimer(0.2f, () => _spriteRenderer.material.SetFloat("_HitValue", 0));
        if (MaxEHealth <= 0)
        {
            OnDeath();
        }
    }

    public override void OnDeath()
    {
        //LevelManager.Instance._enemyList.Remove(gameObject);
        EnemyKilledCounter.Instance.EnemyCounter++;
        loot.MoneyLoot(transform.position);
        _animator.SetTrigger("IsDead");
        SoundEffectManager.Instance.PlayExplosionSound();
        this.StartTimer(0.5f, () => Destroy(gameObject));
    }

    public override void EnemyMovement()
    {
        Vector3 moveTowards = player.transform.position - transform.position;
        if (moveTowards.magnitude < 10)
        {
            _rigidbody2D.velocity = Vector3.zero;
            AttackPlayer(moveTowards);
        }
        else
        {
            _rigidbody2D.velocity = moveTowards.normalized * ESpeed;
        }
    }

    public void AttackPlayer(Vector3 distance)
    {
        if (timer <= 0)
        {
            var angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, angle)));
            timer = 1f;
        }
    }

    public override void FlipSprite()
    {
        if (transform.position.x > player.transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (transform.position.x < player.transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}