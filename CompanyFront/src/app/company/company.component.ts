import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { CompanyService } from '../company.service';
import { Company } from '../Company';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.css']
})
export class CompanyComponent implements OnInit {
  
  companies: Company[];
  
  ngOnInit(){
    this.getCompanies();
  }

  public modalRef: BsModalRef; 
  constructor(private modalService: BsModalService, private companyService: CompanyService) { } 

  public getCompanies(): void{
    this.companyService.getCompanies().subscribe(res => this.companies=res);
  }

  public openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template); 
  }
}
