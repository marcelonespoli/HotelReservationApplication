import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Hotel } from 'src/app/models/hotel';
import { HotelService } from 'src/app/services/hotel.service';
import { DataNotification } from 'src/app/models/data-notification';

@Component({
  selector: 'app-hotel-form',
  templateUrl: './hotel-form.component.html',
  styleUrls: ['./hotel-form.component.scss']
})
export class HotelFormComponent implements OnInit {

  title: string;
  editHotelId: string;
  hotelForm: FormGroup;

  constructor(
    private router: Router,
    private fb: FormBuilder,
    private service: HotelService,
    private route: ActivatedRoute,
  ) { 
    const id = this.route.snapshot.paramMap.get('hotelId');
    if (id)  {
      this.editHotelId = id;
      this.title = 'Edit Hotel';
      this.loadHotelToEdit(id);
    } else {
      this.title = 'Create Hotel';
    }
  }

  ngOnInit() {
    this.hotelForm = this.fb.group({
      hoteId: null,
      name: ['', Validators.required],
      address: ['', Validators.required],
      city: ['', Validators.required],
      phone: ['', Validators.required],
      stars: [0, Validators.required]
    });
  }

  save() {
    if (!this.hotelForm.valid && !this.hotelForm.dirty) {
      return;
    }

    const hotel = {
      id: null,
      name: this.hotelForm.get('name').value,
      address: this.hotelForm.get('address').value,
      city: this.hotelForm.get('city').value,
      phone: this.hotelForm.get('phone').value,
      stars: this.hotelForm.get('stars').value
    } as Hotel;

    if (this.editHotelId) {
      hotel.id = this.editHotelId;
      this.service.update(hotel)
        .subscribe((response: DataNotification) => {
          if (response.success) {
            this.router.navigate(['/']);
          }
      });
      return;
    }

    this.service.create(hotel)
      .subscribe((response: DataNotification) => {
        if (response.success) {
          this.router.navigate(['/']);
        }
    });
  }

  cancel() {
    this.router.navigate(['/']);
  }
  
  private loadHotelToEdit(id: string) {
    this.service.getById(id)
    .subscribe((response: Hotel) => {      
      this.populateHotelForm(response);
    });
  }

  private populateHotelForm(hotel: Hotel) {
    this.hotelForm.get('hoteId').setValue(hotel.id);
    this.hotelForm.get('name').setValue(hotel.name);
    this.hotelForm.get('address').setValue(hotel.address);
    this.hotelForm.get('city').setValue(hotel.city);
    this.hotelForm.get('phone').setValue(hotel.phone);
    this.hotelForm.get('stars').setValue(hotel.stars);
  }

}
