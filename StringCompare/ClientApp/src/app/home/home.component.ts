import { Component } from '@angular/core';    
import { FormBuilder } from '@angular/forms';
import { HomeService } from './home.service';
import { CompareStringsModel } from '../Models/CompareStringsModel';
import { PositionResultModel } from '../Models/PositionResultModel';

imports: [
  HomeService,
  FormBuilder
]

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent{
  title = 'Get String Matches';
  formGroup;
  result = "";

  constructor(private formBuilder: FormBuilder, private homeService: HomeService) {
    this.formGroup = this.formBuilder.group({
      MainText: '',
      SubText: ''
    });
  }

  onSubmit(formData) {
    const mod = this.formGroup.value;
    this.CompareStrings(mod); 
  }

  CompareStrings(mod: CompareStringsModel) {
    this.homeService.CompareStrings(mod).subscribe(
      (res: PositionResultModel) => {
        console.log(res);
        if (res.matchesFound == true) {
          this.result = "Matches Found on index " + res.positions;
        }
        else {
          this.result = "No Matches Found";
        }
      });

    
    
  }    
}
