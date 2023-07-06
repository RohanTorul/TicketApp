using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace TicketApp
{
    internal class Ticket
    {
        private string TicketCode; // Unique Identifier
        private string TicketDescription; // parsed mail contents
        private string EmailOfIssuer;
        private DateTime DateTimeTicketCreated;
        private DateTime DateTimeTicketClosed;
        private bool Creation_Success; // To check if the ticket constructor has been succesful.
        private enum STATUS
        {
            ACTIVE = 0,
            PENDING = 1,
            CLOSED = 2
        }
        private enum TICKET_TYPE
        {
            TEST_TYPE1,
            TEST_TYPE2,
            TEST_TYPE3,
            TEST_TYPE4,
            /*... TEST_TYPEn*/
        }

        private TICKET_TYPE TicketType;
        private STATUS status;
        public Boolean Validator(string TicketCode_Parameter, string TicketDesctiption_Parameter, string EmailOfIssuer_Parameter, int TicketType_Parameter)
        {

            return true;//To be implemented...
        }

        public Ticket(string TicketCode_Parameter, string TicketDesctiption_Parameter, string EmailOfIssuer_Parameter, int TicketType_Parameter)
        {
            if (Validator(TicketCode_Parameter, TicketDesctiption_Parameter, EmailOfIssuer_Parameter, TicketType_Parameter))
            {
                TicketCode = TicketCode_Parameter;//-----------------┒
                TicketDescription = TicketDesctiption_Parameter;//---┡----> Obtained from parsing of eml... or some other file.
                EmailOfIssuer = EmailOfIssuer_Parameter;//-----------┘
                DateTimeTicketCreated = DateTime.Now; //most likely this must not have to be modified, a setter will be implemented anyways
                DateTimeTicketClosed = DateTime.MinValue;//Must be a known nonesense value by default : 00:00:00.0000000
                status = STATUS.PENDING; //A ticket is created as Pending by default
                TicketType = (TICKET_TYPE)TicketType_Parameter;//Dangerous(?)
                Creation_Success = true;
            }
            else
            {
                Creation_Success = false;
            }

        }
        /*
          Setters and Getters for private attibutes.
         
         */
        //---------------------------------------------------------------------------------------[TicketCode
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
        //---------------------------------------------------------------------------------------[EmailOfIssuer
        public int setEmailOfIssuer(string NewEmailOfIssuer)
        {
            EmailOfIssuer = NewEmailOfIssuer;
            return 0;
        }
        public string getEmailOfIssuer()
        {
            return (EmailOfIssuer);
        }
        //---------------------------------------------------------------------------------------[status
        public int setStatus(int NewStatus)
        {
            status = (STATUS)NewStatus;
            return 0;
        }
        public string getStatus()
        {
            return status.ToString();
        }
        //---------------------------------------------------------------------------------------[DateTimeTicketCreated
        public int setDateTimeTicketCreated(DateTime NewDateTimeTicketCreated)//just in case...
        {
            DateTimeTicketCreated = NewDateTimeTicketCreated;
            return 0;
        }
        public string getDateTimeTicketCreated()
        {
            return DateTimeTicketCreated.ToString();
        }
        //---------------------------------------------------------------------------------------[DateTimeTicketCreated
        public int setDateTimeTicketClosed(DateTime NewDateTimeTicketClosed)//just in case...
        {
            DateTimeTicketClosed = NewDateTimeTicketClosed;
            return 0;
        }
        public string getDateTimeTicketClosed()
        {
            return DateTimeTicketClosed.ToString();
        }
        //---------------------------------------------------------------------------------------[TicketType
        public int setTicketType(int TypeNumber)//just in case...
        {
            TicketType = (TICKET_TYPE)TypeNumber;
            return 0;
        }
        public string getTicketType()
        {
            return TicketType.ToString();
        }

        //---------------------------------------------------------------------------------------[Creation_Success
        public bool getCreation_Success()
        {
            return Creation_Success;
        }


    }

    internal class EmlFileParser
    {
        private FileStream EmlHandler;
        private string path;

        public EmlFileParser(FileStream emlHandler_Parameter, string path_Parameter)
        {
            EmlHandler = emlHandler_Parameter;
            this.path = path_Parameter;
        }

        public Ticket processFile()
        {
            //to be implemented...
            return null;//TO REMOVE
        }
    }

    public class TicketManager
    {
        private struct PendingQueue
        {
            public Queue<Ticket> HighImportance_PendingTicketRequests;
            public Queue<Ticket> NormalImportance_PendingTicketRequests;
            public Queue<Ticket> BelowNormalImportance_PendingTicketRequests;
            public PendingQueue()
            {
                HighImportance_PendingTicketRequests = new Queue<Ticket>();
                NormalImportance_PendingTicketRequests = new Queue<Ticket>();
                BelowNormalImportance_PendingTicketRequests = new Queue<Ticket>();
            }
        }
        private PendingQueue PendingRequests = new PendingQueue();//stores tickets that are yet to be acknowledged, in chronological order classified by importance....
        private Dictionary<string, Ticket> ActiveTickets = new Dictionary<string, Ticket>();//----------------------------------------------------------------------------------------------------┯--->Each ticket must be accessed randomly, and not by going though the whole list and getting access to all tickets.
        private Dictionary<string, Ticket> TicketsToBeClosed = new Dictionary<string, Ticket>();//Reasoning for this Dictionary is that before closing a ticket, it might have to be reviewed|----┙



        /* replaced by public function in Ticket Class
        private bool validateTicket(Ticket ticket)//returns True if validation successfull
        {
            return true;
        }*/


        /* Tentative Implementation...most likely will be replaced
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

        public int addPendingTickets(int ImportanceLevel, string TicketCode_Parameter, string TicketDesctiption_Parameter, string EmailOfIssuer_Parameter, int TicketType_Parameter)// could use one function for each importance level, but it would lead to too much simmilar code
        {
            /*
             Importance Levels: 1- High
                                2- Normal
                                3- BelowNormal
             */
            Ticket TempTicket = new Ticket(TicketCode_Parameter, TicketDesctiption_Parameter, EmailOfIssuer_Parameter, TicketType_Parameter);
            if (TempTicket.getCreation_Success())
            {
                switch (ImportanceLevel)
                {
                    case 1:
                        PendingRequests.HighImportance_PendingTicketRequests.Enqueue(TempTicket);
                        return 0;
                    case 2:
                        PendingRequests.NormalImportance_PendingTicketRequests.Enqueue(TempTicket);
                        return 0;
                    case 3:
                        PendingRequests.BelowNormalImportance_PendingTicketRequests.Enqueue(TempTicket);
                        return 0;
                    default:
                        return -1;

                }
            }
            else
            {
                return -1;
            }

        }

        public int assignPendingTicket(int ImportanceLevel = 1/*High*/, int amount = 0)// an amount of 0 means that the whole queue will be emptied and added to ActiveTickets | an importance level of 0 means that all Importance levels have to be added to ActiveTicketes
        {
            Ticket TempTicket;
            if (amount == 0)
            {
                if (ImportanceLevel == 0)
                {
                    amount = PendingRequests.HighImportance_PendingTicketRequests.Count();
                    for(int i = 0; i < amount; i++)
                    {
                        TempTicket = PendingRequests.HighImportance_PendingTicketRequests.Dequeue();
                        ActiveTickets.Add(TempTicket.getTicketCode().GetHashCode().ToString(), TempTicket);
                    }

                    amount = PendingRequests.NormalImportance_PendingTicketRequests.Count();
                    for (int i = 0; i < amount; i++)
                    {
                        TempTicket = PendingRequests.NormalImportance_PendingTicketRequests.Dequeue();
                        ActiveTickets.Add(TempTicket.getTicketCode().GetHashCode().ToString(), TempTicket);
                    }

                    amount = PendingRequests.BelowNormalImportance_PendingTicketRequests.Count();
                    for (int i = 0; i < amount; i++)
                    {
                        TempTicket = PendingRequests.BelowNormalImportance_PendingTicketRequests.Dequeue();
                        ActiveTickets.Add(TempTicket.getTicketCode().GetHashCode().ToString(), TempTicket);
                    }

                    return 0;
                }
            }
            else
            {
                if (amount > 0 & ImportanceLevel > 0 & ImportanceLevel < 4)
                switch (ImportanceLevel)
                {
                    case 1:
                        for (int i = 0; i < amount; i++)
                        {
                            TempTicket = PendingRequests.HighImportance_PendingTicketRequests.Dequeue();
                            ActiveTickets.Add(TempTicket.getTicketCode().GetHashCode().ToString(), TempTicket);
                        }
                        return 0;
                    case 2:
                        for (int i = 0; i < amount; i++)
                        {
                            TempTicket = PendingRequests.NormalImportance_PendingTicketRequests.Dequeue();
                            ActiveTickets.Add(TempTicket.getTicketCode().GetHashCode().ToString(), TempTicket);
                        }
                        return 0;
                    case 3:
                        for (int i = 0; i < amount; i++)
                        {
                            TempTicket = PendingRequests.BelowNormalImportance_PendingTicketRequests.Dequeue();
                            ActiveTickets.Add(TempTicket.getTicketCode().GetHashCode().ToString(), TempTicket);
                        }
                        return 0;
                }
            }
            return 0;
        }

        public int  completeTicket(string TicketCode)
        {
            TicketsToBeClosed.Add(TicketCode.GetHashCode().ToString(), ActiveTickets[TicketCode.GetHashCode().ToString()]);//Maybe I should Have used Try... just in case [TO DO]
            ActiveTickets.Remove(TicketCode.GetHashCode().ToString());
            return 0;
        }


    }
}
