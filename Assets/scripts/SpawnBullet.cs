using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform spawn;

    // ������ ��������
    public bool singleShoot { get; private set; }  = true;    //�������� �������� ����� �������                  // ���������� � ��� ����������  
    private bool secondShoot;                                 

    [SerializeField] private int maxAmmo = 3;                            // ���������� �������������� ��������
    private int maxAmmoInClip = 1;                        // ������� ��������
    private int gunAmmo = 0;
    [SerializeField] private int shrapnel = 0;



    private bool canShoot = true;                        // �������
    [SerializeField] private float shootForce;
    [SerializeField] private float spread;
    [SerializeField] private float shotgunSpread;

    private void Awake()
    {
        gunAmmo = maxAmmoInClip;                        // ������ � ������� ������� � �������� ������� ��������
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.B))
        {
            SingleOrNotShoot();
        }
        // ��� ������� �� ����� ������ ���� � ���� ��� ��������� ��������
        if (Input.GetMouseButtonDown(0)  && canShoot)
        {
            Shoot();
        }
    }

    private bool SingleOrNotShoot()
    {
        secondShoot = singleShoot ? false : true;
        singleShoot = secondShoot;
        return secondShoot;
    }
    /// <summary>
    /// ������� �����, � ��� ������� ����, ���� ��� �����
    /// </summary>
    private void Shoot()
    {
        // ��������� ���������� �������� � ��������
        if (singleShoot)
        {
            Bullet();
        }
        else 
        {
            for (int i = shrapnel; i >= 0; i--) 
            {
                Bullet(shotgunSpread);
            }
        }
      
        if (gunAmmo!=0)
        {
            gunAmmo--;
        }
        if (gunAmmo < 1)
        {
            // ��������� ������� (�� ���� �������� ��� ������)
            canShoot = false;

            // ���� ���������� �������������� �������� ������ 0...
            if (maxAmmo > 0)
            {
                gunAmmo = maxAmmo - maxAmmoInClip;
                maxAmmo -= maxAmmoInClip;
                StartCoroutine(corontinulReloud());
            }
        }
    }
    private void Bullet(float spread=0)
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            Vector3 target;

            if (Physics.Raycast(ray, out hit))
                target = hit.point;
            else
                target = ray.GetPoint(75);

            Vector3 dirWithoutSpread = target - spawn.position; //��������� ���� ��� ��������

            //������� ����
            float x = Random.Range(-spread, spread);
            float y = Random.Range(-spread, spread);

            //����� ����������
            Vector3 dirWithSpread = dirWithoutSpread + new Vector3(x, y, 0);

            GameObject currentBullet = Instantiate(bullet, spawn.position, Quaternion.identity);

            //������� ���� � ������� ��������
            currentBullet.transform.forward = dirWithSpread.normalized;

            //���� ����
            currentBullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * shootForce, ForceMode.Impulse);
        }

    private IEnumerator corontinulReloud()
    {
        canShoot = true;
        yield return new WaitForSeconds(Time.deltaTime);
    }
    
}


 
