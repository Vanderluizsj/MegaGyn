import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  public widthImg: number = 7;
  public marginImg: number = 1;
  constructor() { }

  ngOnInit() {
  }

}
