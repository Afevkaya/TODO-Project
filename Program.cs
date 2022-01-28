using System;
using System.Collections.Generic;

namespace ProjectTwo // Note: actual namespace depends on the project name.
{
    
    class Program
    {
        
        
        static void Main(string[] args)
        {
            Board board = new Board();

            board.TODO  = new List<Card>();
            board.DONE = new List<Card>();
            board.INPROGRESS = new List<Card>();

            Menu(board);
            
        }

        static void Menu(Board board){
            
            int selection;

            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Board Listelemek");
            Console.WriteLine("(2) Borad'a Kart Eklemek");
            Console.WriteLine("(3) Board'dan Kart Silmek");
            Console.WriteLine("(4) Kart Taşımak");

            selection = Convert.ToInt32(Console.ReadLine());
            if (selection == 1)
            {
                AddCard(board);
            }
            else if(selection == 2)
            {
                ListCards(board);
            }
            else if(selection == 3)
            {
                Remove(board);
            }
            else if(selection == 4)
            {
                Transport(board);
            }
            else
            {
                Console.WriteLine("Yanlış seçim yaptınız.");
                Environment.Exit(0);
            }
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
                foreach (var inprogress in board.INPROGRESS)
                {
                    Console.WriteLine("Başlık: "+inprogress.Name);
                    Console.WriteLine("İçerik: "+inprogress.Content);
                    Console.WriteLine("Atanana Kişi: "+inprogress.UserId);
                    Console.WriteLine("Büyüklük: "+inprogress.Size);
                    Console.WriteLine("-");
                }
            }
            if (board.DONE != null)
            {
                Console.WriteLine("DONE Line");
                Console.WriteLine("********************");
                foreach (var done in board.DONE)
                {
                    Console.WriteLine("Başlık: "+done.Name);
                    Console.WriteLine("İçerik: "+done.Content);
                    Console.WriteLine("Atanana Kişi: "+done.UserId);
                    Console.WriteLine("Büyüklük: "+done.Size);
                    Console.WriteLine("-");
                }
            }
        }

        //Kart Ekleme
        static void AddCard(Board board){
            
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

        //Kart Silme
        static void Remove(Board board){
            string cardName = "";
            Card card = null;

            Console.WriteLine("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.");
            Console.WriteLine("Kart başlığını giriniz: ");
            cardName = Console.ReadLine();

            if (board.TODO != null)   
            {
                foreach (var todo in board.TODO)
                {
                    if (cardName == todo.Name)
                    {
                        card = todo;
                        break;
                    }
                    
                }
                if (card != null)
                {
                    board.TODO.Remove(card);
                }
                else
                {
                    RemoveMessage(board);
                }
                
            }

            if(board.INPROGRESS != null)
            {
                if (card != null)
                {
                    foreach (var inprogress in board.INPROGRESS)
                    {
                        if (cardName == inprogress.Name)
                        {
                            card = inprogress;
                            board.INPROGRESS.Remove(card);
                            break;
                        }
                        RemoveMessage(board);
                    }
                }
            }
            if (board.DONE != null)
            {
                if (card != null)
                {
                    foreach (var done in board.DONE)
                    {
                        if (cardName == done.Name)
                        {
                            card = done;
                            board.DONE.Remove(card);
                            break;
                        }
                    }
                    RemoveMessage(board);
                }

            }
                
            
        }

        static void Transport(Board board){
            string cardName = "";
            string line = "TODO";
            Console.WriteLine("Öncelikle taşımak istediğiniz kartı seçmeniz gerekiyor.");
            Console.WriteLine("Lütfen kart başlığını yazınız: ");
            cardName = Console.ReadLine();

            Card card = null;

            if(board.TODO != null)
            {
                foreach (var todo in board.TODO)
                {   
                    if (cardName == todo.Name)
                    {
                        card = todo;
                        line = "TODO";
                        board.TODO.Remove(card);
                        break;
                    }
                }
                
            }
            else if (board.INPROGRESS != null)
            {   
                foreach (var inprogress in board.INPROGRESS)
                {
                    if (cardName == inprogress.Name)
                    {
                        card = inprogress;
                        line = "INPROGRESS";
                        board.INPROGRESS.Remove(card);
                        break; 
                    }
                }   
            }
            else if (board.DONE != null)
            {
                foreach (var done in board.DONE)
                {
                    if (cardName == done.Name)
                    {
                        card = done;
                        line = "DONE";
                        board.DONE.Remove(card);
                        break;
                    }
                }
            }

            if (card != null)
            {
                int selection;

                Console.WriteLine("Bulunan Kart Bilgileri: ");
                Console.WriteLine("****************************************");
                Console.WriteLine("Başlık: " + card.Name);
                Console.WriteLine("İçerik: "+card.Content);
                Console.WriteLine("Atanan Kişi: "+card.UserId);
                Console.WriteLine("Büyüklük: "+card.Size);
                Console.WriteLine("Line: " +line);

                Console.WriteLine("Lütfen taşımak istediğiniz Line'ı seçiniz: ");
                Console.WriteLine("(1) TODO");
                Console.WriteLine("(2) IN PROGRESS");
                Console.WriteLine("(3) DONE");

                selection = Convert.ToInt32(Console.ReadLine());
                if (selection == 1)
                {
                    board.TODO.Add(card);
                }
                else if(selection == 2)
                {
                    board.INPROGRESS.Add(card);
                }
                else if (selection == 3)
                {
                    board.DONE.Add(card);
                }
                else
                {
                    Console.WriteLine("Hatalı bir seçim yaptınız!");
                    Environment.Exit(0);
                }  
            }
            else
            {
                TransportMessage(board);
            }

        }

        //Silme mesajı
        static void RemoveMessage(Board board){
            int selection;
            Console.WriteLine("Aradığınız kriterlere uygyn kart board'da bulunamadı. Lütfen bir seçim yapınız.");
            Console.WriteLine("* Silmeyi sonlandırmak için: (1)");
            Console.WriteLine("* Yeniden denemek için: (2)");
            selection = Convert.ToInt32(Console.ReadLine());
            if (selection == 1)
            {
                Environment.Exit(0);
            }
            if (selection == 2)
            {
                Remove(board);
            }
        }

        //Taşıma Mesajı
        static void TransportMessage(Board board){
            int selection;
            Console.WriteLine("Aradığınız kriterlere uygyn kart board'da bulunamadı. Lütfen bir seçim yapınız.");
            Console.WriteLine("* Silmeyi sonlandırmak için: (1)");
            Console.WriteLine("* Yeniden denemek için: (2)");
            selection = Convert.ToInt32(Console.ReadLine());
            if (selection == 1)
            {
                Environment.Exit(0);
            }
            if (selection == 2)
            {
                Transport(board);
            }

        }

    }
}