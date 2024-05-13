using System.Collections;
using UnityEngine;

public class InsectAI : MonoBehaviour
{
    public float flySpeed = 1f;
    public float cooldownTime = 3f;
    public float maxVerticalOffset = 0.5f; // Maximum vertical offset from the current position
    public float verticalChangeProbability = 0.1f; // Probability of changing vertical position
    public float verticalMoveDuration = 0.5f; // Duration of vertical movement
    public float maxRotationAngle = 30f; // Maximum rotation angle when going up or down
    public float rotationChangeSpeed = 5f; // Speed of rotation change
    public GameObject[] interactionPoints;
    GameObject target;
    bool stopMoving;
    bool cooldown;
    private void Start()
    {
        int randomObject = Random.Range(0, interactionPoints.Length);
        target = interactionPoints[randomObject];
    }

    private void Update()
    {
        if (!stopMoving)
        {
            float Speed = flySpeed * Time.deltaTime;

            // Calculate movement towards target
            Vector3 newPosition = Vector3.MoveTowards(transform.position, target.transform.position, Speed);

            // Adjust vertical position randomly
            if (Random.value < verticalChangeProbability)
            {
                StartCoroutine(ChangeVerticalPosition(newPosition));
            }
            else
            {
                transform.position = newPosition;
            }

            // Rotate smoothly towards target direction
            Vector3 targetDirection = target.transform.position - transform.position;
            targetDirection.y = 0; // Setting y to 0 to restrict rotation around the y-axis only
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            Quaternion xRotation = Quaternion.Euler(90f, 0f, 0f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation * xRotation, rotationChangeSpeed * Time.deltaTime);

            // Check if reached target
            if (Vector3.Distance(transform.position, target.transform.position) < 0.0001f)
            {
                stopMoving = true;
            }
        }
        else if (stopMoving && !cooldown)
        {
            // Set cooldown and find new position
            cooldown = true;
            Invoke("FindNewPosition", cooldownTime);
        }
    }

    IEnumerator ChangeVerticalPosition(Vector3 targetPosition)
    {
        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;
        Vector3 randomOffset = new Vector3(0f, Random.Range(-maxVerticalOffset, maxVerticalOffset), 0f);
        Quaternion startRotation = transform.rotation;

        while (elapsedTime < verticalMoveDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition + randomOffset, elapsedTime / verticalMoveDuration);
            elapsedTime += Time.deltaTime;

            // Adjust rotation based on vertical movement
            float rotationAngle = Mathf.Clamp(randomOffset.y * maxRotationAngle, -maxRotationAngle, maxRotationAngle);
            Quaternion targetRotation = Quaternion.Euler(90f, transform.rotation.eulerAngles.y, rotationAngle); // Only rotate around the y-axis
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationChangeSpeed * Time.deltaTime);

            yield return null;
        }

        transform.position = targetPosition + randomOffset;

        // Reset rotation to zero after vertical movement
        transform.rotation = Quaternion.Euler(90f, transform.rotation.eulerAngles.y, 0f);
    }

    void FindNewPosition()
    {
        // Find a new random target position
        int randomObject = Random.Range(0, interactionPoints.Length);
        target = interactionPoints[randomObject];

        // Reset flags
        stopMoving = false;
        cooldown = false;
    }
}