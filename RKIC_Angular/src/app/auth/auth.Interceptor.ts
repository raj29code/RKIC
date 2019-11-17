import { HttpInterceptor, HttpRequest, HttpHandler, HttpUserEvent, HttpEvent } from "@angular/common/http";
import { Observable } from 'rxjs';
import { UserService } from "../shared/user.service";

import { Injectable } from "@angular/core";
import { Router } from "@angular/router";

import { map, filter, tap } from 'rxjs/operators';
import { HttpResponse } from "@angular/common/http";


 
@Injectable()
export class AuthInterceptor implements HttpInterceptor {
 
    constructor(private router: Router) { }
 
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (req.headers.get('No-Auth') == "True")
            return next.handle(req.clone());
            debugger;
        if (localStorage.getItem('userToken') != null) {
            const clonedreq = req.clone({
                headers: req.headers.set("Authorization", "Bearer " + localStorage.getItem('userToken'))
            });
            return next.handle(clonedreq)
                .pipe(
                // succ => { },
                // err => {
                //     if (err.status === 401)
                //         this.router.navigateByUrl('/login');
                // }
                tap(event => {
                    if (event instanceof HttpResponse) {
                        
                    }
                  }, error => {
                    if(error.status===401)
                    {
                        this.router.navigateByUrl('/login');
                    }
                  })
                );
        }
        else {
            this.router.navigateByUrl('/login');
        }
    }
}