using System.Collections;
using UnityEngine;

public class Balloon : MonoBehaviour
{
	private SpringJoint springJoint;
	private StringRenderer stringRenderer;
	private CapsuleCollider capsuleCollider;

	private void Awake()
	{
		springJoint = GetComponent<SpringJoint>();
		stringRenderer = GetComponent<StringRenderer>();
		capsuleCollider = GetComponentInChildren<CapsuleCollider>();
	}

	private void OnEnable()
	{
		StartCoroutine(EnableCollider());
	}

	private void OnDisable()
	{
		capsuleCollider.enabled = false;
	}

	public void SetConnectedBody(Rigidbody playerBody)
	{
		springJoint.connectedBody = playerBody;
		stringRenderer.SetConnectedObject(playerBody.transform);
	}

	private IEnumerator EnableCollider()
	{
		float time = 2f;
		yield return new WaitForSeconds(time);
		capsuleCollider.enabled = true;
	}

}
