using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks_Client
{
    class MsgPasser
    {

        //make this singleton if necessary
        //create object of ClientClass
        ClientClass clientObject = new ClientClass();






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
                playerName = splitString[1];
                //have to split and take the positions
                var brickList = splitString[2].Split(';');
                var stoneList = splitString[3].Split(';');
                var waterList = splitString[4].Split(';');

                
            }

            if (identifier.Equals("G"))
            {
                //get gameplay details

            }
            if (identifier.Equals("C"))
            {
                //get coin pack details


            }
            if (identifier.Equals("L"))
            {
                //get LifePack Details


            }


        }






        /**********use this method to send commands to server*************/
        /**********return a string if the command cannot be accepted *************/
        /**********will return "" empty String if command is successfully accepted*************/
        public String sendCommand(String command)
        {

            //send command request to ClientClass object
            clientObject.Sender(command);

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
            clientObject.Sender(Constant.C2S_INITIALREQUEST);

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
    }
}
