import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-Title',
  templateUrl: './Title.component.html',
  styleUrls: ['./Title.component.scss'],
})
export class TitleComponent implements OnInit {
  @Input() titulo = '';

  constructor() {}

  ngOnInit() {}
}
