import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.css']
})
export class CompanyComponent implements OnInit {
  
  ngOnInit(){
  }

  public modalRef: BsModalRef; 
  constructor(private modalService: BsModalService) { } 

  public openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template); 
  }
}
