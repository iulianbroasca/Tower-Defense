using MonoSingleton;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoSingleton<GameManager>
    {

        protected override void Awake()
        {
            base.Awake();

        }
    }
}
