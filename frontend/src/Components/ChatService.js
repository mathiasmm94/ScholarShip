import { HubConnectionBuilder } from "@microsoft/signalr";

const ChatService = {
  connection: null,

  startConnection:async () => {
    const url = "https://localhost:7181/ChatHub"; // Replace with your actual API URL
    ChatService.connection = new HubConnectionBuilder().withUrl(url).build();

    await ChatService.connection.start() 
  },

  sendMessage: (chatRoomId, senderName, messageContent) => {
    ChatService.connection.invoke("SendMessage", chatRoomId, senderName, messageContent);
  },

  joinChatRoom(chatRoomId) {
    console.log("Joining chat room with id:" + chatRoomId);
    ChatService.connection.invoke("JoinChatRoom", chatRoomId);
  },

  leaveChatRoom: (chatRoomId) => {
    ChatService.connection.invoke("LeaveChatRoom", chatRoomId);
  },

  receiveMessage: (handler) => {
    ChatService.connection.on("ReceiveMessage", (senderName, messageContent) => {
      handler(senderName, messageContent);
    });
  },
};

export default ChatService;
