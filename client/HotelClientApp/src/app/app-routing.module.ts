import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HotelsComponent } from './hotels/hotels.component';
import { RoomsComponent } from './rooms/rooms.component';
import { SearchesComponent } from './searches/searches.component';
import { HotelFormComponent } from './hotels/forms/hotel-form.component';
import { RoomFormComponent } from './rooms/forms/room-form.component';


const routes: Routes = [
  { path: '', component: HotelsComponent,  pathMatch: 'full' },
  { path: 'hotels/create', component: HotelFormComponent },
  { path: 'hotels/edit/:hotelId', component: HotelFormComponent },
  { path: 'rooms', component: RoomsComponent },
  { path: 'rooms/add', component: RoomFormComponent },
  { path: 'searches', component: SearchesComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
