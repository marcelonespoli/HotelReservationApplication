import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DataService } from './data.service';

@Injectable({
  providedIn: 'root'
})
export class RoomService extends DataService {

  constructor(http: HttpClient) { 
    super(http, 'rooms');
  }

}
