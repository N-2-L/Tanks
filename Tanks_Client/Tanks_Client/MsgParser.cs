﻿using System;
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

        //will store locations sent by each msg
        private string[,] map;

        private String message = "";
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

            map = new string[Constant.MAP_SIZE, Constant.MAP_SIZE];
            for (int i = 0; i < Constant.MAP_SIZE; i++)
            {
                for (int j = 0; j < Constant.MAP_SIZE; j++)
                    map[i, j] = Constant.EMPTY;
            }
        }


        //will loop and decode msgs as the queue gets updated
        public void msgProcessor() {
            while (gameRunning) {
                if (msgQueue.Count != 0) {
                    MsgObject msgObject = msgQueue.Dequeue();
                    String msg = msgObject.getMessage();
                    DateTime time = msgObject.getTime();

                    var splitString = msg.Split(':');

                    //this will update message with time - to be printed on GUI
                    message = msg + "\n" + time;

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
                gameRunning = false;
                Console.WriteLine(  "Players Full");
            }
            else if (reply.Equals(Constant.S2C_ALREADYADDED))
            {
                gameRunning = false;
                Console.WriteLine(  "Already connected");
            }
            else if (reply.Equals(Constant.S2C_GAMESTARTED))
            {
                gameRunning = false;
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

            msg = msg.Substring(0 , msg.Length-1);
            var splitString = msg.Split(':');

            //used to identify the type of msg
            String identifier = splitString[0];

            //specifies details of the player at the beginning
            if (identifier.Equals("S")) {

                for (int i = 0; i <= (splitString.Length-1)/4; i++)
                {
                    var playerDetails = splitString[1].Split(';');
                    String playerName = playerDetails[0];
                    String x = playerDetails[1].Split(',')[0];
                    String y = playerDetails[1].Split(',')[1];
                    String direction = playerDetails[2];
                    map[Int32.Parse(x), Int32.Parse(y)] = playerName;
              
                }
                         
            }

            //initial map details
            if (identifier.Equals("I"))
            {
                String playerName = splitString[1];
                //have to split and take the positions

                var brickList = splitString[2].Split(';');
                for (int i = 0; i < brickList.Length; i++) {
                    String x = brickList[0].Split(',')[0];
                    String y = brickList[0].Split(',')[1];
                    map[Int32.Parse(x) , Int32.Parse(y)] = Constant.BRICK;
                }
                var stoneList = splitString[3].Split(';');
                for (int i = 0; i < brickList.Length; i++)
                {
                    String x = stoneList[0].Split(',')[0];
                    String y = stoneList[0].Split(',')[1];
                    map[Int32.Parse(x), Int32.Parse(y)] = Constant.STONE;
                }
                var waterList = splitString[4].Split(';');
                for (int i = 0; i < waterList.Length; i++)
                {
                    String x = waterList[0].Split(',')[0];
                    String y = waterList[0].Split(',')[1];
                    map[Int32.Parse(x), Int32.Parse(y)] = Constant.WATER;
                }

                
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
                    map[Int32.Parse(x), Int32.Parse(y)] = playerName;

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
                String value = splitString[3];
                map[Int32.Parse(x), Int32.Parse(y)] = Constant.COIN;


            }
            if (identifier.Equals("L"))
            {
                //get LifePack Details
                String x = splitString[1].Split(',')[0];
                String y = splitString[1].Split(',')[1];
                String time = splitString[2];
                map[Int32.Parse(x), Int32.Parse(y)] = Constant.LIFE;

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

        /********getter for map 2d array**********/
        public string[,] getMap() {
            return map;
        }
        public Boolean getGameRunning() {
            return gameRunning;
        }
        public String getMessage() {
            return message;
        }
    
    }
}
