import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-emp',
  templateUrl: './show-emp.component.html',
  styleUrls: ['./show-emp.component.css']
})
export class ShowEmpComponent implements OnInit {

  constructor(private service: SharedService) {}

  EmployeeList: any = [];

  ModelTitle: string;
  ActivateAddEditEmpComp: boolean = false;
  emp: any;

  ngOnInit(): void {
    this.refreshEmpList();
  }

  addClick() {
    this.emp = {
      EmployeeId: 0,
      EmployeeName: "",
      Department:"",
      DateOfJoining: "",
      PhotoFileName:"anonymous.jpg"
    }
    this.ModelTitle = 'Add Employee';
    this.ActivateAddEditEmpComp = true;
  }

  editClick(item){
    this.emp= item;
    this.ModelTitle = 'Edit Employee';
    this.ActivateAddEditEmpComp=true;
  }

  deleteClick(item) {
    if(confirm("Are you sure?")){
      this.service.deleteEmployee(item.EmployeeId).subscribe(data=>{
        alert(data.toString());
        this.refreshEmpList();
        console.log(data);
      })
    }
  }

  closeClick() {
    this.ActivateAddEditEmpComp = false;
    this.refreshEmpList();
  }

  refreshEmpList() {
    this.service.getEmpList().subscribe((data) => {
      this.EmployeeList = data;
    });
  }
}
