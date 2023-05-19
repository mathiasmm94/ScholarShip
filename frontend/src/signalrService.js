import * as signalR from '@microsoft/signalr';

const connection = new signalR.HubConnectionBuilder()
  .withUrl('localhost:7181/ChatHub')
  .configureLogging(signalR.LogLevel.Information)
  .build();
