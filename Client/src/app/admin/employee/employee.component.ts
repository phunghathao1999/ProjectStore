import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { People } from 'src/app/Models/People';
import { PeopleServer } from 'src/app/Server/people.server';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  employees!: People[];
  displayedColumns: string[] = ['ID', 'fullName', 'telephone', 'email', 'birthday', 'joinDay', 'status', 'role'];
  
  constructor(
    private employeeServer: PeopleServer,
    public dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.employeeServer.getEmployees()
      .subscribe((result: People[]) => this.employees = result);
  }

}
