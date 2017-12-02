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

    }

    void LateUpdate() {
        rigid.MovePosition(Vector3.MoveTowards(transform.position, player.transform.position, speed));
        rigid.MoveRotation(Quaternion.RotateTowards(transform.rotation, Quaternion.AngleAxis(0.0f, player.transform.position - transform.position), MaxRotation));
    }
}