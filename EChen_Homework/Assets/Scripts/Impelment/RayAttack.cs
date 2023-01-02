using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayAttack : AttackBase
{
    public float lastAttackTime = 0f;
    
    public override void Attack()
    {
        if (!AllowAttack())
            return;

        if (weaponData.currentBulletCount > 0)
        {
            weaponData.currentBulletCount--;
            DrawAttack();
            Debug.Log($"{weaponData.weaponName} + Attack");
        }
        else
        {
            Debug.Log($"{weaponData.weaponName} + NeedReload");
        }      

        lastAttackTime = Time.time;
    }

    public bool AllowAttack()
    {
        return Time.time - lastAttackTime > 1 / weaponData.attackRate;
    }

    public void DrawAttack()
    {
        for (int i = 0; i < weaponData.scatterCount; i++)
        {
            var direction = weaponData.firePoint.forward;
            var spread = Vector3.zero;
            var vMax = Tool.Angle2Value(Vector3.up, weaponData.verticalMaxAngle);
            var vMin = Tool.Angle2Value(Vector3.up, weaponData.verticalMinAngle);
            var hMax = Tool.Angle2Value(Vector3.right, weaponData.horiziontalMaxAngle);
            var hMin = Tool.Angle2Value(Vector3.right, weaponData.horiziontalMinAngle);

            spread += weaponData.firePoint.up * Random.Range(vMin, vMax);
            spread += weaponData.firePoint.right * Random.Range(hMin, hMax);
            direction += spread;

            if (Physics.Raycast(weaponData.firePoint.position, direction, out RaycastHit hit, weaponData.shootingDistance))
            {
                Debug.DrawLine(weaponData.firePoint.position, hit.point, Color.green, 5f);
            }
            else
            {
                Debug.DrawLine(weaponData.firePoint.position,
                    weaponData.firePoint.position + direction * weaponData.shootingDistance,
                    Color.red, 5f);
            }
        }
    }
}
