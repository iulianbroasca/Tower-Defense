using UnityEngine;

namespace TowersMechanism.Behaviours
{
    public class TowerLookAtBehaviour : MonoBehaviour
    {
        public void LookAt(Vector3 position)
        {
            transform.LookAt(new Vector3(position.x, transform.localPosition.y ,position.y));
        }
    }
}
