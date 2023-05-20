import React, { useEffect, useRef, useState } from "react";
import { HubConnectionBuilder } from "@microsoft/signalr";

export function ChatWindow(props) {
  const [messages, setMessages] = useState([]);
  const [inputMessage, setInputMessage] = useState("");

  const chatRoomId = props.chatRoomId;
  const hubConnectionRef = useRef(null);

  useEffect(() => {
    // Create a new instance of SignalR hub connection
    const hubConnection = new HubConnectionBuilder()
      .withUrl("https://localhost:7181/Chat")
      .build();

    // Save the hub connection instance to the ref
    hubConnectionRef.current = hubConnection;

    // Start the hub connection
    hubConnection.start().then(() => {
      // Join the chat room
      hubConnection.invoke("JoinChatRoom", chatRoomId);

      // Receive new message from the hub
      hubConnection.on("ReceiveMessage", (message) => {
        setMessages((prevMessages) => [...prevMessages, message]);
      });
    });

    // Clean up the hub connection on unmount
    return () => {
      hubConnectionRef.current.stop();
    };
  }, [chatRoomId]);

  const handleInputChange = (event) => {
    setInputMessage(event.target.value);
  };

  const handleSendMessage = () => {
    if (inputMessage.trim() === "") return;

    const messageContent = inputMessage;

    // Send the message to the hub
    hubConnectionRef.current
      .invoke("SendMessage", chatRoomId, messageContent)
      .then(() => {
        setInputMessage("");
      })
      .catch((error) => {
        console.error("Failed to send message:", error);
      });
  };

  return (
    <div className="chat-window">
      <div className="chat-messages">
        {messages.map((message) => (
          <div key={message.messageId} className="message">
            <span className="message-sender">{message.efManager.username}:</span>{" "}
            {message.content}
          </div>
        ))}
      </div>
      <div className="chat-input">
        <input
          type="text"
          value={inputMessage}
          onChange={handleInputChange}
          placeholder="Type your message..."
        />
        <button onClick={handleSendMessage}>Send</button>
      </div>
    </div>
  );
}
