using UnityEngine;
using System.Collections;

public class FollowShip : MonoBehaviour
{
    public float speed = 1.0f;
    public float MaxRotation = 0.3f;
    public GameObject player;

    private Rigidbody rigid;

    private void Awake() {
        rigid = GetComponent<Rigidbody>();
    }

    void Start() {
        player = GameObject.FindGameObjectWithTag("Ship");
    }

    void LateUpdate() {
        rigid.MovePosition(Vector3.MoveTowards(transform.position, player.transform.position, speed));
        rigid.MoveRotation(Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), MaxRotation));
    }
}