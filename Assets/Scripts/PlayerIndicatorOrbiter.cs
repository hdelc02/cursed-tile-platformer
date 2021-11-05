﻿using UnityEngine;


class PlayerIndicatorOrbiter : MonoBehaviour
{
  [SerializeField] public float orbitRadius = 1.5f;
  [SerializeField] public float vanishProximity = 10f;

  private GameObject parentPlayer;
  private SpriteRenderer spriteRenderer;

  private void Awake()
  {
    parentPlayer = transform.parent.gameObject;
    spriteRenderer = GetComponent<SpriteRenderer>();
  }

  private void FixedUpdate()
  {
    GameObject targetCollectible = GameObject.Find("Collectible");
    Vector2 targetRay = targetCollectible.transform.position - parentPlayer.transform.position;
    if (targetRay.magnitude > vanishProximity)
    {
      spriteRenderer.enabled = true;
      transform.position = orbitRadius * targetRay.normalized;
      transform.rotation = Quaternion.Euler(new Vector3(0, 0, Vector2.SignedAngle(Vector2.right, targetRay)));
    }
    else
      spriteRenderer.enabled = false;
  }
}

