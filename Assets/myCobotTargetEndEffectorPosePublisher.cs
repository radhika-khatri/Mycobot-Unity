using RosMessageTypes.Geometry;
using RosMessageTypes.MycobotUnity;
using Unity.Robotics.ROSTCPConnector;
using Unity.Robotics.Core;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using Unity.Robotics.UrdfImporter;
using UnityEngine;

public class myCobotTargetEndEffectorPosePublisher : MonoBehaviour
{
    private static readonly string TopicName = "/mycobot_tracking";
    private static readonly Quaternion PickOrientation = Quaternion.Euler(0, 0, 0);

    public UrdfJointRevolute[] jointArticulationBodies;
    public GameObject target;
    public GameObject endEffector;

    [SerializeField]
    double m_PublishRateHz = 1f;

    double m_LastPublishTimeSeconds;

    double PublishPeriodSeconds => 1.0f / m_PublishRateHz;

    bool ShouldPublishMessage => Clock.NowTimeInSeconds > m_LastPublishTimeSeconds + PublishPeriodSeconds;

    private ROSConnection m_Ros;
    private MyCobotTrackingTargetMsg jointMsg;

    void Start()
    {
        m_Ros = ROSConnection.GetOrCreateInstance();
        m_Ros.RegisterPublisher<MyCobotTrackingTargetMsg>(TopicName);
        jointMsg = new MyCobotTrackingTargetMsg();

        m_LastPublishTimeSeconds = Clock.time + PublishPeriodSeconds;
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
            orientation = Quaternion.Euler(target.transform.eulerAngles.x,
                                           target.transform.eulerAngles.y,
                                           target.transform.eulerAngles.z).To<FLU>()
        };
        
        jointMsg.end_effector_pose = new PoseMsg
        {
            position = endEffector.transform.position.To<FLU>(),
            orientation = Quaternion.Euler(endEffector.transform.eulerAngles.x,
                                           endEffector.transform.eulerAngles.y,
                                           endEffector.transform.eulerAngles.z).To<FLU>()
        };

        m_Ros.Publish(TopicName, jointMsg);
        m_LastPublishTimeSeconds = Clock.FrameStartTimeInSeconds;
    }

   
    private void Update()
    {
        if (ShouldPublishMessage)
        {
            Publish();
        }
    }
}