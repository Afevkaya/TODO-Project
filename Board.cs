using System;
using System.Collections.Generic;

namespace ProjectTwo // Note: actual namespace depends on the project name.
{
    // Kartların tutulduğu sınıf - Tahta sınıfı
    class Board
    {
        public List<Card> TODO { get; set; } 
        public List<Card> INPROGRESS { get; set; }
        public List<Card> DONE { get; set; }

    }
}