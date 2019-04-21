import { Component } from '@angular/core';
import { PetService } from 'src/api/generated/services';
import { Pet } from 'src/api/generated/models';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  constructor(private petService: PetService) {
    this.pets$ = petService.GetPets();
  }

  public pets$: Observable<Pet[]>;
}
