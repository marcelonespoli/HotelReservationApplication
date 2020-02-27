import { Component, OnInit } from '@angular/core';
import { Room } from '../models/room';
import { RoomService } from '../services/room.service';
import { Hotel } from '../models/hotel';
import { HotelService } from '../services/hotel.service';

@Component({
  selector: 'app-rooms',
  templateUrl: './rooms.component.html',
  styleUrls: ['./rooms.component.scss']
})
export class RoomsComponent implements OnInit {

  hotels: Hotel[] = []
  rooms: Room[] = [];;
  hotelId: string;
  loading = false;
  roomLoading = false;

  constructor(
    private serviceHotel: HotelService,
    private serviceRoom: RoomService) { }

  ngOnInit() {
    this.getHotels();
  }

  showHotels() {
    return this.hotels && this.hotels.length > 0;
  }

  showRooms() {
    return this.rooms && this.rooms.length > 0;
  }

  hotelChanged(event) {
    if (this.hotelId == event.target.value) {
      return;
    }

    this.hotelId = event.target.value;
    this.getRooms(this.hotelId);
  }

  private getHotels() {
    this.loading = true;

    this.serviceHotel.getAll()
      .subscribe((response: Hotel[]) => {
        this.hotels = response;
        this.loading = false;
    });
  }

  private getRooms(hotelId: string) {
    this.roomLoading = true;

    if (hotelId == '' || hotelId == null) {
      this.rooms = [];
      this.roomLoading = false;
      return;
    }

    this.serviceRoom.getRoomsByHotelId(hotelId)
      .subscribe((response: Room[]) => {
        this.rooms = response;
        this.roomLoading = false;
    });
  }

}
