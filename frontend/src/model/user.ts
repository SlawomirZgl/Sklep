import { BasketItemDto } from "./basket-item";

export interface User {
    id: number;
    login: string;
    password: string;
    name: string;
    surname: string;
    basketItems: BasketItemDto[];
}