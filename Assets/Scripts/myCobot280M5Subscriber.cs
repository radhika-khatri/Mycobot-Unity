using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using JointStateMsg = RosMessageTypes.Sensor.JointStateMsg;

public class myCobot280M5Controller : MonoBehaviour
{
    public ArticulationBody joint2;
    public ArticulationBody joint3;
    public ArticulationBody joint4;
    public ArticulationBody joint5;
    public ArticulationBody joint6;
    public ArticulationBody joint6Flange;

    private ArticulationBody[] joint;
    private ROSConnection ros;


    // Start is called before the first frame update
    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();
        ros.Subscribe<JointStateMsg>("/move_group/fake_controller_joint_states", Callback);

        joint = new ArticulationBody[6];
        joint[0] = joint2;
        joint[1] = joint3;
        joint[2] = joint4;
        joint[3] = joint5;
        joint[4] = joint6;
        joint[5] = joint6Flange;
    }

    void Callback(JointStateMsg msg)
    {
        for (int i = 0; i < 6; i++)
        {
            ArticulationDrive aDrive = joint[i].xDrive;
            aDrive.target = Mathf.Rad2Deg * (float)msg.position[i];
            joint[i].xDrive = aDrive;
        }
    }
}