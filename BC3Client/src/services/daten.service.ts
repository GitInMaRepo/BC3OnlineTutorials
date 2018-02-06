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
    GetSinglePerson(id: number): Observable<Person> {
        return this.http.get(`http://localhost:8088/${id}`)
        .map((response: Response) => response.json())
        .catch((error: any) => Observable.throw(error.json().error || 'Server error'));
    }
    SaveData(vorname: string, nachname: string): any {

        const person = new Person();
        person.vorname = vorname;
        person.nachname = nachname;

        const requestHeaders = new Headers({'Content-Type': 'application/json'});
        const requestOptions = new RequestOptions({headers: requestHeaders});
        const body = JSON.stringify(person);

        this.http.post('http://localhost:8088/Set', body, requestOptions)
        .catch(this.handleError)
        .subscribe();
    }
    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }
}



