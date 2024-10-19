using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour
{

    [SerializeField] private float maxLife = 10;
    [SerializeField] private float currentLife = 0;
    [SerializeField] private float damageResistPercentage = 0;

    [SerializeField] private float damageNormalizerAux = 0.2f;
    [SerializeField] private float deathAnimationDuration = 1;

    [SerializeField] private Transform healthBar;
    private float healthBarZScale;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject ball = collision.gameObject;


        if (ball.CompareTag("pinball"))
        {
            Rigidbody ballRB = ball.GetComponent<Rigidbody>();
            TakeDamage(ballRB);

        }
    }

    private void TakeDamage(Rigidbody ballRB)
    {
        // velocity magnitude varies from 0 to 20
        float damageReceived = ballRB.velocity.magnitude * damageNormalizerAux * damageResistPercentage;
        maxLife -= damageReceived;

        Vector3 newScale = healthBar.localScale;
        newScale.z = healthBarZScale * currentLife / maxLife;
        healthBar.localScale = newScale;

        if (currentLife <= 0)
        {
            currentLife = 0;
            Die();
        }

    }


    private IEnumerator Die()
    {
        yield return new WaitForSeconds(deathAnimationDuration);
        Destroy(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        currentLife = maxLife;
        healthBarZScale = healthBar.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
