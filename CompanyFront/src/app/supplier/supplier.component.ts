import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';


@Component({
  selector: 'app-supplier',
  templateUrl: './supplier.component.html',
  styleUrls: ['./supplier.component.css']
})
export class SupplierComponent implements OnInit {

  ngOnInit(){
  }

  public modalRef: BsModalRef; 
  constructor(private modalService: BsModalService) { } 

  public openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template); 
  }

}
