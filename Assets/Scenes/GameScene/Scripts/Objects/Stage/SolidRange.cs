using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidRange : MonoBehaviour
{
    [SerializeField] private Vector3 Range = Vector3.one;
    
    // 3Dの範囲内ならtrue
    public bool CheckSolidRange(Vector3 shadowpos)
    {
        Vector3 pos = transform.position - shadowpos;
        for (int i = 0; i < 3; i++) pos[i] = Mathf.Abs(pos[i]);
        if (Range == Vector3.Max(Range, pos))
            return true;
        return false;
    }

    public void SetRange(float x,float y,float z = 1f)
    {
        Range = new Vector3(x,y,z);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position,
            new Vector3(Range.x * 2f, Range.y * 2f, Range.z * 2f));
    }

}
