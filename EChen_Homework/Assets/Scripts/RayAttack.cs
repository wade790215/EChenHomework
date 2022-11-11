using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayAttack : IAttack
{
    private WeaponData weaponData;
    private Transform firePoint;

    public RayAttack(WeaponData weaponData, Transform firePoint)
    {
        this.weaponData = weaponData;
        this.firePoint = firePoint; 
    }


    public void DrawAttack()
    {
        for (int i = 0; i < weaponData.scatterCount; i++)
        {
            var direction = firePoint.forward;
            var spread = Vector3.zero;
            var vMax = Tool.Angle2Value(Vector3.up, weaponData.verticalMaxAngle);
            var vMin = Tool.Angle2Value(Vector3.up, weaponData.verticalMinAngle);
            var hMax = Tool.Angle2Value(Vector3.right, weaponData.horiziontalMaxAngle);
            var hMin = Tool.Angle2Value(Vector3.right, weaponData.horiziontalMinAngle);

            spread += firePoint.up * Random.Range(vMin, vMax);
            spread += firePoint.right * Random.Range(hMin, hMax);
            direction += spread;

            if (Physics.Raycast(firePoint.position, direction, out RaycastHit hit, weaponData.shootingDistance))
            {
                Debug.DrawLine(firePoint.position, hit.point, Color.green, 5f);
            }
            else
            {
                Debug.DrawLine(firePoint.position, firePoint.position + direction * weaponData.shootingDistance, Color.red, 5f);
            }
        }
    }   
}
