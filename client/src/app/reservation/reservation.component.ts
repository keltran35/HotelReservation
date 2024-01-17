import { NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ReservationService } from '../_services/reservation.service';

@Component({
  selector: 'reservation',
  standalone: true,
  imports: [FormsModule, NgIf, NgbModule],
  templateUrl: './reservation.component.html',
  styleUrl: './reservation.component.css'
})
export class ReservationComponent {
  guests: number;
  result: string;

  constructor(private reservationService: ReservationService) {
    this.guests = 0;
    this.result = '';
  }

  makeReservation() {
    this.reservationService.makeReservation(this.guests)
      .subscribe(
        {
          next: response => {
            if (response.result) {
              this.result = response.result;
            }
          },
          error: error => {
            console.log(error)
          }
        }
      );
  }
}
