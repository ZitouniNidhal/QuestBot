using System;
using System.Collections.Generic;


public class BotLogic{
    private Dictionary<string,string> _responses;
    public BotLogic()
    {
        _responses = new Dictionary<string, string>();
        _responses.Add("Hello", "Hello! How can I help you today?");
        _responses.Add("How are you?", "I'm a chatbot, I don't have feelings.");
        _responses.Add("What is your name?", "I'm a chatbot, I don't have a name.");
        _responses.Add("What is the time?", DateTime.Now.ToString("hh:mm tt"));
        _responses.Add("What is the date?", DateTime.Now.ToString("MM/dd/yyyy"));
    }

     public string GetResponse(string userMessage)
  {
    string lowerMessage = userMessage.ToLower();
    if(_responses.ContainsKey(lowerMessage)){
        return _responses[lowerMessage];
    }
    else{
        return "I'm sorry, I don't understand.";
    }
}
}