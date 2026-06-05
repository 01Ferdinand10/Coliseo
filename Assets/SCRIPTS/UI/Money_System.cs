using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Money_System : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text_cant_money;
    [SerializeField] private int cant_money;

    public int GetMoney()
    {
        return cant_money;
    }

    private void Start()
    {
        ActualizarText();
    }

    private void OnEnable()
    {
        Moneda.EnemigoMuerto += SumarMoney;
    }

    private void OnDisablee()
    {
        Moneda.EnemigoMuerto -= SumarMoney;
    }

    public void SumarMoney(int money)
    {
        if(cant_money+money <= 999) 
        {
            cant_money += money;
            ActualizarText();
        }
    }

    public void RestarMoney(int money)
    {
        cant_money -= money;
        ActualizarText();
    }

    private void ActualizarText()
    {
        text_cant_money.text = cant_money.ToString();
    }
}
