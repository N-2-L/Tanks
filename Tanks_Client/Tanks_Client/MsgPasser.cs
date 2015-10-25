using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks_Client
{
    class MsgPasser
    {

        String msg = "";
        //create object of ClientClass
        ClientClass clientObject = new ClientClass();









        /**********use this method to send commands to server*************/
        /**********return a string if the command cannot be accepted *************/
        /**********will return "" empty String if command is successfully accepted*************/
        public String sendCommand(String command)
        {

            //send command request to ClientClass object
            clientObject.Sender(command);

            //this string will accept the reply from server when trying to issue a command
            String reply = "";

            if (reply.Equals("OBSTACLE#"))
            {
                return "Blocked by an obstacle";
            }
            else if (reply.Equals("CELL_OCCUPIED#"))
            {
                return "Cell is occupied by another player";
            }
            else if (reply.Equals("DEAD#"))
            {
                return "You are already dead";
            }
            else if (reply.Equals("TOO_QUICK#"))
            {
                return "The command is too quick";
            }
            else if (reply.Equals("INVALID_CELL#"))
            {
                return "Cell is invalid";
            }
            else if (reply.Equals("GAME_HAS_FINISHED#"))
            {
                return "The game has finished";
            }
            else if (reply.Equals("GAME_NOT_STARTED_YET#"))
            {
                return "Game has not started yet";
            }
            else if (reply.Equals("NOT_A_VALID_CONTESTANT#"))
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


            if (reply.Equals("PLAYERS_FULL#"))
            {
                return "Players Full";
            }
            else if (reply.Equals("ALREADY_ADDED#"))
            {
                return "Already connected";
            }
            else if (reply.Equals("GAME_ALREADY_STARTED#"))
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
