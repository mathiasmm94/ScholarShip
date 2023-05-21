import React, { useEffect, useState } from "react";
import ChatService from "./ChatService.js";

function parseJwt (token) {
  var base64Url = token.split('.')[1];
  var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
  var jsonPayload = decodeURIComponent(window.atob(base64).split('').map(function(c) {
      return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
  }).join(''));

  return JSON.parse(jsonPayload);
}

const decodeToken = () =>{
  const t = localStorage.getItem('token');
  let user = parseJwt(t);
  console.log(user);
  return user.Name.toString();
};

const ChatId = () =>{
  fetch("https://localhost:7181/api/chat")
}



export function ChatWindow() {

  const [messages, setMessages] = useState([]);
  const [inputMessage, setInputMessage] = useState("");
  const userName = decodeToken();  
  

  useEffect(() => {
    // Start the SignalR connection
    ChatService.startConnection().then(()=>{
      ChatService.joinChatRoom(1)

      // Receive incoming messages
      ChatService.receiveMessage((senderName, messageContent) => {
        const newMessage = { senderName, messageContent };
        console.log(newMessage);
        setMessages((prevMessages) => [...prevMessages, newMessage]);
      });
    });

   

    // Clean up the SignalR connection on component unmount
    return () => {
      ChatService.connection.stop();
    };
  }, []);

  const sendMessage = () => {
    if (inputMessage.trim() !== "") {
      ChatService.sendMessage(1, userName, inputMessage);
      console.log(inputMessage);
      setInputMessage("");
    }
  };

  return (
    <div>
  
      <div>
        <ul>
          {messages.map((message, index) => (
            <li key={index}>
              <strong>{message.senderName}: </strong>
              {message.messageContent}
            </li>
          ))}
        </ul>
      </div>
      <div>
        <input
          type="text"
          value={inputMessage}
          onChange={(e) => setInputMessage(e.target.value)}
        />
        <button onClick={sendMessage}>Send</button>
      </div>
    </div>
  );
}


/*

    <div>
        <label>Username: </label>
        <input
          type="text"
          value={userName}
          onChange={(e) => setUserName(e.target.value)}
        />
      </div>
*/