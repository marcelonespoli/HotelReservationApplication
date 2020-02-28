import { Injectable } from '@angular/core';
import { DataService } from './data.service';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class SearchService extends DataService {

  constructor(http: HttpClient) { 
    super(http, 'searches');
  }

  getRoomsAvailablePerPeriod(hotelId: string, startDate: string, endDate: string) {
    const urlApi = this.urlServiceV1 + 'searches/available-rooms/';
    return this.http.get(urlApi + hotelId + '?startDate=' + startDate + '&endDate=' + endDate, this.httpOptions)
    .pipe(  
        catchError((error: Response) => {
        return this.processError(error);
      }));
  }

}
