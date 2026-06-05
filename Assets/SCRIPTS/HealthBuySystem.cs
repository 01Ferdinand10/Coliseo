using UnityEngine;

public class HealthBuySystem : MonoBehaviour
{
    private Money_System moneySystem;
    private Player_vida playerVida;

    void Start()
    {
        moneySystem = FindAnyObjectByType<Money_System>();
        playerVida = FindAnyObjectByType<Player_vida>();
    }

    public void OnMediPackClick()
    {
        int dinero = moneySystem.GetMoney();
        if (dinero >= 36)
        {
            playerVida.Curar(10);
            moneySystem.RestarMoney(36);

        }
    }

    public void OnPotionClick()
    {
        int dinero = moneySystem.GetMoney();
        if (dinero >= 4)
        {
            playerVida.Curar(1);
            moneySystem.RestarMoney(4);

        }
    }
}
