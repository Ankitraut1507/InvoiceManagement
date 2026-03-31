# 📄 Invoice Management CRM

## 📌 Project Overview

The **Invoice Management CRM** is a full-stack application designed to manage customers, quotes, invoices, and payments efficiently. It provides a structured workflow starting from customer creation → quote generation → invoice creation → payment tracking.

This system ensures proper financial tracking, data consistency, and scalable business operations.

---

## 🚀 Features

* 👤 Customer Management
* 📑 Quote Generation & Tracking
* 🧾 Invoice Creation & Lifecycle Management
* 📦 Line Item Management for Invoices
* 💳 Payment Tracking with Methods
* 📊 Tax, Discount & Total Calculations
* 🗂️ Status Tracking (Active, Archived, etc.)

---

## 🏗️ System Architecture (High-Level Flow)

```
Customer → Quote → Invoice → Invoice Line Items → Payment
```

* A **Customer** can create multiple **Quotes**
* A **Quote** can be converted into an **Invoice**
* An **Invoice** contains multiple **Line Items**
* An **Invoice** can receive multiple **Payments**
* Each **Payment** uses a **Payment Method**

---

## 🧩 Database Design (ER Diagram)

![ER Diagram](./ER%20Diagram.jpeg)

---

## 🗃️ Entities Description

### 👤 Customer

* Stores customer details like name, email, phone, GST number
* Maintains account status and creation date

### 📑 Quote

* Represents price estimation before invoice generation
* Includes validity (expiry date), tax, discount, and totals

### 🧾 Invoice

* Generated from quotes or directly for a customer
* Tracks payment status, subtotal, tax, discount, and grand total

### 📦 Invoice Line Item

* Individual items/services in an invoice
* Includes quantity, unit price, tax, discount, and total

### 💳 Payment

* Records payments made against invoices
* Includes payment method, amount, and reference details

### 🏦 Payment Method

* Defines payment types (UPI, Card, Cash, etc.)
* Helps standardize payment tracking

---

## 🔗 Relationships

* **Customer → Quote** (1:N)
* **Customer → Invoice** (1:N)
* **Quote → Invoice** (1:1 or 1:N depending on conversion)
* **Invoice → Line Items** (1:N)
* **Invoice → Payment** (1:N)
* **Payment → Payment Method** (N:1)

---

## 🛠️ Tech Stack (Expected)

### Frontend

* React (SPA)
* Vite
* CSS / Tailwind (optional)

### Backend

* .NET / Node.js (based on your implementation)

### Database

* SQL Server / MySQL / PostgreSQL

---

## 📁 Suggested Folder Structure

```
project-root/
│
├── frontend/
│   ├── components/
│   ├── pages/
│   ├── services/
│   └── App.jsx
│
├── backend/
│   ├── Controllers/
│   ├── Models/
│   ├── Services/
│   └── DbContext/
│
├── database/
│   └── schema.sql
│
├── ER Diagram.jpeg
└── README.md
```

---

## ⚙️ Setup Instructions

### 1. Clone Repository

```bash
git clone <repo-url>
cd invoice-management-crm
```

### 2. Frontend Setup

```bash
cd frontend
npm install
npm run dev
```

### 3. Backend Setup

```bash
cd backend
dotnet run
# OR
npm install && npm start
```

### 4. Database Setup

* Create database
* Run schema SQL script
* Update connection string

---

## 📊 Key Functional Flow

1. Create Customer
2. Generate Quote
3. Convert Quote → Invoice
4. Add Line Items
5. Calculate totals (Tax, Discount)
6. Record Payments
7. Track Invoice Status

---

## 👨‍💻 Team Members

* **Ankit Raut**
* **Darshan Badgujar**
* **Aayush Kadam**

---

## 📌 Future Enhancements

* Authentication & Authorization (JWT)
* Dashboard Analytics
* PDF Invoice Generation
* Email Notifications
* Role-Based Access Control

---

## 📄 License

This project is developed for learning and evaluation purposes.

---
