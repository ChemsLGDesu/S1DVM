using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class BaseEnemy : MonoBehaviour
{
    public GameObject Player;
    public float range =3f;
    public float speed;

    public bool enterZone;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enterZone = true;
            print("Player Entered");
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            enterZone = false;
            print("Player not Detect");
        }
    }
    void Update()
    {
        DetectRange();
    }
    public void DetectRange()
    {
        if (enterZone)
        {
            if (range < 3f)
            {
                GameObject obj = Instantiate(Player, transform);

                Vector3 origin = transform.position;
                Vector3 FinalPosition = origin  * Random.Range(0, range);
                obj.transform.position = FinalPosition;

                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(transform.position, 3f);
            }
        }
    }

}



