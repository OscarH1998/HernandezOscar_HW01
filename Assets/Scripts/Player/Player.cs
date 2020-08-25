using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BallMotor))]
public class Player : MonoBehaviour
{
    [SerializeField] int _maxHealth = 3;
    int _currenthealth;

    [SerializeField] int _treasureCount = 0;
    public Text _treasure;

    [SerializeField] ParticleSystem _deathParticles;
    [SerializeField] AudioClip _deathSound;


    BallMotor _ballMotor;

    private void Awake()
    {
        _ballMotor = GetComponent<BallMotor>();
    }

    private void Start()
    {
        _currenthealth = _maxHealth;
    }

    private void FixedUpdate()
    {
        ProcessMovement();  
    }

    private void ProcessMovement()
    {
        //TODO move into Input script
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical).normalized;

        _ballMotor.Move(movement);
    }

    public void IncreaseHealth(int amount)
    {
        _currenthealth += amount;
        Debug.Log("Player's health: " + _currenthealth);
    }

    public void DecreaseHealth(int amount)
    {
        _currenthealth -= amount;
        Debug.Log("Player's health: " + _currenthealth);

        if(_currenthealth <= 0)
        {
            Kill();
        }
    }

    public void IncreaseTreasure(int amount)
    {
        _treasureCount += amount;
        Debug.Log("Treasures found: " + _treasureCount);
        SetCountText();
    }

    void SetCountText()
    {
        _treasure.text = "Treasures Found:" + _treasureCount.ToString();
    }

    public void Kill()
    {
        gameObject.SetActive(false);
        // particles
        // sounds
    }
}
