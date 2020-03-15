using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : LivingEntity
{


    public float rotateSpeed;
    public Rigidbody rb;
    public EasyJoystick lookRotate;


   // public VariableJoystick variableJoystick;

    // Start is called before the first frame update
    protected override void Start()
    {
        //rb = GetComponent<Rid>()
        base.Start();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // float rotate = lookRotate.MoveInput().x;

        lookRotate.Rotate(transform, rotateSpeed);

        //print (xRotation);



       
    }
}
