import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProcessingResult } from '../interfaces/interfaces';

@Injectable({
  providedIn: 'root'
})

export class EmployeesService {

  private apiUrl = 'http://localhost:5001/api';

  constructor(
    private http: HttpClient
  ) { }

  uploadCsv(file: File): Observable<ProcessingResult> {
    const formData = new FormData();
    formData.append('file', file, file.name);
    return this.http.post<ProcessingResult>(`${this.apiUrl}/employees/upload`, formData);
  }
}
