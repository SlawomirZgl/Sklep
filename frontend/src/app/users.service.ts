import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PaginatedData } from 'src/model/paginated-data';
import { Pagination } from 'src/model/pagination';
import { User } from 'src/model/user';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private httpClient: HttpClient) { }
  get(pagination?: Pagination): Observable<PaginatedData<User>> {

    if(pagination == null){
      pagination = new Pagination();
      pagination.sortColumn = 'Id';
      pagination.page = 0;
      pagination.rowsPerPage = 10;
      pagination.sortAscending = true;
    }
    return this.httpClient.get<PaginatedData<User>>('https://localhost:44312/api/Users?' +
      'sortColumn=' + pagination.sortColumn +
      '&page='+ pagination.page +
      '&rowsPerPage=' + pagination.rowsPerPage +
      '&sortAscending=' + pagination.sortAscending
    );
  }

  //getByID(id:number): Observable<PaginatedData<User>> {
  //return this.httpClient.get('https://localhost:44312/api/Users/' + id);
  //}
}

