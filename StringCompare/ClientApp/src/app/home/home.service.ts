
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { CompareStringsModel } from '../Models/CompareStringsModel';
import { PositionResultModel } from '../Models/PositionResultModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class HomeService {
  Url: string;
  header: any;
  constructor(private http: HttpClient) {
    this.Url = 'https://localhost:44334/api/StringComparison/';
    this.header = new HttpHeaders().set("Content-Type", "application/json");
  }
  public CompareStrings(model: CompareStringsModel): Observable<PositionResultModel> {
    console.log(this.Url + 'CompareStrings');
    console.log(model);
    return this.http.post<PositionResultModel>(this.Url + 'CompareStrings', model, { headers: this.header });
  }
}
