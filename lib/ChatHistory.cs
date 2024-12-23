using System;
using System.Collections.Generic;


public class ChatHistory{
    private List<Message> _messages;
    public ChatHistory()
    {
        _messages = new List<Message>();
    }
    public void AddMessage(Message message ){
        _messages.Add(message);
    }
    public IEnumerable<Message> GetMessages(){
        return _messages;
    }
}