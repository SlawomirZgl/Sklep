import { Routes } from "@angular/router";
import { BasketListComponent } from "./basket-list/basket-list.component";
import { LoginComponent } from "./login/login.component";
import { ProductsFormComponent } from "./products-form/products-form.component";
import { ProductsListComponent } from "./products-list/products-list.component";
import { UsersListComponent } from "./users-list/users-list.component";

export const APP_ROUTES: Routes = [
    {path: 'products', component: ProductsListComponent},
    {path: 'products/:id', component: ProductsFormComponent},
    {path: 'basket', component: BasketListComponent},
    {path: 'users', component: UsersListComponent},
    {path: 'login', component: LoginComponent},
    {path: '', redirectTo:'products', pathMatch: 'full'},
];
