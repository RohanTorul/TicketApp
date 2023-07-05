using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TicketApp
{
    internal class Ticket
    {
        private string TicketCode;
        private string TicketDescription;
        private string EmailOfIssuer;
        private DateTime DateTimeTicketCreated;
        private DateTime DateTimeTicketClosed;
        private enum STATUS
        {
            ACTIVE = 0,
            PENDING = 1,
            CLOSED = 2
        }
        private STATUS status;
        private Boolean validator(string TicketCode_Parameter, string TicketDesctiption_Parameter, string EmailOfIssuer_Parameter)
        {   

            return true;//To be implemented...
        }

        public Ticket(string TicketCode_Parameter, string TicketDesctiption_Parameter, string EmailOfIssuer_Parameter)
        {   
            if (validator(TicketCode_Parameter, TicketDesctiption_Parameter, EmailOfIssuer_Parameter))
            {
                TicketCode = TicketCode_Parameter;//-----------------┒
                TicketDescription = TicketDesctiption_Parameter;//---┡----> Obtained from parsing of eml or some other file.
                EmailOfIssuer = EmailOfIssuer_Parameter;//-----------┘
                DateTimeTicketCreated = DateTime.Now; //most likely this must not have to be modified, a setter will be implemented anyways
                DateTimeTicketClosed = DateTime.MinValue;//Must be a known nonesense value by default : 00:00:00.0000000
                status = STATUS.PENDING; //A ticket is created as Pending by default

            }

        }
        /*
          Setters and Getters for private attibutes.
         
         */
        //-------------------------------------------------------------------------------------[TicketCode
        public int setTicketCode(string NewTicketCode)
        {
            TicketCode = NewTicketCode;
            return (0);
        }
        public string getTicketCode()
        {
            return TicketCode;
        }
        //---------------------------------------------------------------------------------------[TicketDescription
        public int setTicketDescription(string NewTicketDescription)
        {
            TicketDescription = NewTicketDescription;
            return 0;
        }
        public string getTicketDescription()
        {
            return (TicketDescription);
        }
        //----------------------------------------------------------------------------------------[EmailOfIssuer
        public int setEmailOfIssuer(string NewEmailOfIssuer)
        {
            EmailOfIssuer = NewEmailOfIssuer;
            return 0;
        }
        public string getEmailOfIssuer()
        {
            return (EmailOfIssuer);
        }
        //----------------------------------------------------------------------------------------[status
        public int setStatus(int NewStatus)
        {
            status = (STATUS)NewStatus;
            return 0;
        }
        public string getStatus()
        {
            return status.ToString();
        }
        //----------------------------------------------------------------------------------------[DateTimeTicketCreated
        public int setDateTimeTicketCreated(DateTime NewDateTimeTicketCreated)//just in case...
        {
            DateTimeTicketCreated = NewDateTimeTicketCreated;
            return 0;
        }
        public string getDateTimeTicketCreated()
        {
            return DateTimeTicketCreated.ToString();
        }
    }

    internal class EmlFileParser
    {

    }

   public class TicketManager
    {   
        public struct PendingQueue
        {
            Queue<Ticket> HighImportance_PendingTicketRequests;
            Queue<Ticket> NormalImportance_PendingTicketRequests;
            Queue<Ticket> BelowNormalImportance_PendingTicketRequests;
            public PendingQueue()
            {
                HighImportance_PendingTicketRequests = new Queue<Ticket>();
                NormalImportance_PendingTicketRequests = new Queue<Ticket>();
                BelowNormalImportance_PendingTicketRequests = new Queue<Ticket>();
            }
        }
        private PendingQueue PendingRequests;//stores tickets that are yet to be acknowledged, in chronological order classified by importance....
        private Dictionary<string, Ticket> ActiveTickets = new Dictionary<string, Ticket>();//----------------------------------------------------------------------------------------------------┯--->Each ticket must be accessed randomly, and not by going though the whole list and getting access to all tickets.
        private Dictionary<string, Ticket> TicketsToBeClosed = new Dictionary<string, Ticket>();//Reasoning for this Dictionary is that before closing a ticket, it might have to be reviewed|----┙

        private bool validateTicket(Ticket ticket)//returns True if validation successfull
        {
            /*To be Implemented*/
            return true;
        }

        /* Tentative Implementation
        public int newTicketHandler(string TicketCode_Parameter, string TicketDesctiption_Parameter, string EmailOfIssuer_Parameter)
        {
            Ticket TempTicket = new Ticket(TicketCode_Parameter, TicketDesctiption_Parameter, EmailOfIssuer_Parameter);
            if (validateTicket(TempTicket)){
                ActiveTickets.Add(TempTicket.getTicketCode().GetHashCode().ToString(), TempTicket);//There ARE better ways....
            }
            else
            {
                return -1;//Error value, could implement an enum for this...
                PendingTicketRequests.
            }
            return 0;
        }
        */



    }
}
