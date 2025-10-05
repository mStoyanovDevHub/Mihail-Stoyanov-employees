import { Component, ElementRef, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { EmployeesService } from '../../services/employees-service';
import { ProcessingResult } from '../../interfaces/interfaces';

@Component({
  selector: 'app-upload',
  standalone: true,
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatProgressSpinnerModule,
    MatCardModule,
    MatTableModule,
    MatIconModule,
    MatSnackBarModule 
  ],
  templateUrl: './upload.html',
  styleUrl: './upload.css'
})

export class UploadComponent {
  selectedFile?: File;
  result?: ProcessingResult;
  isLoading: boolean = false;
  error?: string;
  @ViewChild('fileInput') fileInput!: ElementRef;

  constructor(
    private employeesService: EmployeesService,
    private snackBar: MatSnackBar
  ) { }

  onFileSelected(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (!input.files?.length) return;

    this.selectedFile = input.files[0];
    this.isLoading = true;
    this.error = undefined;

    this.employeesService.uploadCsv(this.selectedFile).subscribe({
      // ✅ Only success here
      next: (res: ProcessingResult) => {
        this.result = res;
        this.isLoading = false;
        this.snackBar.open('Analysis complete', 'Close', { duration: 3000 });
        this.fileInput.nativeElement.value = '';
      },

      // ✅ Only error handling here
      error: (err) => {
        this.result = undefined;
        this.isLoading = false;

        const errorMessage = err?.error?.message || 'Unexpected error occurred.';
        this.snackBar.open(`Error: ${errorMessage}`, 'Close', {
          duration: 5000,
          panelClass: 'snack-error'
        });

        this.fileInput.nativeElement.value = '';
      }
    });
  }


}
