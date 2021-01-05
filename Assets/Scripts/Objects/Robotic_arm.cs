using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robotic_arm : MonoBehaviour
{
    ///
    /// Joint objects
    ///
    HingeJoint joint;
    JointMotor motor; 
    string control_target;

    ///
    /// constants
    ///
    float force_multiplier;
    float target_velocity;

    void Start()
    {
        control_target = gameObject.name;
        joint = GetComponent<HingeJoint>();

        /// motor default values
        force_multiplier = float.Parse(ConfigData.GetValue(control_target, "force_multiplier"));
        target_velocity = float.Parse(ConfigData.GetValue(control_target, "target_velocity"));

        /// motor
        motor = joint.motor;
        motor.force = 0;
        motor.targetVelocity = 0;
        motor.freeSpin = false;
        joint.motor = motor;
        joint.useSpring = false;

        /// angles
        JointLimits limits = joint.limits;
        limits.min = int.Parse(ConfigData.GetValue(control_target, "angle_min"));
        limits.bounciness = 0;
        limits.bounceMinVelocity = 20;
        limits.max = int.Parse(ConfigData.GetValue(control_target, "angle_max"));
        joint.limits = limits;
        joint.useLimits = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float value = Input.GetAxis(control_target);
        if (value > 0.05)
        {
            motor.force = value * force_multiplier;
            motor.targetVelocity = target_velocity;
        }
        else if (value < -0.05)
        {
            motor.force = -value * force_multiplier;
            motor.targetVelocity = -target_velocity;
        }
        else
        {
            motor.force = 0;
        }

        joint.motor = motor;

    }
}
