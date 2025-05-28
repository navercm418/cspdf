# Accounting Report PDF Generator

## 📌 Project Overview
This project is a **standalone C# script** that generates **PDF accounting reports** **without** relying on third-party libraries. It creates a structured **financial report**, including:
- **A company logo** (top-left).
- **A centered report title**.
- **A structured table with 12 columns** for financial data.
- **A totals row** at the bottom.

Everything is manually written in **raw PDF format**, ensuring **full flexibility** to adjust layout, styling, and content.

---

## 🚀 Key Features
✅ **Standalone C# solution** (no dependencies).  
✅ **Embeds a company logo** in the top-left.  
✅ **Flexible table formatting** with 12 columns.  
✅ **Dynamic row generation** for financial data.  
✅ **Customizable structure** for future enhancements.  
✅ **Readable & well-commented code** for easy modifications.  

---

## ⚙️ Installation & Usage
### 📥 Prerequisites
- **.NET SDK** (C# compiler)
- **Basic knowledge of text-based PDF structuring** (optional, script handles this automatically)

### ▶️ Compile & Run
1. **Clone the Repository**
   ```sh
   git clone https://github.com/YourUsername/AccountingReportGenerator.git
   cd AccountingReportGenerator
   ```

2. **Compile & Run**
   ```sh
   dotnet run
   ```

3. **Generated PDF**
   - `AccountingReport.pdf` will be created in the same directory.

---

## 📑 Usage Example
### Example Report Format
Generated PDF structure:
```
-----------------------------------------------------------
| [Company Logo] |               Accounting Report        |
-----------------------------------------------------------
| ID | Date | Client | Description | Debit | Credit | ... |
-----------------------------------------------------------
| 01 | 05/01 | ABC Co. | Service Fee | 1000 | 0 | ...  |
| 02 | 05/02 | XYZ Ltd | Software Dev | 2000 | 500 | ...  |
-----------------------------------------------------------
|             TOTALS              | $3000 | $500 | ...   |
-----------------------------------------------------------
```

---

## 🔧 Customization Guide
The script is designed to be **easily adjustable** for different report formats. Below are key modifications users might want to make.

### 📌 Edit Report Title
To change the **title** at the top-center of the report, update this line inside `CreatePDF()`:
```csharp
writer.WriteLine("BT /F1 16 Tf 200 720 Td (Accounting Report - Q1 2025) Tj ET");
```
Replace `"Accounting Report - Q1 2025"` with **your own title**.

### 🖼️ Modify Company Logo
To update the **company logo**, change the **image file path**:
```csharp
string companyLogoPath = "new_logo.jpg";
```
Ensure the image format is **JPEG** or **PNG**.

### 📊 Change Table Column Names
Modify this array to **update column headers**:
```csharp
string[] columnHeaders = { "ID", "Date", "Client", "Transaction", "Debit", "Credit", "Balance", "Tax", "Discount", "Net", "Approval", "Notes" };
```
Adjust the **column width** if needed.

### 📈 Increase Row Count
Modify the **loop generating rows**:
```csharp
for (int row = 0; row < 20; row++) // Now 20 rows
```
This controls **how many rows appear** in the report table.

---

## 🚀 Future Enhancements
🔹 **Dynamic font embedding** for better typography.  
🔹 **Better table formatting** (alignment, column width control).  
🔹 **Integration with a database or CSV for automatic data input**.  
🔹 **Optional graph/chart generation for financial visualization**.  

---

## 🤝 Contributing
Feel free to modify and enhance this project! Open an issue or submit a pull request if you have improvements.

---

## 📜 License
This project is **open-source** under the MIT License.
