using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandsLibrary
{
  public  class CommandsOperations
    {
      //geeting methods
      public string ReplyHi()
      {
          return "Hello Sir, I am here ";
      }

      public string ReplyHowAreYou()
      {
          return "I am fine, waiting for your commands.";
      }

      public string ReplyGoodBye()
      {

          
          return "Good bye sir, have a good day.";
      }

      public string ReplyTime()
      {

          DateTime getTime = DateTime.Now;
          return getTime.ToString("hh:mm",CultureInfo.InvariantCulture);
      }

      public string ReplyDate()
      {

          DateTime getDate = DateTime.Now;
          return string.Format("{0:dddd,MMMM d,yyyy} ", getDate);
      }

      //windows operations
      public string goToDesktop()
      {
          Type typeShell = Type.GetTypeFromProgID("Shell.Application");
          object objShell = Activator.CreateInstance(typeShell);
          typeShell.InvokeMember("MinimizeAll", System.Reflection.BindingFlags.InvokeMethod, null, objShell, null); 
          return "We are now on desktop screen.";
      }

    }
}
