using System;
using System.Collections.Generic;

namespace ProjectTwo // Note: actual namespace depends on the project name.
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Board board = new Board();
            AddCard(board);
            ListCards(board);
            
        }

        //Kart Listeleme
        static void ListCards(Board board){
            if (board.TODO != null)
            {
                Console.WriteLine("TODO Line");
                Console.WriteLine("********************");
                foreach (var todo in board.TODO)
                {
                    Console.WriteLine("Başlık: "+todo.Name);
                    Console.WriteLine("İçerik: "+todo.Content);
                    Console.WriteLine("Atanana Kişi: "+todo.UserId);
                    Console.WriteLine("Büyüklük: "+todo.Size);
                    Console.WriteLine("-");
                }
            }
            if (board.INPROGRESS != null)
            {
                Console.WriteLine("IN PROGRESS Line");
                Console.WriteLine("********************");
                foreach (var todo in board.TODO)
                {
                    Console.WriteLine("Başlık: "+todo.Name);
                    Console.WriteLine("İçerik: "+todo.Content);
                    Console.WriteLine("Atanana Kişi: "+todo.UserId);
                    Console.WriteLine("Büyüklük: "+todo.Size);
                    Console.WriteLine("-");
                }
            }
            if (board.DONE != null)
            {
                Console.WriteLine("DONE Line");
                Console.WriteLine("********************");
                foreach (var todo in board.TODO)
                {
                    Console.WriteLine("Başlık: "+todo.Name);
                    Console.WriteLine("İçerik: "+todo.Content);
                    Console.WriteLine("Atanana Kişi: "+todo.UserId);
                    Console.WriteLine("Büyüklük: "+todo.Size);
                    Console.WriteLine("-");
                }
            }
        }

        //Kart Ekleme
        static void AddCard(Board board){
            board.TODO  = new List<Card>();
            Card card = new Card();

            List<User> users = new List<User>{
                new User{
                    ID = 1,
                    Name ="Ahmet"
                },
                new User{
                    ID = 2,
                    Name ="Enes"
                },
                new User{
                    ID = 3,
                    Name ="Kemal"
                }
            };
            
            Console.WriteLine("Lutfen kart başlığını giriniz: ");
            card.Name = Console.ReadLine();
            
            Console.WriteLine("Lutfen kart içeriğini giriniz: ");
            card.Content = Console.ReadLine();
            
            Console.WriteLine("Lutfen kullaıcı seçiniz: ");
            foreach (var user in users){
                Console.WriteLine(user.ID + " " +user.Name);
            }
            card.UserId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Lutfen size seçiniz -> XS(1), S(2), M(3), L(4)i XL(5): ");
            card.Size = Convert.ToInt32(Console.ReadLine());

            board.TODO.Add(card);

        }

        
    }
}