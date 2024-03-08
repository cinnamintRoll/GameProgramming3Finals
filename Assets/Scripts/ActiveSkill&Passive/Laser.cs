using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserBeam : MonoBehaviour
{
    public float laserWidth = 1.0f;
    public float noise = 1.0f;
    public float maxLength = 50.0f;
    public Color color = Color.red;
    public float moveSpeed = 5.0f; // Adjust this speed as needed

    private LineRenderer lineRenderer;
    private int length;
    private Vector3[] position;
    private Transform myTransform;
    private Transform endEffectTransform;
    public ParticleSystem endEffect;
    private Vector3 offset;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = laserWidth;
        lineRenderer.endWidth = laserWidth;

        myTransform = transform;
        offset = Vector3.zero;

        endEffect = GetComponentInChildren<ParticleSystem>();
        if (endEffect)
            endEffectTransform = endEffect.transform;
    }

    void Update()
    {
        RenderLaser();
        MoveLaser();
    }

    void RenderLaser()
    {
        UpdateLength();
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;

        for (int i = 0; i < length; i++)
        {
            offset.x = myTransform.position.x + i * myTransform.forward.x + Random.Range(-noise, noise);
            offset.z = i * myTransform.forward.z + Random.Range(-noise, noise) + myTransform.position.z;
            position[i] = offset;
            position[0] = myTransform.position;
            lineRenderer.SetPosition(i, position[i]);
        }
    }

    void UpdateLength()
    {
        RaycastHit[] hit;
        hit = Physics.RaycastAll(myTransform.position, myTransform.forward, maxLength);

        int i = 0;
        while (i < hit.Length)
        {
            if (!hit[i].collider.isTrigger)
            {
                length = (int)Mathf.Round(hit[i].distance) + 2;
                position = new Vector3[length];

                if (endEffect)
                {
                    endEffectTransform.position = hit[i].point;
                    if (!endEffect.isPlaying)
                        endEffect.Play();
                }

                lineRenderer.positionCount = length;
                return;
            }
            i++;
        }

        if (endEffect)
        {
            if (endEffect.isPlaying)
                endEffect.Stop();
        }

        length = (int)maxLength;
        position = new Vector3[length];
        lineRenderer.positionCount = length;
    }

    void MoveLaser()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}


