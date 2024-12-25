using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
                { "What is the time?", GetCurrentTime("hh:mm tt") } // Call method to get current time
            };
        }

        /// <summary>
        /// Gets the current time as a formatted string.
        /// </summary>
        /// <param name="format">The format of the time string.</param>
        /// <returns>The current time as a string.</returns>
        private static string GetCurrentTime(string format)
        {
            return DateTime.Now.ToString(format);
        }

        /// <summary>
        /// Gets a response based on user input.
        /// </summary>
        /// <param name="userMessage">The message from the user.</param>
        /// <returns>A response string from the bot.</returns>
        public string GetResponse(string userMessage)
        {
            if (string.IsNullOrWhiteSpace(userMessage))
            {
                return "Please say something.";
            }

            // Check for regex matches for more flexible responses
            foreach (var key in _responses.Keys)
            {
                if (Regex.IsMatch(userMessage, key, RegexOptions.IgnoreCase))
                {
                    return _responses[key];
                }
            }

            return "I'm sorry, I don't understand.";
        }
    }
}