using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _explosionParticle;
    private Rigidbody _targetRb;
    private GameManager gameManager;
    private float _minUpwardForce = 12;
    private float _maxUpwardForce = 16;
    private float _randomTorque = 10;
    private float _XRange = 4;
    private float _YPosition = -6;

    public int pointValue;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _targetRb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        _targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        _targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPosition();
    }

    void OnMouseDown()
    {
        Destroy(gameObject);
        Instantiate(_explosionParticle, transform.position, _explosionParticle.transform.rotation);
        gameManager.UpdateScore(pointValue);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!other.gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(_minUpwardForce, _maxUpwardForce);
    }

    private float RandomTorque()
    {
        return Random.Range(-_randomTorque, _randomTorque);
    }

    private Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-_XRange, _XRange), _YPosition);
    }
}
