using System;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private int startingHp = 100;
    [SerializeField] private ParticleSystem deathParticlePrefab;

    private int currentHp;

    private float CurrentHpPct
    {
        get { return (float)currentHp / (float)startingHp; }
    }


    public event Action<float> OnHPPctChanged = delegate { };
    public event Action OnNPCDied = delegate { };

    private void Start()
    {
        currentHp = startingHp;
    }

    private void UpdateUI()
    {
        var currentHpPct = (float)currentHp / (float)startingHp;

        //slider.value = currentHpPct;
    }

    private void Update()
    {
        //hpBarSlider.transform.LookAt(Camera.main.transform);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(startingHp / 10);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage(20);
        }
    }


internal void TakeDamage(int amount)
    {
        GetComponent<IHealth>().TakeDamage(amount);
    }

    private void Die()
    {
        OnNPCDied();
        GameObject.Destroy(this.gameObject);
    }
}