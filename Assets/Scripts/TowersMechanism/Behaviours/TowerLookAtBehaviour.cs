using UnityEngine;

namespace TowersMechanism.Behaviours
{
    public class TowerLookAtBehaviour : MonoBehaviour
    {
        public void LookAt(Transform target)
        {
            transform.LookAt(target);
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
    }
}
