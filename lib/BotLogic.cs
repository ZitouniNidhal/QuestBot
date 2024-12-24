using System;
using System.Collections.Generic;

namespace QuestBot
{
    public class BotLogic
    {
        // Use a case-insensitive dictionary for responses
        private readonly Dictionary<string, string> _responses;

        public BotLogic()
        {
            _responses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "Hello", "Hello! How can I help you today?" },
                { "How are you?", "I'm a chatbot, I don't have feelings." },
                { "What is your name?", "I'm a chatbot, I don't have a name." },
                { "What is the time?", GetCurrentTime() } // Call method to get current time
            };
        }

        // Method to get the current time as a string
        private string GetCurrentTime()
        {
            return DateTime.Now.ToString("hh:mm tt");
        }

        // Method to get a response based on user input
        public string GetResponse(string userMessage)
        {
            // Check if the message matches any key in the dictionary
            if (_responses.TryGetValue(userMessage, out string response))
            {
                return response;
            }
            else
            {
                return "I'm sorry, I don't understand.";
            }
        }
    }
}