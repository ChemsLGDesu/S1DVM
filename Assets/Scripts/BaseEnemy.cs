using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public Transform Player;
    public int range = 10;
    public bool VerificarArea = false;
    public float speed = 2f;
    void Start()
    {
        GetComponent<SphereCollider>().radius = range;
        GetComponent<Player>();

    }

    void Update()
    {
        PerseguirPlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            VerificarArea = true;
            Player = other.gameObject.transform;
            print("Player Detectado");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            VerificarArea = false;
            Player = null;
            print("Player no Detectado");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            print("Enemigo Eliminado");
            Destroy(gameObject);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.color = Color.green;
        if (VerificarArea)
        {
            Gizmos.DrawLine(transform.position, Player.transform.position);
        }
    }
    public void PerseguirPlayer()
    {
        if (VerificarArea)
        {
            Vector3 dir = (Player.transform.position - transform.position).normalized;
            transform.position += dir * speed * Time.deltaTime;
        }
    }

}



