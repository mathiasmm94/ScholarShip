import React from "react";
import { SignalRService } from "../signalrService";


export function Chat(){
    const [connection, setConnection] = useState();
    const [messages, setMessages] = useState([]);
    const [users, setUsers] = useState([]);
  
    const joinRoom = async (user, room) => {
      try {
        const connection = new HubConnectionBuilder()
          .withUrl("https://localhost:7181/Chat")
          .configureLogging(LogLevel.Information)
          .build();
  
        connection.on("ReceiveMessage", (user, message) => {
          setMessages(messages => [...messages, { user, message }]);
        });
  
        connection.on("UsersInRoom", (users) => {
          setUsers(users);
        });
  
        connection.onclose(e => {
          setConnection();
          setMessages([]);
          setUsers([]);
        });
  
        await connection.start();
        await connection.invoke("JoinRoom", { user, room });
        setConnection(connection);
      } catch (e) {
        console.log(e);
      }
    }
  
    const sendMessage = async (message) => {
      try {
        await connection.invoke("SendMessage", message);
      } catch (e) {
        console.log(e);
      }
    }
  
    const closeConnection = async () => {
      try {
        await connection.stop();
      } catch (e) {
        console.log(e);
      }
    }
  
    
}