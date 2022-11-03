using ADONETExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADONETExample.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        static Chat chatmodel;
        public ActionResult Index(string User, bool? LogOn, bool? LogOff, string ChatMessage)
        {
            try
            {
                if(chatmodel == null)
                {
                    chatmodel = new Chat();
                }

                if (!Request.IsAjaxRequest())
                {
                    return View();
                }
                else if (LogOn != null && (bool)LogOn)
                {
                    if(chatmodel.User.FirstOrDefault(x =>x.Name == User) != null)
                    {
                        throw new Exception("Пользователь таким именем уже существует ... ");
                    }
                    else if(chatmodel.User.Count > 3)
                    {
                        throw new Exception("Чат переполнено");
                    }
                    else
                    {
                        chatmodel.User.Add(new Chat.ChatUsers()
                        {
                            Name = User,
                            Login = DateTime.Now,
                            LastVisit = DateTime.Now
                        });

                        chatmodel.Messages.Add(new Chat.ChatMessage()
                        {
                            Text = User + "вошел в чат",
                            Date = DateTime.Now
                        });
                    }
                    return PartialView("ChatRoom",chatmodel);
                }
                else if(LogOff != null && (bool)LogOff)
                {
                    LogOffChat(chatmodel.User.FirstOrDefault(x => x.Name == User));
                    return PartialView("ChatRoom", chatmodel);
                }
                else
                {
                    Chat.ChatUsers currentUser = chatmodel.User.FirstOrDefault(x => x.Name == User);

                    currentUser.LastVisit = DateTime.Now;

                    if (!string.IsNullOrEmpty(ChatMessage))
                    {
                        chatmodel.Messages.Add(new Chat.ChatMessage()
                        {
                            users = currentUser,
                            Text = ChatMessage,
                            Date = DateTime.Now
                        });
                    }
                    return PartialView("MessageHistory",chatmodel);
                }
            }
            catch(Exception ex) {
                Response.StatusCode = 400;
                return Content(ex.Message);
            }
        }

        public void LogOffChat(Chat.ChatUsers user)
        {
            chatmodel.User.Remove(user);

            chatmodel.Messages.Add(new Chat.ChatMessage()
            {
                Text = user + "Покинул чат",
                Date = DateTime.Now
            }
                );
        }
    }
}