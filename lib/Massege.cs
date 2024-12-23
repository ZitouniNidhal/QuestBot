using System;
public class Message{
    public string Author {get;set;}
    public string content{get;set;}
    public DateTime TimeSent{get;set;}

    public Message(string author, string content){
        Author = author;
        this.content = content;
        TimeSent = DateTime.Now;
    }
}