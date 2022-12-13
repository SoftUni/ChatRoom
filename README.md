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
