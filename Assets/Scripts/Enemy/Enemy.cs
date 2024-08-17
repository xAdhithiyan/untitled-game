using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KevinCastejon.MoreAttributes;

public class Enemy : MonoBehaviour
{
	[Header("Core Variables")]
	[SerializeField]
	private Transform playerPositon;
	[SerializeField]
	private Rigidbody2D rb;

	[Header("Movement")]
	[SerializeField]
	private float moveSpeed;

	[Header("Prefabs")]
	[SerializeField]
	private EnemyAttack _enemyAttackPrefab;
	private EnemyAttack _singleEnemyAttack;

	[Header("Attack")]
	[SerializeField]
	private float waitForNextAttack;

	[ReadOnly]
	public Vector3 towardsPlayer;
	
	private void Start()
	{
		playerPositon = GameObject.FindWithTag(Tags.T_Player).transform;
		towardsPlayer = (playerPositon.position - transform.position).normalized;
		//rb.velocity = towardsPlayer * moveSpeed;	
	  StartCoroutine(ShootProjectiles());
	}

	private void Update()
	{
		checkPlayer();
	}
	private void checkPlayer()
	{
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
		Bounds bound = new Bounds(transform.position, Vector3.zero);
		if(GeometryUtility.TestPlanesAABB(planes, bound))
		{
			Debug.Log("hello");
		}
	}

	private IEnumerator ShootProjectiles() { 
		while(true) {
			ShootProjectile();
			yield return new WaitForSeconds(waitForNextAttack);
		}
	}

	private void ShootProjectile()
	{
		_singleEnemyAttack = Instantiate(_enemyAttackPrefab, transform.position, Quaternion.identity);
	}

}
