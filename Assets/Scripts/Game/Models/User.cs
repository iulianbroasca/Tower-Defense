using Globals;

namespace Game.Models
{
    public class User
    {
        public float Money { get; set; }

        public User()
        {
            Money = Constants.PlayerMoney;
        }
    }
}
