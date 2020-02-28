import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { HotelService } from 'src/app/services/hotel.service';
import { RoomService } from 'src/app/services/room.service';
import { Hotel } from 'src/app/models/hotel';
import { Room } from 'src/app/models/room';
import { RoomBooked } from 'src/app/models/room-booked';
import { DataNotification } from 'src/app/models/data-notification';


@Component({
  selector: 'app-room-form',
  templateUrl: './room-form.component.html',
  styleUrls: ['./room-form.component.scss']
})
export class RoomFormComponent implements OnInit {

  hotels: Hotel[] = []
  roomsBooked: RoomBooked[] = [];
  roomForm: FormGroup;
  loading = false;

  constructor(
    private router: Router,
    private fb: FormBuilder,
    private serviceHotel: HotelService,
    private serviceRoom: RoomService) { }

  ngOnInit() {
    this.getHotels();

    this.roomForm = this.fb.group({
      roomId: null,
      name: ['', Validators.required],
      hotelId: ['', Validators.required]
    });
  }

  showHotels() {
    return this.hotels && this.hotels.length > 0;
  }

  save() {
    if (!this.roomForm.valid && !this.roomForm.dirty) {
      return;
    }

    const room = {
      id: null,
      name: this.roomForm.get('name').value,
      hotelId: this.roomForm.get('hotelId').value,
      roomsBooked: this.roomsBooked
    } as Room;

    this.serviceRoom.create(room)
      .subscribe((response: DataNotification) => {
        if (response.success) {
          this.router.navigate(['/rooms']);
        }
    });
  }

  hasRoomsBooked() {
    return this.roomsBooked && this.roomsBooked.length > 0;
  }

  addDate(date: string) {
    if (date == '' || date == null) {
      return;
    }

    const roomBooked = {
      id: null,
      roomId: null,
      date
    } as RoomBooked

    this.roomsBooked.push(roomBooked);
  }

  removeDate(roomBooked) {
    const index = this.roomsBooked.indexOf(roomBooked, 0);
    if (index > -1) {
      this.roomsBooked.splice(index, 1);
    }
  }

  private getHotels() {
    this.loading = true;

    this.serviceHotel.getAll()
      .subscribe((response: Hotel[]) => {
        this.hotels = response;
        this.loading = false;
    });
  }

}
