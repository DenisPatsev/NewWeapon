using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uzi : Weapon
{
    [SerializeField] private float _delay;
    [SerializeField] private float _bulletCount;

    private IEnumerator FireABurst(Transform shootPoint, float delay)
    {
        var wait = new WaitForSeconds(delay);
        float bullets = _bulletCount;

        while (bullets != 0)
        {
            Instantiate(Bullet, shootPoint.position, Quaternion.identity);
            bullets--;
            yield return wait;
        }
    }

    public override void Shoot(Transform shootPoint)
    {
        gameObject.SetActive(true);
        MonoBehaviour weapon = FindAnyObjectByType<Player>().GetComponent<MonoBehaviour>();
        weapon.StartCoroutine(FireABurst(shootPoint, _delay));
    }
}
