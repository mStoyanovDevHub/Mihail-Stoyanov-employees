# Employee Pair Analyzer

A full-stack solution built with **Angular** (Material UI) and **.NET 8 Web API** that:

- Accepts a CSV file with employee project assignments
- Analyzes overlapping days between employee pairs on shared projects
- Displays the top employee pair and their shared project breakdown
- Handles multiple date formats (`dd/MM/yyyy`, `yyyy-MM-dd`, etc.)
- Fully styled with Angular Material and DataGrid table

---

##  Tech Stack

| Frontend | Backend |
|----------|---------|
| Angular 20 | .NET 8 Web API |
| Angular Material | CsvHelper for parsing |
| RxJS | CORS enabled |
| MatTable for result view | Custom date converter |

---

## Running the Project Locally

### 1. Clone the repo

```bash
git clone https://github.com/mStoyanovDevHub/Mihail-Stoyanov-employees.git
cd Mihail-Stoyanov-employees

### One-Command Start (Recommended)

> Run this command to launch the entire full-stack project (frontend + backend):

```bash
cd employees-client
npm install
npm start

#### Multi-Command Start

Start the Angular frontend on http://localhost:4200
Start the .NET backend API on http://localhost:5001

This project is shared for evaluation purposes only. All rights reserved.
