using UnityEngine;
using UnityEngine.UI;
using TMPro; // <-- Thêm namespace TextMeshPro
using System.Collections.Generic;

public class CartManager : MonoBehaviour
{
    public TextMeshProUGUI cartText;    // <-- Thay Text bằng TextMeshProUGUI
    public TextMeshProUGUI totalText;   // <-- Thay Text bằng TextMeshProUGUI
    public Button confirmButton;

    private List<MenuItem> cartItems = new List<MenuItem>();
    private float totalPrice = 0f;

    private void Start()
    {
        UpdateCartUI();
        confirmButton.interactable = false;
        confirmButton.onClick.AddListener(ConfirmOrder);
    }

    public void AddToCart(MenuItem item)
    {
        cartItems.Add(item);
        totalPrice += item.price;
        UpdateCartUI();
    }

    void UpdateCartUI()
    {
        cartText.text = "";
        foreach (var item in cartItems)
        {
            cartText.text += $"{item.name} - ${item.price:F2}\n";
        }
        totalText.text = "Total: $" + totalPrice.ToString("F2");
        confirmButton.interactable = cartItems.Count > 0;
    }

    void ConfirmOrder()
    {
        // TODO: Lưu đơn hàng thành JSON
        Debug.Log("Order confirmed!");
    }
}
