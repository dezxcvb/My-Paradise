using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BuoyantObject : MonoBehaviour
{
    public float underWaterDrag = 3f;
    public float underWaterAngularDrag = 1f;
    public float airDrag = 0f;
    public float airAngularDrag = 0.05f;
    public float floatingPointer = 15f;

    public float waterHeight = 0f;

    Rigidbody m_RigidBody;

    bool underwater;

    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float difference = transform.position.y - waterHeight;

        if (difference < 0)
        {
            m_RigidBody.AddForceAtPosition(Vector3.up * floatingPointer * Mathf.Abs(difference), transform.position, ForceMode.Force);
            if (!underwater)
            {
                underwater = true;
                SwitchState(true);
            }
        } else if (underwater)
        {
            underwater = false;
            SwitchState(false);
        }
    }

    void SwitchState(bool isUnderwater)
    {
        if (isUnderwater)
        {
            m_RigidBody.drag = underWaterDrag;
            m_RigidBody.angularDrag = underWaterAngularDrag;
        }
        else
        {
            m_RigidBody.drag = airDrag;
            m_RigidBody.angularDrag = airAngularDrag;
        }
    }
}