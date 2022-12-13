# ChatRoom C# App

Summary: ChatRoom allows users to manage their own chat rooms! Create, edit, and delete chat rooms. Then add (or remove) your friends to the chat room and chat on any topic you want!

- Target platform: .NET 6
- Seeded database with three users, two chat rooms and three messages
- Default user credentials: `guest` / `guest`

## ChatRoom Web App

The ASP.NET Core app "ChatRoom" is an app for creating chat rooms and managing their users.

- Technologies: C#, ASP.NET Core, Entity Framework Core, ASP.NET Core Identity, NUnit
- The app supports the following operations:
  - Home page (view chat rooms + menu): `/`
  - View chat room: `/ChatRooms/Detaiils`
  - Create a new chatroom: `/ChatRooms/Create`
  - Edit an existing chatroom: `/ChatRooms/Edit/:chatId`
  - Delete an existing chatroom: `/ChatRooms/Delete/:chatId`
  - Add user to an existing chat room: `/ChatRoom/AddUser/:chatId`
  - Remove user from an existing chat room: `/ChatRoom/RemoveUser/:chatId`

## Screenshots
![main-page](https://user-images.githubusercontent.com/72888249/207466136-e0e7487f-8759-4f5c-9680-a602655a7493.png)
![register-page](https://user-images.githubusercontent.com/72888249/207465721-f0eaee33-09b7-4c61-84ff-94607e4abae6.png)
![login-page](https://user-images.githubusercontent.com/72888249/207465943-89bec126-e98b-4557-b9b2-111c2812ccaf.png)
![main-page-logged](https://user-images.githubusercontent.com/72888249/207465889-3bde63cc-67ff-4837-a396-77b5804c3c80.png)
![chat-room](https://user-images.githubusercontent.com/72888249/207465978-68ce3db1-6a75-4a38-889f-e79d74140b96.png)
![user-add](https://user-images.githubusercontent.com/72888249/207466007-62341737-57cd-4da5-9589-9335b96b1414.png)
![user-remove](https://user-images.githubusercontent.com/72888249/207466035-eb399221-8266-470b-8413-fbf9f25638b1.png)
