import { Injectable } from '@angular/core';
import { Company } from './Company';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  private companiesUrl = 'https://localhost:44379/api/company';  

  constructor(private http: HttpClient) { }

  getCompanies() {
    return this.http.get<Company[]>(this.companiesUrl);
  }
}
