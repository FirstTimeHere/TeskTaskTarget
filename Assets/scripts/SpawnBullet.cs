using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform spawn;
    [SerializeField]
    // режимы стрельбы
    private bool SingleShoot = true;                        // одиночными
    private bool BurstAuto = true;                        // очередями с отсечкой по 3 выстрела
    private bool FullAuto = true;                        // непрерывними очередями

    [SerializeField] private int maxAmmo = 3;                            // количество дополнительных патронов
    private int maxAmmoInClip = 1;                        // емкость магазина
    private int gunAmmo = 0;

    private int modes = 0;                                // переменная для определения режимов стрельбы
    private bool canShoot = true;                        // триггер
    private int currentMode;                                // текущий режим стрельбы
    private int bulletsToGo;                                // переменная необходимая для реализации режима стрельбы очередями с отсечкой по 3 выстрела
                                                            // количество патронов в магазине

    [SerializeField] private float shootForce;
    [SerializeField] private float spread;


    private void Update()
    {
        // при нажатии на левую кнопку мыши и если нам разрешено стрелять
        if (Input.GetAxis("Fire1") != 0 && canShoot)
        {
            // стреляем
            Shoot();
            // если текущий режим стрельбы очередью с отсечкой по 3 выстрела, то переменной bulletsToGo
            // присваиваем значение равное 2 (то есть 0, 1, 2 - три выстрела)
            if (currentMode == 1) { bulletsToGo = 2; }
           
        }
    }
    /// <summary>
    /// Создаем метод, в нем создаем пулю, куда она летит
    /// </summary>
    private void Shoot()
    {
        // уменьшаем количество патронов в магазине
        gunAmmo--;
        if (gunAmmo < 1)
        {
            // выключаем триггер (то есть стрелять уже нельзя)
            canShoot = false;
            // если количество дополнительных патронов больше 0...
            if (maxAmmo > 0)
            {
                gunAmmo = maxAmmoInClip;
                maxAmmo -= maxAmmoInClip;
                
                canShoot = true;
            }
                // то перезаряжаем оружие
        }
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 target;

        if (Physics.Raycast(ray, out hit))
            target = hit.point;
        else
            target = ray.GetPoint(75);

        Vector3 dirWithoutSpread = target - spawn.position; //появление пули без разброса

        //разброс пули
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //новое расстояние
        Vector3 dirWithSpread = dirWithoutSpread + new Vector3(x, y, 0);

        GameObject currentBullet = Instantiate(bullet, spawn.position, Quaternion.identity);

        //поворот пули в сторону выстрела
        currentBullet.transform.forward = dirWithSpread.normalized;

        //сила пули
        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * shootForce, ForceMode.Impulse);
    }

}


 
