# Chat

Simple chat using 
- WebSockets
- Newtonsoft.Json
- WPF
- Prism framework
- EntityFrameworkCore (PosrgeSQL)
- NLog

## Key Features 

- It's possible to send a message to a public chat
- Usernames are generated automatically, it concatenate string "User" and a random number in the range (1, 1000)
- All messages from the users are saved in database (PosrgeSQL)
- Logs, which are created by NLog, are saved in "logfile.txt".

## Sending And Receiving Messages

To send a message, you need to press the "Enter" key or just click the "Send" button.

```
![Alt Text](https://github.com/Soqva/chat/blob/master/github/gifs/sending-messages.gif)
```

All users receive messages from the server automatically.

```
![Alt Text](https://github.com/Soqva/chat/blob/master/github/gifs/receiving-messages.gif)
```

## Saving Message History

All messages from users are saved in the PosrgreSQL database. 

The entries in the database contain:
- userId
- username
- text
- datetime.

```
![Alt Text](https://github.com/Soqva/chat/blob/master/github/gifs/db.gif)
```

## Logging

The NLog logger writes actions such as sending messages, saving messages in the DB and etc.

```
![Alt Text](https://github.com/Soqva/chat/blob/master/github/gifs/logging-part1.gif)
```
```
![Alt Text](https://github.com/Soqva/chat/blob/master/github/gifs/logging-part2.gif)
```
