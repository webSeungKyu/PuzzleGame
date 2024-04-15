using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    CapsuleCollider cc;

    Vector3 destPos;
    Vector3 dir;
    Quaternion lookTarget;

    bool move = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CapsuleCollider>();
    }

    
    void Update()
    {
        // ���� ���콺 ��ư�� ������ ��
        if (Input.GetKey(KeyCode.Mouse0))
        {
            RaycastHit hit;
            // ���� ī�޶� ���� ���콺 Ŭ���� ���� ray ������ ������
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // ray�� ���� ��ü�� �ִ��� �˻�
            if (Physics.Raycast(ray, out hit, 100f))
            {
                print(hit.transform.name);

                // hit.point �� ���콺 Ŭ���� ���� ���� ��ǥ.
                // �� �������� ĳ������ y ��(����) �� ������ �ʱ� ������ 
                // �Ʒ��� ���� ��ǥ��ġ�� �缳���մϴ�.
                destPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);

                // ���� ��ġ�� ��ǥ ��ġ�� ���� ����
                dir = destPos - transform.position;

                // �ٶ� ���ƾ� �� ���� Quaternion
                lookTarget = Quaternion.LookRotation(dir);
                move = true;
            }
        }

        Move();
    }


    void Move()
    {
        if (move)
        {
            // �̵��� �������� Time.deltaTime * 2f �� �ӵ��� ������.
            transform.position += dir.normalized * Time.deltaTime * 2f;
            // ���� ���⿡�� ���������� �������� �ε巴�� ȸ��
            transform.rotation = Quaternion.Lerp(transform.rotation, lookTarget, 0.25f);

            // ĳ������ ��ġ�� ��ǥ ��ġ�� �Ÿ��� 0.05f ���� ū ���ȸ� �̵�
            move = (transform.position - destPos).magnitude > 0.05f;
        }
    }
}
