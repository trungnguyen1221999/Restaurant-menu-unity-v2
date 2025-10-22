# Unity UI Toolkit - Admin & Client Mode with PIN Code

This Unity project demonstrates a simple UI built with **UI Toolkit** featuring:

- A client mode for adding items to a cart and checking out
- An admin mode to view total income
- A PIN code input field (using `IntegerField`) to authenticate access and reveal admin controls
- Responsive UI logic to switch between modes
- Compatibility with Android devices (including numeric keyboard support)

---

## Features

- **IntegerField PIN input:** Accepts only numeric input, triggers admin UI reveal when the correct PIN is entered (`1234` by default).
- **Toggle Admin/Client mode:** A button to switch between user and admin interfaces.
- **Cart system:** Add different priced items, reset cart, and checkout.
- **Dynamic UI updates:** Labels update in real-time to reflect current totals and income.
- **Mobile support:** Ensures numeric keyboard opens on Android for PIN input.

---

---

## PIN Code

- The PIN is hardcoded as `1234` in the script (variable `correctPin`).
- On entering the correct PIN, the admin label appears and the PIN input hides.
- You can customize the PIN by modifying the `correctPin` variable in `MainUIController.cs`.

---

## Notes

- UI Toolkit's `IntegerField` is used for PIN input to ensure numeric input only.
- `pinCodeInput.isDelayed = true` is set to reduce event firing on every keypress.
- Focus is managed to open the numeric keyboard on Android devices.
- Make sure your UXML and USS files match the element names used in the script.

---

For questions or support, please open an issue or contact the author.

