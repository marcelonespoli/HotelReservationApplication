import { Component, OnInit } from '@angular/core';
import { HotelService } from '../services/hotel.service';
import { RoomService } from '../services/room.service';
import { Hotel } from '../models/hotel';

@Component({
  selector: 'app-searches',
  templateUrl: './searches.component.html',
  styleUrls: ['./searches.component.scss']
})
export class SearchesComponent implements OnInit {

  hotels: Hotel[] = []
  hotelId: string;
  startDate: string;
  endDate: string;
  loading = false;
  
  constructor(
    private serviceHotel: HotelService,
    private serviceRoom: RoomService) { }

  ngOnInit() {
    this.getHotels();
  }

  showHotels() {
    return this.hotels && this.hotels.length > 0;
  }

  get isFormValid() {
    return this.hotelId && this.startDate && this.endDate;
  }

  search() {
    if (!this.isFormValid) {
      return;
    }

    alert(1);
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
