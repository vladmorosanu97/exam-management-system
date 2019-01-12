import { AuthService } from 'src/app/shared/services/auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {
  constructor(private _authService: AuthService) {}

  ngOnInit() {}
}
