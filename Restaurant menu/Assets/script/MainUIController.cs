using UnityEngine;
using UnityEngine.UIElements;

public class MainUIController : MonoBehaviour
{
    public UIDocument uiDocument;

    private float totalPrice = 0f;
    private float income = 0f;

    private Label totalPriceLabel;
    private Label incomeLabel;
    private VisualElement adminPanel;
    private VisualElement clientPanel;
    private VisualElement clientBox;

    private VisualElement adminHeader;
    private VisualElement clientHeader;
    private Button btnAdmin;

    private bool isAdminMode = false;

    void OnEnable()
    {
        var root = uiDocument.rootVisualElement;

        // Truy xuất UI
        btnAdmin = root.Q<Button>("btnAdmin");
        if (btnAdmin == null)
        {
            Debug.LogError("btnAdmin is null! Kiểm tra tên nút trong UXML hoặc UI Builder.");
            return;
        }

        Button btnMar = root.Q<Button>("btnMar");
        Debug.Assert(btnMar != null, "btnMar is null!");
        Button btnBol = root.Q<Button>("btnBol");
        Debug.Assert(btnBol != null, "btnBol is null!");
        Button btnAlto = root.Q<Button>("btnAlto");
        Debug.Assert(btnAlto != null, "btnAlto is null!");
        Button btnVeg = root.Q<Button>("btnVeg");
        Debug.Assert(btnVeg != null, "btnVeg is null!");

        Button btnRefresh = root.Q<Button>("btnRefresh");
        Debug.Assert(btnRefresh != null, "btnRefresh is null!");
        Button btnCheckout = root.Q<Button>("btnCheckout");
        Debug.Assert(btnCheckout != null, "btnCheckout is null!");

        totalPriceLabel = root.Q<Label>("totalPriceLabel");
        Debug.Assert(totalPriceLabel != null, "totalPriceLabel is null!");
        incomeLabel = root.Q<Label>("incomeLabel");
        Debug.Assert(incomeLabel != null, "incomeLabel is null!");

        adminPanel = root.Q<VisualElement>("adminPanel");
        Debug.Assert(adminPanel != null, "adminPanel is null!");
        adminHeader = root.Q<VisualElement>("adminHeader");
        Debug.Assert(adminHeader != null, "adminHeader is null!");
        clientHeader = root.Q<VisualElement>("clientHeader");
        Debug.Assert(clientHeader != null, "clientHeader is null!");
        clientPanel = root.Q<VisualElement>("clientPanel");
        Debug.Assert(clientPanel != null, "clientPanel is null!");
        clientBox = root.Q<VisualElement>("clientBox");
        Debug.Assert(clientBox != null, "clientBox is null!");

        // Gắn sự kiện
        btnAdmin.clicked += ToggleAdminMode;

        btnMar.clicked += () => AddToCart(15f);
        btnBol.clicked += () => AddToCart(20f);
        btnAlto.clicked += () => AddToCart(18f);
        btnVeg.clicked += () => AddToCart(17f);

        btnRefresh.clicked += ResetCart;
        btnCheckout.clicked += Checkout;

        // Thiết lập trạng thái UI ban đầu
        SetClientModeUI();

        UpdateTotalPriceLabel();
        UpdateIncomeLabel();
    }

    void AddToCart(float price)
    {
        totalPrice += price;
        UpdateTotalPriceLabel();
    }

    void ResetCart()
    {
        totalPrice = 0f;
        UpdateTotalPriceLabel();
    }

    void Checkout()
    {
        income += totalPrice;
        totalPrice = 0f;
        UpdateTotalPriceLabel();
        UpdateIncomeLabel();
    }

    private void ToggleAdminMode()
    {
        Debug.Log("btnAdmin clicked! Đang chuyển đổi chế độ...");
        isAdminMode = !isAdminMode;

        if (isAdminMode)
        {
            SetAdminModeUI();
        }
        else
        {
            SetClientModeUI();
        }
    }

    void SetAdminModeUI()
    {
        btnAdmin.text = "Client";

        adminPanel.style.display = DisplayStyle.Flex;
        adminHeader.style.display = DisplayStyle.Flex;

        clientHeader.style.display = DisplayStyle.None;
        clientPanel.style.display = DisplayStyle.None;
        clientBox.style.display = DisplayStyle.None;

        totalPriceLabel.style.display = DisplayStyle.None;
        incomeLabel.style.display = DisplayStyle.Flex;
    }

    void SetClientModeUI()
    {
        btnAdmin.text = "Admin";

        adminPanel.style.display = DisplayStyle.None;
        adminHeader.style.display = DisplayStyle.None;

        clientHeader.style.display = DisplayStyle.Flex;
        clientPanel.style.display = DisplayStyle.Flex;
        clientBox.style.display = DisplayStyle.Flex;

        totalPriceLabel.style.display = DisplayStyle.Flex;
        incomeLabel.style.display = DisplayStyle.None;
    }

    void UpdateTotalPriceLabel()
    {
        totalPriceLabel.text = $"Total Price: €{totalPrice:0.00}";
    }

    void UpdateIncomeLabel()
    {
        incomeLabel.text = $"Total Income: €{income:0.00}";
    }
}
