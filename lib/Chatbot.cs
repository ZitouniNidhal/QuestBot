using Godot;
using Microsoft.VisualBasic;
using System;

public class Chatbot : Control
{
    private TextEdit _chatDisplay;
    private LineEdit _userInput;
    private Button _sendButton;
    private BotLogic _botLogic;

    public override void _Ready()
    {
        _chatDisplay = GetNode<TextEdit>("ChatDisplay");
        _userInput = GetNode<LineEdit>("UserInput");
        _sendButton = GetNode<Button>("SendButton");
        _botLogic = new BotLogic();

        _sendButton.Connect("pressed",this ,nameof(OnSendButtonPressed));
        _chatDisplay.Text = "Chatbot: Hello! How can I help you today?";


    }
    private void OnSendButtonPressed()
    {
        string userMessage = _userInput.Text.TrimEdges();
        if(!string.IsNullOrEmpty(userMessage))
        {
            
        _chatDisplay.Text += $"\nYou:{userMessage}";
       
        string botResponse = _botLogic.GetResponse ;
        _chatDisplay.Text += $"\nChatbot:{botResponse} ";
        _userInput.Clear();
        }
    }
}