import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { Person } from '../models/model';

@Injectable()
export class DatenService {
    constructor(private http: Http) {}
    LeseDaten (): string {
    return 'Hello World';
    }
    GetData(): Observable<Person> {
        return this.http.get('http://localhost:8088/')
        .map((response: Response) => response.json())
        .catch((error: any) => Observable.throw(error.json().error || 'Server error'));
    }
    GetAllData(): Observable<Person[]> {
        return this.http.get('http://localhost:8088/All')
        .map((response: Response) => response.json())
        .catch((error: any) => Observable.throw(error.json().error || 'Server error'));
    }
}
