using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponBuySystem : MonoBehaviour
{
    
    private Money_System moneySystem;
    private Weapon weapon;

    [SerializeField] Sprite sword1Sprite;
    [SerializeField] Sprite sword2Sprite;
    [SerializeField] Sprite sword3Sprite;
    [SerializeField] Sprite sword4Sprite;
    [SerializeField] Sprite sword5Sprite;

    void Start()
    {
        moneySystem = FindAnyObjectByType<Money_System>();
        weapon = FindAnyObjectByType<Weapon>();
    }

    public void OnSword1Click()
    {
        int dinero = moneySystem.GetMoney();
        if (dinero >= 18)
        {
            weapon.SetWeapon(sword1Sprite, 2);
            moneySystem.RestarMoney(10);

        }
    }

    public void OnSword2Click()
    {
        int dinero = moneySystem.GetMoney();
        if (dinero >= 24)
        {
            weapon.SetWeapon(sword2Sprite, 3);
            moneySystem.RestarMoney(12);

        }
    }

    public void OnSword3Click()
    {
        int dinero = moneySystem.GetMoney();
        if (dinero >= 30)
        {
            weapon.SetWeapon(sword3Sprite, 4);
            moneySystem.RestarMoney(18);

        }
    }

    public void OnSword4Click()
    {
        int dinero = moneySystem.GetMoney();
        if (dinero >= 36)
        {
            weapon.SetWeapon(sword4Sprite, 5);
            moneySystem.RestarMoney(24);

        }
    }

    public void OnSword5Click()
    {
        int dinero = moneySystem.GetMoney();
        if (dinero >= 42)
        {
            weapon.SetWeapon(sword5Sprite, 6);
            moneySystem.RestarMoney(32);

        }
    }
}