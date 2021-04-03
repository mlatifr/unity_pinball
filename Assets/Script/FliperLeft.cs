using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FliperLeft : MonoBehaviour
{
    public float posisiAwal = 0f;
    public float posisiTekan = -45f;
    public float torsiPukulan = 99000f;//buat atur momentum
    public float flipperDamper = 150f;//buat atur momentum
    HingeJoint hingeJoint;
    // Start is called before the first frame update
    void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
        hingeJoint.useSpring = true;
    }

    // Update is called once per frame
    void Update()
    {
        JointSpring perPegas = new JointSpring();//buat atur momentum
        perPegas.spring = torsiPukulan;//buat atur biar balik ke posisi awal
        perPegas.damper = flipperDamper;//buat atur 
        if (Input.GetKey("left"))
        {
            perPegas.targetPosition = posisiTekan;
        }
        hingeJoint.spring = perPegas;
        hingeJoint.useLimits = true;
    }
}
