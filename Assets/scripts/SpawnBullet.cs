using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform spawn;
    [SerializeField]
    // ������ ��������
    private bool SingleShoot = true;                        // ����������
    private bool BurstAuto = true;                        // ��������� � �������� �� 3 ��������
    private bool FullAuto = true;                        // ������������ ���������

    [SerializeField] private int maxAmmo = 3;                            // ���������� �������������� ��������
    private int maxAmmoInClip = 1;                        // ������� ��������
    private int gunAmmo = 0;

    private int modes = 0;                                // ���������� ��� ����������� ������� ��������
    private bool canShoot = true;                        // �������
    private int currentMode;                                // ������� ����� ��������
    private int bulletsToGo;                                // ���������� ����������� ��� ���������� ������ �������� ��������� � �������� �� 3 ��������
                                                            // ���������� �������� � ��������

    [SerializeField] private float shootForce;
    [SerializeField] private float spread;


    private void Update()
    {
        // ��� ������� �� ����� ������ ���� � ���� ��� ��������� ��������
        if (Input.GetAxis("Fire1") != 0 && canShoot)
        {
            // ��������
            Shoot();
            // ���� ������� ����� �������� �������� � �������� �� 3 ��������, �� ���������� bulletsToGo
            // ����������� �������� ������ 2 (�� ���� 0, 1, 2 - ��� ��������)
            if (currentMode == 1) { bulletsToGo = 2; }
           
        }
    }
    /// <summary>
    /// ������� �����, � ��� ������� ����, ���� ��� �����
    /// </summary>
    private void Shoot()
    {
        // ��������� ���������� �������� � ��������
        gunAmmo--;
        if (gunAmmo < 1)
        {
            // ��������� ������� (�� ���� �������� ��� ������)
            canShoot = false;
            // ���� ���������� �������������� �������� ������ 0...
            if (maxAmmo > 0)
            {
                gunAmmo = maxAmmoInClip;
                maxAmmo -= maxAmmoInClip;
                
                canShoot = true;
            }
                // �� ������������ ������
        }
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

}


 
