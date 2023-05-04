using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject playerShip, cannonBall, bomb, frontCanvas, backCanvas;
    [SerializeField] public int hp = 10;
    private bool _immortal;
    private string _hitTrigger = "Hit";
    private string _startTrigger = "Start";

    private void Update()
    {
        if (hp <= 0)
        {
            Debug.Log("Game Over");
            return;
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Fire!!!");
        }
    }

    public void StartGame()
    {
        Debug.Log("Starting Game!");
        frontCanvas.GetComponent<Animator>().SetTrigger(_startTrigger);
        backCanvas.GetComponent<Animator>().SetTrigger(_startTrigger);
        playerShip.GetComponent<Animator>().SetTrigger(_startTrigger);
    }

    public void GetHit()
    {
        if (!_immortal)
        {
            _immortal = true;
            hp--;
            playerShip.GetComponent<Animator>().SetTrigger(_hitTrigger);
            StartCoroutine(ImmortalCountdown());
        }
    }

    private IEnumerator ImmortalCountdown()
    {
        yield return new WaitForSeconds(1f);
        _immortal = false;
    }
}
