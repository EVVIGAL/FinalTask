using UnityEngine;
using TMPro;

public class MoneyCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;

    private int _money;
    private string _moneyTxt = " $";

    public int Money => _money;

    private void Start()
    {
        _money = 0;
        _moneyText.text = _money.ToString() + _moneyTxt;
    }

    public void AddMoney(int value)
    {
        _money += value;
        _moneyText.text = _money.ToString() + _moneyTxt;
    }

    public void SpendMoney(int value)
    {
        _money -= value;
        _moneyText.text = _money.ToString() + _moneyTxt;
    }
}
