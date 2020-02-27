import { RoomBooked } from './room-booked';

export class Room {
    id: string;
    name: string;
    hotelId: string;
    roomBooked: RoomBooked[];

    constructor() {
        this.roomBooked = [];
    }
}