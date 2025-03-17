using System;
using System.Collections.Generic;

namespace HotelManagementSystem
{
    
    public class Room
    {
        public int RoomNumber { get; set; }
        public string Type { get; set; }
        public bool IsBooked { get; set; }

        public Room(int roomNumber, string type)
        {
            RoomNumber = roomNumber;
            Type = type;
            IsBooked = false;
        }
    }

    
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }

        public Customer(int customerId, string name)
        {
            CustomerId = customerId;
            Name = name;
        }
    }

   
    public class Booking
    {
        public Room Room { get; set; }
        public Customer Customer { get; set; }
        public DateTime BookingDate { get; set; }

        public Booking(Room room, Customer customer)
        {
            Room = room;
            Customer = customer;
            BookingDate = DateTime.Now;
        }
    }

    
    public class Hotel
    {
        private List<Room> rooms = new List<Room>();
        private List<Customer> customers = new List<Customer>();
        private List<Booking> bookings = new List<Booking>();

        
        public void AddRoom(int roomNumber, string type)
        {
            rooms.Add(new Room(roomNumber, type));
            Console.WriteLine($"Room {roomNumber} added.");
        }

        
        public void AddCustomer(int customerId, string name)
        {
            customers.Add(new Customer(customerId, name));
            Console.WriteLine($"Customer {name} added.");
        }

        
        public void BookRoom(int roomNumber, int customerId)
        {
            Room room = rooms.Find(r => r.RoomNumber == roomNumber && !r.IsBooked);
            Customer customer = customers.Find(c => c.CustomerId == customerId);

            if (room != null && customer != null)
            {
                room.IsBooked = true;
                bookings.Add(new Booking(room, customer));
                Console.WriteLine($"Room {roomNumber} booked by {customer.Name}.");
            }
            else
            {
                Console.WriteLine("Room not available or customer not found.");
            }
        }

        
        public void ListRooms()
        {
            Console.WriteLine("Rooms:");
            foreach (var room in rooms)
            {
                Console.WriteLine($"Room {room.RoomNumber}, Type: {room.Type}, Booked: {room.IsBooked}");
            }
        }

        
        public void ListCustomers()
        {
            Console.WriteLine("Customers:");
            foreach (var customer in customers)
            {
                Console.WriteLine($"ID: {customer.CustomerId}, Name: {customer.Name}");
            }
        }

        
        public void ListBookings()
        {
            Console.WriteLine("Bookings:");
            foreach (var booking in bookings)
            {
                Console.WriteLine($"Room {booking.Room.RoomNumber} booked by {booking.Customer.Name} on {booking.BookingDate}");
            }
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            Hotel hotel = new Hotel();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nHotel Management System");
                Console.WriteLine("1. Add Room");
                Console.WriteLine("2. Add Customer");
                Console.WriteLine("3. Book Room");
                Console.WriteLine("4. List Rooms");
                Console.WriteLine("5. List Customers");
                Console.WriteLine("6. List Bookings");
                Console.WriteLine("7. Exit");
                Console.Write("Select option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Enter Room Number: ");
                        int roomNumber = int.Parse(Console.ReadLine());
                        Console.Write("Enter Room Type: ");
                        string type = Console.ReadLine();
                        hotel.AddRoom(roomNumber, type);
                        break;
                    case "2":
                        Console.Write("Enter Customer ID: ");
                        int customerId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Customer Name: ");
                        string name = Console.ReadLine();
                        hotel.AddCustomer(customerId, name);
                        break;
                    case "3":
                        Console.Write("Enter Room Number to Book: ");
                        int bookRoomNumber = int.Parse(Console.ReadLine());
                        Console.Write("Enter Customer ID: ");
                        int bookCustomerId = int.Parse(Console.ReadLine());
                        hotel.BookRoom(bookRoomNumber, bookCustomerId);
                        break;
                    case "4":
                        hotel.ListRooms();
                        break;
                    case "5":
                        hotel.ListCustomers();
                        break;
                    case "6":
                        hotel.ListBookings();
                        break;
                    case "7":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}