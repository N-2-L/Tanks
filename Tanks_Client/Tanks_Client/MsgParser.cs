using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tanks_Client.DataType;

namespace Tanks_Client
{
    class MsgParser
    {

        //make this singleton if necessary
        //create object of ClientClass
        //ClientClass clientObject = new ClientClass();
        
        //this queue will store all the msgs sent by the server
        private Queue<MsgObject> msgQueue  = new Queue<MsgObject>();

        //this thread is used to keep parsing msgs as long as the game is connected
        private Thread thread;

        //True if game is alive. False if otherwise
        private Boolean gameRunning =true;

        //constructor for MsgParser class
        public MsgParser() {
            thread = new Thread(new ThreadStart(msgProcessor));
            thread.Start();
        }


        //will loop and decode msgs as the queue gets updated
        public void msgProcessor() {
            while (gameRunning) {
                if (msgQueue.Count != 0) {
                    MsgObject msgObject = msgQueue.Dequeue();
                    String msg = msgObject.getMessage();
                    DateTime time = msgObject.getTime();

                    var splitString = msg.Split(':');

                    if (splitString.Length == 0)
                    {
                        //a response msg which is a warning to be handled
                        warningHandler(msg);
                    }
                    else {
                        //if the server response is an update to the GUI
                        messageDeoder(msg);
                    }

                }
            
            }
        }

        /**********this will handle warnings sent by the server***********/
        public void warningHandler(String reply) {
            if (reply.Equals(Constant.S2C_HITONOBSTACLE))
            {
                Console.WriteLine( "Blocked by an obstacle");
            }
            else if (reply.Equals(Constant.S2C_CELLOCCUPIED))
            {
                Console.WriteLine("Cell is occupied by another player");
            }
            else if (reply.Equals(Constant.S2C_NOTALIVE))
            {
                Console.WriteLine( "You are already dead");
            }
            else if (reply.Equals(Constant.S2C_TOOEARLY))
            {
                Console.WriteLine( "The command is too quick");
            }
            else if (reply.Equals(Constant.S2C_INVALIDCELL))
            {
                Console.WriteLine( "Cell is invalid");
            }
            else if (reply.Equals(Constant.S2C_GAMEOVER))
            {
                Console.WriteLine( "The game has finished");
            }
            else if (reply.Equals(Constant.S2C_NOTSTARTED))
            {
                Console.WriteLine( "Game has not started yet");
            }
            else if (reply.Equals(Constant.S2C_NOTACONTESTANT))
            {
                Console.WriteLine( "You are not a valid contestant");
            }
            else if (reply.Equals(Constant.S2C_CONTESTANTSFULL))
            {
                Console.WriteLine(  "Players Full");
            }
            else if (reply.Equals(Constant.S2C_ALREADYADDED))
            {
                Console.WriteLine(  "Already connected");
            }
            else if (reply.Equals(Constant.S2C_GAMESTARTED))
            {
                Console.WriteLine(  "Game has already begun");
            }
            else
            {
                Console.WriteLine(reply);
            }
        }


        /**********use this method to decode random msgs from server*************/
        /**********identifies the type of msg and extracts the necessary information from it*************/
        public void messageDeoder(String msg) {

            var splitString = msg.Split(':');

            //used to identify the type of msg
            String identifier = splitString[0];

            //specifies details of the player at the beginning
            if (identifier.Equals("S")) {

                List<List<String>> playerList = new List<List<String>>(); //Creates new nested List
                playerList.Add(new List<String>()); //Adds new sub List
                for (int i = 0; i <= (splitString.Length-1)/4; i++)
                {
                    playerList[i].Add(splitString[1]);
                    playerList[i].Add(splitString[2].Split(',')[0]);
                    playerList[i].Add(splitString[2].Split(',')[1]);
                    playerList[i].Add(splitString[3]);
                    
                }
                         
            }

            //initial map details
            if (identifier.Equals("I"))
            {
                String playerName = splitString[1];
                //have to split and take the positions
                var brickList = splitString[2].Split(';');
                var stoneList = splitString[3].Split(';');
                var waterList = splitString[4].Split(';');

                
            }

            if (identifier.Equals("G"))
            {
                //get gameplay details
                //get details of players
                for (int i = 0; i < splitString.Length - 2; i++) {
                    var playerSplit = splitString[i + 1].Split(';');
                    String playerName = playerSplit[0];
                    String x = playerSplit[1].Split(',')[0];
                    String y = playerSplit[1].Split(',')[1];
                    String direction = playerSplit[2];
                    String shot = playerSplit[3];
                    String health = playerSplit[4];
                    String coin = playerSplit[5];
                    String points = playerSplit[6];
                }
                var brickList = splitString[splitString.Length-1].Split(';');
                for (int i = 0; i < brickList.Length - 2; i++)
                {
                    var damageBrick = brickList[i].Split(',');
                    String x = damageBrick[0];
                    String y = damageBrick[1];
                    String damageLevel = damageBrick[2];
                
                }

            }
            if (identifier.Equals("C"))
            {
                //get coin details
                String x = splitString[1].Split(',')[0];
                String y = splitString[1].Split(',')[1];
                String time = splitString[2];


            }
            if (identifier.Equals("L"))
            {
                //get LifePack Details
                String x = splitString[1].Split(',')[0];
                String y = splitString[1].Split(',')[1];
                String time = splitString[2];
                String value = splitString[3];

            }


        }



        /**********use this method to send commands to server*************/
        /**********return a string if the command cannot be accepted *************/
        /**********will return "" empty String if command is successfully accepted*************/
        public String sendCommand(String command)
        {

            //send command request to ClientClass object
            //clientObject.Sender(command);

            //this string will accept the reply from server when trying to issue a command
            String reply = "";


            //
            if (reply.Equals(Constant.S2C_HITONOBSTACLE))
            {
                return "Blocked by an obstacle";
            }
            else if (reply.Equals(Constant.S2C_CELLOCCUPIED))
            {
                return "Cell is occupied by another player";
            }
            else if (reply.Equals(Constant.S2C_NOTALIVE))
            {
                return "You are already dead";
            }
            else if (reply.Equals(Constant.S2C_TOOEARLY))
            {
                return "The command is too quick";
            }
            else if (reply.Equals(Constant.S2C_INVALIDCELL))
            {
                return "Cell is invalid";
            }
            else if (reply.Equals(Constant.S2C_GAMEOVER))
            {
                return "The game has finished";
            }
            else if (reply.Equals(Constant.S2C_NOTSTARTED))
            {
                return "Game has not started yet";
            }
            else if (reply.Equals(Constant.S2C_NOTACONTESTANT))
            {
                return "You are not a valid contestant";
            }

            else
            {
                //return an empty String if command is successful
                return "";
            }

           
        }



        /**********use this method to join game to the server***********/
        /**********return string should be displayed in a TextBox***********/
        public String joinGame()
        {

            //send join request to ClientClass object
            //clientObject.Sender(Constant.C2S_INITIALREQUEST);

            //this string will accept the reply from server when trying to connect
            String reply = "";


            if (reply.Equals(Constant.S2C_CONTESTANTSFULL))
            {
                return "Players Full";
            }
            else if (reply.Equals(Constant.S2C_ALREADYADDED))
            {
                return "Already connected";
            }
            else if (reply.Equals(Constant.S2C_GAMESTARTED))
            {
                return "Game has already begun";
            }
            else
            {
                return "SUCCESSFULLY CONNECTED";
            }



        }
    
        /*********setter for msgQueue Queue *********/
        public void addMsg(MsgObject msgObject) {
            this.msgQueue.Enqueue(msgObject);
        }
    
    }
}
