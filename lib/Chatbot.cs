using Godot;
using System;
using System.Collections.Generic;


namespace QuestBot
{
    public partial class Chatbot : Control
    {
        private TextEdit? _chatDisplay;
        private LineEdit? _userInput;
        private Button? _sendButton;
        private BotLogic? _botLogic;

        public override void _Ready()
        {
            _chatDisplay = GetNode<TextEdit>("ChatDisplay");
            _userInput = GetNode<LineEdit>("UserInput");
            _sendButton = GetNode<Button>("SendButton");
            _botLogic = new BotLogic();

            _sendButton.Connect("pressed", Callable.From(OnSendButtonPressed));
            _chatDisplay.Text = "Chatbot: Hello! How can I help you today?";


        }
        private void OnSendButtonPressed()
        {
            if (_userInput != null && _chatDisplay != null)
            {
                string userMessage = _userInput.Text.Trim();
                if (!string.IsNullOrEmpty(userMessage))
                {
                    _chatDisplay.Text += $"\nYou:{userMessage}";
                
                    if (_botLogic != null)
                    {
                        string botResponse = _botLogic.GetResponse(userMessage);
                        _chatDisplay.Text += $"\nChatbot:{botResponse} ";
                    }
                    _userInput.Clear();
                }
            }
            }
        }
    }
