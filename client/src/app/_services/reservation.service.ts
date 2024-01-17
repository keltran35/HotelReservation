import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReservationService {
  private baseUrl = 'http://localhost:5263/api'; // Adjust the URL accordingly

  constructor(private http: HttpClient) { }

  makeReservation(guests: number): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/reservation/${guests}`);
  }
}
