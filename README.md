#  Employee Pair Analyzer

A full-stack solution built with **Angular 20** and **.NET 8 Web API** that:

- Accepts a CSV file with employee project assignments
- Analyzes overlapping days between employee pairs on shared projects
- Displays the top employee pair and their shared project breakdown
- Handles multiple date formats 
- Fully styled with Angular Material and displayed in a DataGrid table

---

##  Tech Stack

| Frontend           | Backend             |
|--------------------|---------------------|
| Angular 20         | ASP.NET Core 8 Web API |
| Angular Material   | CsvHelper for CSV parsing |
| RxJS               | CORS enabled         |
| MatTable DataGrid  | Custom date converter |

---

## ⚙️ Environment Setup

Before running the project, make sure you have the following tools installed:

### 1. Node.js & npm

Download and install Node.js (includes npm):  
https://nodejs.org/

Verify installation:

```bash
node -v
npm -v
```

### 2. Angular CLI

Install Angular CLI globally:

```bash
npm install -g @angular/cli
```

Verify Angular installation:

```bash
ng version
```

### 3. .NET 8 SDK

Download and install the .NET 8 SDK:  
https://dotnet.microsoft.com/en-us/download/dotnet/8.0

Verify installation:

```bash
dotnet --version
```

## Running the Project Locally

### 1. Clone the Repository

```bash
git clone https://github.com/mStoyanovDevHub/Mihail-Stoyanov-employees.git
cd Mihail-Stoyanov-employees
```

---

### 2. One-Command Start (Recommended)

>  This command will launch both the frontend and backend:

```bash
cd employees-client
npm install
npm start
```

- Angular frontend runs at `http://localhost:4200`
- .NET backend runs at `http://localhost:5001`

>  Ensure the .NET SDK is accessible in your terminal environment.

---

### 3. Multi-Command Start (Optional)

Start backend (API):

```bash
cd server
dotnet restore
dotnet run
```

Start frontend (Angular):

```bash
cd employees-client
npm install
npm start
```

---

##  CSV Format

Required columns:

```csv
EmpID,ProjectID,DateFrom,DateTo
```

 Notes:
- Supports multiple date formats like:
  - `yyyy-MM-dd`
  - `MM/dd/yyyy`
  - `dd-MM-yyyy`
  - `dd/MM/yyyy`
  - `yyyy-MM-ddTHH:mm:ss`
  - `dd-MMM-yyyy`
- `NULL` as DateTo is treated as today.
- Invalid or malformed rows are handled cleanly.

---

##  Error Handling

-  Invalid CSVs or date formats → Clean UI error in Angular Snackbar
-  Uploading a new file resets state

---

##  License
This project is shared for technical evaluation purposes only. All rights reserved.
