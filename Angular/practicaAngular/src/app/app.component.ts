import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MyPopUpComponent } from './componentes/my-pop-up/my-pop-up.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'practicaAngular';
  constructor(public dialog: MatDialog) { }

  openDialog(messaga: string): void {
    const dialogRef = this.dialog.open(MyPopUpComponent, {
      width: '360px',
      data: messaga,
    })
  }
}
