using System;
using System.Collections.Generic;
using System.Text;

namespace DockerTraining.Shared
{
    public class Item  
    {  
        public int Id { get; set; }
        public string Title { get; set; }  
        public bool IsComplete { get; set; } = false;  

        public Item(string title)  
        {  
            Title = title; 

        }  
    }  
}