using System;
using System.Collections.Generic;

namespace QuestBot.Lib
{
    /// <summary>
    /// Represents the chat history, storing messages exchanged in the chat.
    /// </summary>
    public class ChatHistory
    {
        private readonly List<Message> _messages;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatHistory"/> class.
        /// </summary>
        public ChatHistory()
        {
            _messages = new List<Message>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatHistory"/> class with existing messages.
        /// </summary>
        /// <param name="messages">The initial messages to add to the chat history.</param>
        public ChatHistory(IEnumerable<Message> messages)
        {
            _messages = new List<Message>(messages);
        }

        /// <summary>
        /// Adds a message to the chat history.
        /// </summary>
        /// <param name="message">The message to add.</param>
        public void AddMessage(Message message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message), "Message cannot be null.");
            }
            _messages.Add(message);
        }

        /// <summary>
        /// Retrieves all messages in the chat history.
        /// </summary>
        /// <returns>An enumerable collection of messages.</returns>
        public IEnumerable<Message> GetMessages()
        {
            return _messages.AsReadOnly(); // Return a read-only collection to prevent modification
        }

        /// <summary>
        /// Clears all messages from the chat history.
        /// </summary>
        public void ClearHistory()
        {
            _messages.Clear();
        }
    }
}