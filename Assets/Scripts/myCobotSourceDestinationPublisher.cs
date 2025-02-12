using RosMessageTypes.Geometry;
using RosMessageTypes.MycobotUnity;
using Unity.Robotics.ROSTCPConnector;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using Unity.Robotics.UrdfImporter;
using UnityEngine;

public class myCobotSourceDestinationPublisher : MonoBehaviour
{
    private static readonly string TopicName = "/mycobot_joints";
    private static readonly Quaternion PickOrientation = Quaternion.Euler(90, 90, 0);

    public UrdfJointRevolute[] jointArticulationBodies;
    public GameObject target;
    private ROSConnection m_Ros;
    private MyCobotMoveitJointsMsg jointMsg;

    void Start()
    {
        m_Ros = ROSConnection.GetOrCreateInstance();
        m_Ros.RegisterPublisher<MyCobotMoveitJointsMsg>(TopicName);
        jointMsg = new MyCobotMoveitJointsMsg();
    }

    public void Publish()
    {
        for (var i = 0; i < jointArticulationBodies.Length; i++)
        {
            jointMsg.joints[i] = jointArticulationBodies[i].GetPosition();
        }

        jointMsg.goal_pose = new PoseMsg
        {
            position = target.transform.position.To<FLU>(),
            orientation = Quaternion.Euler(90, target.transform.eulerAngles.y, 0).To<FLU>()
        };

        m_Ros.Publish(TopicName, jointMsg);
    }
}