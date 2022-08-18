using UnityEngine;
using DG.Tweening;

public class BalloonSpawner : MonoBehaviour
{
	[SerializeField] private Material[] balloonMaterials;
	[SerializeField] private Rigidbody rbPoint;

	private void Start()
	{
		InvokeRepeating(nameof(BalloonCreate), 1.0f, 2.0f);
		InvokeRepeating(nameof(BalloonDeActivate), 101.001f, 2.0f); //This numbers may switch with variables
	}

	public void BalloonCreate()
	{
		GameObject cloneBalloon = PoolingSystem.Instance.SpawnFromPool("Balloon", rbPoint.position + Vector3.zero, Quaternion.identity);

		Balloon balloonScript = cloneBalloon.GetComponent<Balloon>();
		balloonScript.SetConnectedBody(rbPoint);

		cloneBalloon.transform.GetChild(0).GetComponent<MeshRenderer>().material = balloonMaterials[Random.Range(0, balloonMaterials.Length)];

		cloneBalloon.transform.localScale = new Vector3(.1f, .1f, .1f);
		cloneBalloon.transform.DOScale(Vector3.one, 2f);
		
	}

	public void BalloonDeActivate()
	{
		GameObject cloneBalloon2 = PoolingSystem.Instance.DeSpawnFromPool("Balloon", Vector3.zero, Quaternion.identity);
		Debug.Log("Deactivation Starts");
	}

}
