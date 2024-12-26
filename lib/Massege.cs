using System;

namespace QuestBot.Lib
{
    public class Message : IEquatable<Message>
    {
        public string Author { get; }
        public string Content { get; }
        public DateTime TimeSent { get; }
        public Guid MessageId { get; }
        public bool IsRead { get; private set; } // Indique si le message a été lu

        private const int MaxContentLength = 500; // Longueur maximale du contenu

        private Message(string author, string content)
        {
            Author = author;
            Content = content;
            TimeSent = DateTime.UtcNow;
            MessageId = Guid.NewGuid();
            IsRead = false; // Par défaut, le message n'est pas lu
        }

        public static Message Create(string author, string content)
        {
            if (string.IsNullOrWhiteSpace(author))
                throw new ArgumentException("Author cannot be null or empty.", nameof(author));
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Content cannot be null or empty.", nameof(content));
            if (content.Length > MaxContentLength)
                throw new ArgumentException($"Content cannot exceed {MaxContentLength} characters.", nameof(content));

            return new Message(author, content);
        }

        public override string ToString()
        {
            return $"{TimeSent:yyyy-MM-dd HH:mm:ss} - {Author}: {Content} (Read: {IsRead})";
        }

        public void MarkAsRead()
        {
            IsRead = true; // Marquer le message comme lu
        }

        public bool Equals(Message other)
        {
            if (other is null) return false;
            return MessageId.Equals(other.MessageId);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Message);
        }

        public override int GetHashCode()
        {
            return MessageId.GetHashCode();
        }
    }
}