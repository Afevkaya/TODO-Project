using System;
using System.Collections.Generic;

namespace ProjectTwo // Note: actual namespace depends on the project name.
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Board board = new Board();
            ListCards(board);
        }

        //Kart Listeleme
        static void ListCards(Board board){
            foreach (var todo in board.TODO)
            {
                Console.WriteLine(todo.Name);
            }
            foreach (var inprogress in board.INPROGRESS)
            {
                Console.WriteLine(inprogress.Name);
            }
            foreach (var done in board.DONE)
            {
                Console.WriteLine(done.Name);
            }
        }

        //Kart Ekleme
        static void AddCard(Board board){
            
        }
    }
}