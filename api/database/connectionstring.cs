using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.controllers;

namespace api.database
{
    public class connectionstring
    {
        public string cs{get; set;}
        public connectionstring()
        {
            string server= "qao3ibsa7hhgecbv.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database= "a2b1gw4zc6cndbto";
            string port = "3306";
            string userName = "qly70mzd2o876rf8";
            string password = "pfw2s74l9kqh0nby";

            cs = $@"server = {server}; user = {userName}; database = {database}; port = {port}; password = {password};"; //this is the connection string 

        }
    }
}