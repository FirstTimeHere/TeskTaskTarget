using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform spawn;

    // режимы стрельбы
    public bool singleShoot { get; private set; }  = true;    //передать значение через делегат                  // одиночными и для коэфицента  
    private bool secondShoot;                                 

    [SerializeField] private int maxAmmo = 3;                            // количество дополнительных патронов
    private int maxAmmoInClip = 1;                        // емкость магазина
    private int gunAmmo = 0;
    [SerializeField] private int shrapnel = 0;



    private bool canShoot = true;                        // триггер
    [SerializeField] private float shootForce;
    [SerializeField] private float spread;
    [SerializeField] private float shotgunSpread;

    private void Awake()
    {
        gunAmmo = maxAmmoInClip;                        // кладем в магазин патроны в колистве емкости магазина
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.B))
        {
            SingleOrNotShoot();
        }
        // при нажатии на левую кнопку мыши и если нам разрешено стрелять
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
    /// Создаем метод, в нем создаем пулю, куда она летит
    /// </summary>
    private void Shoot()
    {
        // уменьшаем количество патронов в магазине
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
            // выключаем триггер (то есть стрелять уже нельзя)
            canShoot = false;

            // если количество дополнительных патронов больше 0...
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

    private IEnumerator corontinulReloud()
    {
        canShoot = true;
        yield return new WaitForSeconds(Time.deltaTime);
    }
    
}


 
