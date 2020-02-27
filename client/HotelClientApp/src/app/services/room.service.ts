import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DataService } from './data.service';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class RoomService extends DataService {

  constructor(http: HttpClient) { 
    super(http, 'rooms');
  }

  
  getRoomsByHotelId(hotelId: string) {
    const urlApi = this.urlServiceV1 + 'rooms/hotel/';
    return this.http.get(urlApi + hotelId, this.httpOptions)
    .pipe(  
        catchError((error: Response) => {
        return this.processError(error);
      }));
  }

}
