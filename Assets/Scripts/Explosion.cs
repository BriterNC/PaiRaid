using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private string _explosionTrigger = "Explode";
    private GameController _gc;
    private bool _blowOff;
    
    private void Awake()
    {
        _gc = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("PlayerShip") && !_blowOff)
        {
            _blowOff = true;
            if (_gc.hp > 0)
            {
                _gc.GetHit();
                Debug.Log($"Player's Ship Hit!! (HP = {_gc.hp})");
            }
            gameObject.GetComponent<Animator>().SetTrigger(_explosionTrigger);
            StartCoroutine(DestroyBall());
        }
    }

    private IEnumerator DestroyBall()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
