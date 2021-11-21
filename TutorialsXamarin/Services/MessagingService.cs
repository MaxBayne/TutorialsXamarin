using System;
using TutorialsXamarin.Interfaces;
using Xamarin.Forms;

namespace TutorialsXamarin.Services
{
    /// <summary>
    /// Send Message between ViewModels , Register For Messages
    /// </summary>
    public class MessagingService : IMessagingCenter
    {
        #region Sending Messages
       
        public void Send<TSender>(TSender sender, string message) where TSender : class
        {
            MessagingCenter.Send(sender, message);
        }

        public void Send<TSender, TArgs>(TSender sender, string message, TArgs args) where TSender : class
        {
            MessagingCenter.Send(sender, message,args);
        }

        #endregion

        #region Subscribe For Messaging

        public void Subscribe<TSender, TArgs>(object subscriber, string message, Action<TSender, TArgs> callback, TSender source = null) where TSender : class
        {
            MessagingCenter.Subscribe(subscriber,message, callback, source);
        }

        public void Subscribe<TSender>(object subscriber, string message, Action<TSender> callback, TSender source = null) where TSender : class
        {
            MessagingCenter.Subscribe(subscriber, message, callback, source);
        }


        #endregion

        #region UnSubscribe For Messaging

        public void Unsubscribe<TSender, TArgs>(object subscriber, string message) where TSender : class
        {
            MessagingCenter.Unsubscribe<TSender, TArgs>(subscriber, message);
        }

        public void Unsubscribe<TSender>(object subscriber, string message) where TSender : class
        {
            MessagingCenter.Unsubscribe<TSender>(subscriber, message);
        }

        #endregion

    }
}
