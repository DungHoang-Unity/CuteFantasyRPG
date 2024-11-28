using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;

    readonly int FIRE_HASH = Animator.StringToHash("Fire");

    private Animator myAnimator;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    public void Attack()
    {
        myAnimator.SetTrigger(FIRE_HASH);
        GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, ActiveWeapon.Instance.transform.rotation);
        newBullet.GetComponent<Projecttile>().UpdateWeaponInfo(weaponInfo);
        
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }
}
