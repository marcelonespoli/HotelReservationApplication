import { Room } from './room';

export class Hotel {
    id: string;
    name: string;
    address: string;
    city: string;
    phone: string;
    stars: number;
    rooms: Room[]

    constructor() {
        this.rooms = [];
    }
}