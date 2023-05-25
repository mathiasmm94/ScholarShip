import React, { useEffect, useState } from "react";
import axios from "axios";
import ChatService from "./ChatService.js";
import "./CSS/ChatWindow.css"

function parseJwt(token) {
  var base64Url = token.split(".")[1];
  var base64 = base64Url.replace(/-/g, "+").replace(/_/g, "/");
  var jsonPayload = decodeURIComponent(
    window.atob(base64)
      .split("")
      .map(function (c) {
        return "%" + ("00" + c.charCodeAt(0).toString(16)).slice(-2);
      })
      .join("")
  );

  return JSON.parse(jsonPayload);
}

const decodeName = () => {
  const t = localStorage.getItem("token");
  let user = parseJwt(t);
  return user.Name.toString();
};
const decodeManagerId = () => {
  const t = localStorage.getItem("token");
  let user = parseJwt(t);
  return Number(user.EfManagerId);
};

export function ChatWindow({ chatId }) {
  const [messages, setMessages] = useState([]);
  const [inputMessage, setInputMessage] = useState("");
  const [oldChatData, setOldChatData] = useState([]);
  const userName = decodeName();
  const EfmanagerId = decodeManagerId();
  console.log(EfmanagerId);

  const getStoredChatData = async () => {
    try {
      const response = await axios.get(
        `https://localhost:7181/api/Chat/Rooms/${chatId}/messages`
      );
      setOldChatData(response.data);
      console.log(response.data);
    } catch (error) {
      console.log(error);
    }
  };

  useEffect(() => {
    getStoredChatData(); // Fetch initial chat history

    // Start the SignalR connection
    ChatService.startConnection().then(() => {
      ChatService.joinChatRoom(chatId);

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
  }, [chatId]);

  const sendMessage = () => {
    if (inputMessage.trim() !== "") {
      ChatService.sendMessage(chatId, userName, inputMessage, EfmanagerId);
      setInputMessage("");
    }
  };

  return (
    <div className="ChatWindow">
      <div className="Message_Output">
        <ul>
          {oldChatData.map((message, index) => (
            <li key={index}>
              <strong>{message.firstName}: </strong>
              {message.content}
            </li>
          ))}
          {messages.map((message, index) => (
            <li key={index}>
              <strong>{message.senderName}: </strong>
              {message.messageContent}
            </li>
          ))}
        </ul>
      </div>
      <div className="Message_intput">
        <input
          className="InputMessage"
          type="text"
          value={inputMessage}
          onChange={(e) => setInputMessage(e.target.value)}
        />
        <button className="ChatSendBTN" onClick={sendMessage}>Send</button>
      </div>
    </div>
  );
}



