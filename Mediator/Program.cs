using System;

using Mediator;

TeamChatRoom teamChatRoom = new();

teamChatRoom.Register(new Lawyer("Tom"));

teamChatRoom.Register(new Lawyer("Jane"));

teamChatRoom.Register(new AccountManager("Alice"));

var me = new Lawyer("Me");

teamChatRoom.Register(me);
me.Send("Hi guys!");
me.Send("Tom", "Hi Tom");
me.SendTo<Lawyer>("Hi Lawyers");