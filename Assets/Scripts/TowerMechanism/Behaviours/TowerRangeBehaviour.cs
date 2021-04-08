using UnityEngine;

namespace TowerMechanism.Behaviours
{
    public class TowerRangeBehaviour : MonoBehaviour
    {
        public void SetRange(Vector3 position, float range)
        {
            transform.localPosition = position;
            transform.localScale = Vector3.one * range;
        }
    }
}
