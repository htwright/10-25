import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'hidive',
    templateUrl: './hidive.component.html'
})
export class HidiveComponent {
    public TitleRows: TitleRow[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/hidive').subscribe(result => {
            this.TitleRows = result.json() as TitleRow[];
            console.log(this.TitleRows);
        }, error => console.error(error));
    }
}

interface TitleRow {
  Name: string;
  Titles: object[];

}
