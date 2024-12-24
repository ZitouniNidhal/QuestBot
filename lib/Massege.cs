using System;

namespace QuestBot.Lib
{
    public class Message
    {
        // Propriétés auto-implémentées
        public string Author { get; }
        public string Content { get; }
        public DateTime TimeSent { get; }
        public Guid MessageId { get; } // Identifiant unique pour chaque message

        // Constructeur avec validation
        public Message(string author, string content)
        {
            if (string.IsNullOrWhiteSpace(author))
                throw new ArgumentException("Author cannot be null or empty.", nameof(author));
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Content cannot be null or empty.", nameof(content));

            Author = author;
            Content = content;
            TimeSent = DateTime.UtcNow; // Utilisation de l'heure UTC
            MessageId = Guid.NewGuid(); // Génération d'un identifiant unique
        }

        // Méthode ToString pour un affichage facile
        public override string ToString()
        {
            return $"{TimeSent:yyyy-MM-dd HH:mm:ss} - {Author}: {Content}";
        }
    }
}