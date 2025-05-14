import { Component } from '@angular/core';
import { IUser } from '../../core/models/user.model';


@Component({
  templateUrl: 'profile.component.html',
  styleUrls: [ './profile.component.scss' ],
  standalone: false,
})

export class ProfileComponent {
  user: IUser;
  colCountByScreen: object;

  constructor() {
    this.user = {
      name: '',
      middleName: '',
      lastName: '',
      SurName: '',
      identificationTypeId: '',
      identificationNumber: '',
      birthDate: new Date('1974/11/5'),
      address: '',
      contact: '',
    };
    this.colCountByScreen = {
      xs: 1,
      sm: 2,
      md: 3,
      lg: 4
    };
  }
}
