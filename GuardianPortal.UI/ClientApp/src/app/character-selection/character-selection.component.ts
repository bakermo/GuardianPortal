import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-character-selection',
  templateUrl: './character-selection.component.html',
  styleUrls: ['./character-selection.component.css']
})
export class CharacterSelectionComponent implements OnInit {
  public profile: any; //TODO: make this strongly typed
  constructor(http: HttpClient) {
    console.log('loading character data');
    http.get('/api/profile/character').subscribe((response: any) => {
      let resp = response;
      this.profile = resp.response.characters.data
      console.log('profile ==', this.profile);
    }, error => console.error(error));
  }

  ngOnInit() {
  }

}
