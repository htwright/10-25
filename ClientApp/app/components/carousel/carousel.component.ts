import { Component, Input } from '@angular/core';

@Component({
    selector: 'carousel',
    templateUrl: './carousel.component.html'
})
export class CarouselComponent {
  @Input() arr:Array<any>;
  items:Array<any> = [];
  constructor(){
    this.items = this.arr;
  }
}
