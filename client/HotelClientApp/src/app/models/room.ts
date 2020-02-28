import { RoomBooked } from './room-booked';

export class Room {
    id: string;
    name: string;
    hotelId: string;
    roomsBooked: RoomBooked[];

    constructor() {
        this.roomsBooked = [];
    }
}