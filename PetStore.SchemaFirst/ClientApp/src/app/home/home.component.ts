import { Component } from '@angular/core';
import { PetClient, PetViewModel } from 'src/api/generated';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  constructor(petService: PetClient) {
    this.pets$ = petService.getPets();
  }

  public pets$: Observable<PetViewModel[]>;
}
