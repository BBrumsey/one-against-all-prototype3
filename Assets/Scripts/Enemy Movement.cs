using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform baseTarget;

    public int baseDamage = 1;
    public float arrivalDistance = 0.2f;

    private BaseHealth baseHealth;

    void Start()
    {
        GameObject targetObject = GameObject.Find("BaseTarget");

        if (targetObject != null)
        {
            baseTarget = targetObject.transform;
            baseHealth = baseTarget.GetComponentInParent<BaseHealth>();
        }
        else
        {
            Debug.LogError("BaseTarget was not found!");
        }
    }
    void Update()
    {
        if (baseTarget == null)
        {
            return;
        }

        float distance = Vector2.Distance(
            transform.position,
            baseTarget.position
        );

        if (distance <= arrivalDistance)
        {
            if (baseHealth != null)
            {
                baseHealth.TakeDamage(baseDamage);
            }

            Destroy(gameObject);
            return;
        }

        transform.position = Vector2.MoveTowards(
            transform.position,
            baseTarget.position,
            moveSpeed * Time.deltaTime
        );
    }
}