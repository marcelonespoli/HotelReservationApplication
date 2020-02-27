import { Component, OnInit } from '@angular/core';
import { HotelService } from '../services/hotel.service';
import { Hotel } from '../models/hotel';

@Component({
  selector: 'app-hotels',
  templateUrl: './hotels.component.html',
  styleUrls: ['./hotels.component.scss']
})
export class HotelsComponent implements OnInit {

  hotels: Hotel[] = [];;
  loading = false;

  constructor(private service: HotelService) { }

  ngOnInit() {
    this. getHotels();
  }

  showHotels() {
    return this.hotels && this.hotels.length > 0;
  }

  private getHotels() {
    this.loading = true;

    this.service.getAll()
      .subscribe((response: Hotel[]) => {
        this.hotels = response;
        this.loading = false;
    });
  }

}
