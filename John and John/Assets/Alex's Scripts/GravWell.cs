using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GravWell : Trigger {

//	public CapsuleCollider gravField;

	public Vector3 gravVector = Vector3.up;

	public ParticleSystem gravEffect;

    private List<Collider> cols;

	// Use this for initialization
	void Start () {
/*		if(gravField == null)
		{
			GameObject g = new GameObject();
			g.transform.parent = transform;
			gravField = g.AddComponent<CapsuleCollider>();
			g.transform.localPosition = Vector3.up;
			g.transform.localEulerAngles = Vector3.zero;
		}*/

//		gravField.isTrigger = true; 
        cols = new List<Collider>();

		if(currentState == State.Activated) gravEffect.Play();
		else gravEffect.Stop();

        triggerType = TriggerType.NonInteractive;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        if (currentState != State.Activated) return;

        foreach(Collider other in cols)
        {
        if (other == collider) return;
        Rigidbody r = other.attachedRigidbody;
        if (r != null)
        {
            Vector3 worldGravVector = gravVector.x * transform.right +
                                      gravVector.y * transform.up +
                                      gravVector.z * transform.forward;

            float radius = (other.transform.position - transform.position).sqrMagnitude / 16.0f + 1;

            r.velocity += worldGravVector * Time.deltaTime / radius;
        }
        else
        {
            var c = other.GetComponent<vp_FPController>();

            if (c != null)
            {
                Vector3 worldGravVector = gravVector.x * transform.right +
                                      gravVector.y * transform.up +
                                      gravVector.z * transform.forward;

                float radius = (other.transform.position - transform.position).sqrMagnitude / 16.0f + 1;

                c.AddForce(worldGravVector / (Physics.gravity.magnitude * radius) * Time.deltaTime * c.PhysicsGravityModifier);
            }
        }
        }
	}

	public override void OnActivated()
	{
		gravEffect.Play();
	}

	public override void OnDeactivate()
	{
		gravEffect.Stop();
	}

	void OnTriggerEnter(Collider other)
	{
        if(!cols.Contains(other)) cols.Add(other);
	}

    void OnTriggerExit(Collider other)
    {
        if (cols.Contains(other)) cols.Remove(other);
    }
}
