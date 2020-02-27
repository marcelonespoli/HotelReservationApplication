import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';


import { AppComponent } from './app.component';
import { HotelsComponent } from './hotels/hotels.component';
import { RoomsComponent } from './rooms/rooms.component';
import { SearchesComponent } from './searches/searches.component';
import { HotelFormComponent } from './hotels/forms/hotel-form.component';
import { HotelService } from './services/hotel.service';
import { RoomService } from './services/room.service';
import { SearchService } from './services/search.service';


@NgModule({
  declarations: [
    AppComponent,
    HotelsComponent,
    RoomsComponent,
    SearchesComponent,
    HotelFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [
    HotelService,
    RoomService,
    SearchService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
