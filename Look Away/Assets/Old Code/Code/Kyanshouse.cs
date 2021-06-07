using TMPro;
using UnityEngine;

namespace Old_Code.Code
{
    public class Kyanshouse : MonoBehaviour
    {
        public static Player MainPlayer;
        public TMP_Text coin;
        public Sprite killerWhale;
        public Sprite hammerheadShark;
        public Sprite yellowFish;
        private readonly int _totalCoins;

        private void Start()
        {
            MainPlayer = new Player("YellowFish", yellowFish);
            PlayerPrefs.SetInt("Coin", 1000);
            PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("Coin"));
            coin.text = $"Coins: {PlayerPrefs.GetInt("TotalCoins")}";
        }

        private void DeleteDate()
        {
            PlayerPrefs.DeleteKey("TotalCoins");
            PlayerPrefs.DeleteKey("Coin");
        }

        public void KillerWhaleButton()
        {
            if (PlayerPrefs.GetInt("TotalCoins") < 100)
            {
                Debug.Log("Not Enough money");
                return;
            }

            PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - 100);
            coin.text = $"Coins: {PlayerPrefs.GetInt("TotalCoins")}";
            MainPlayer = new Player("killer Whale", killerWhale);
        }

        public void HammerHeadButton()
        {
            if (PlayerPrefs.GetInt("TotalCoins") < 50)
            {
                Debug.Log("Not Enough money");
                return;
            }

            PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - 50);
            coin.text = $"Coins: {PlayerPrefs.GetInt("TotalCoins")}";
            MainPlayer = new Player("HammerheadShark", hammerheadShark);
        }
    }
}