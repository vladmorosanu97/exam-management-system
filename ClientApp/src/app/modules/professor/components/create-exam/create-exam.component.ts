import { Component, OnInit } from '@angular/core';
import { CourseService } from 'src/app/shared/services/course.service';

@Component({
  selector: 'app-create-exam',
  templateUrl: './create-exam.component.html',
  styleUrls: ['./create-exam.component.scss']
})
export class CreateExamComponent implements OnInit {
  dropdownList = [];
  dropdownSettings = {};

  constructor(private _courseServices: CourseService) {}
  ngOnInit() {
    this.dropdownList = [
      { item_id: 1, item_text: 'C2' },
      { item_id: 2, item_text: 'C112' },
      { item_id: 3, item_text: 'C410' },
      { item_id: 4, item_text: 'C413' },
      { item_id: 5, item_text: 'C310' }
    ];
    this.dropdownSettings = {
      singleSelection: false,
      idField: 'item_id',
      textField: 'item_text',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: this.dropdownList.length,
      allowSearchFilter: true
    };

    this._courseServices.getCourses().subscribe(data => {
      console.log(data);
    });
  }
  onItemSelect(item: any) {
    console.log(item);
  }
  onSelectAll(items: any) {
    console.log(items);
  }
}
