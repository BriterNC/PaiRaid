using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyShip : MonoBehaviour
{
    [SerializeField] ConstantForce2D cf2d;
    private float _timer;
    private string _whirlpoolTrigger = "Whirlpool";

    private void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }
    
    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= 1f)
        {
            _timer = 0;
            switch (cf2d.isActiveAndEnabled)
            {
                case (true):
                    cf2d.enabled = false;
                    break;
                case (false):
                    cf2d.enabled = true;
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(_whirlpoolTrigger))
        {
            Debug.Log("Whirlpool!!");
        }
    }
}
