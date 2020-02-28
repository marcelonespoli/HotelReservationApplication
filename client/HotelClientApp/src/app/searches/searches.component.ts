import { Component, OnInit } from '@angular/core';
import { HotelService } from '../services/hotel.service';
import { RoomService } from '../services/room.service';
import { Hotel } from '../models/hotel';
import { SearchService } from '../services/search.service';
import { Room } from '../models/room';

@Component({
  selector: 'app-searches',
  templateUrl: './searches.component.html',
  styleUrls: ['./searches.component.scss']
})
export class SearchesComponent implements OnInit {

  hotels: Hotel[] = []
  rooms: Room[] = [];
  hotelId: string;
  startDate: string;
  endDate: string;
  loading = false;
  roomsLoading = false;
  
  constructor(
    private serviceHotel: HotelService,
    private serviceRoom: RoomService,
    private searchService: SearchService) { }

  ngOnInit() {
    this.getHotels();
  }

  showHotels() {
    return this.hotels && this.hotels.length > 0;
  }

  showRooms() {
    return this.rooms && this.rooms.length > 0;
  }

  get isFormValid() {
    return this.hotelId && this.startDate && this.endDate;
  }

  search() {
    if (!this.isFormValid) {
      return;
    }

    this.roomsLoading = true;
    this.searchService.getRoomsAvailablePerPeriod(this.hotelId, this.startDate, this.endDate)
      .subscribe((response: Room[]) => {
        this.rooms = response;
        this.roomsLoading = false;
    });
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
