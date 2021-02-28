using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
//using System.Linq.Dynamic;
using System.Threading.Tasks;
using appMODEL;
using System.IO;
using Microsoft.VisualBasic;
using System.Data.OleDb;
using System.Xml;
using System.Runtime.InteropServices;
using System.Web;

namespace appBLL
{
    // Business katmani (logic layer)
    public class PlayersBLL
    {
        // Uses PAGING GRID Query her defasinda 1 sayfa alir (dahili - internal SQL ifadesi (statement))
        public List<Players> PlayersSearch(
            Players SearchValues,
            long currentPageNumber,
            long pageSize,
            string sortBy,
            string sortAscendingDescending,
            out long totalRows,
            out long totalPages,
            out long pageRows,
            out bool returnStatus,
            out string returnErrorMessage)
        {

            long currentRow;
            long result;

            try
            {
                totalPages = 0;
                totalRows = 0;
               pageRows = 0;
               double timediff = SearchValues.TimeDiff; // yerel saat farkini alir. (client tarafinda js den)

                List<Players> GridList = new List<Players>();
                
                DataTable scriptDataTable = GetPlayers(SearchValues,
                    currentPageNumber,
                    pageSize,
                    sortBy,
                    sortAscendingDescending,
                    out totalRows,
                    out returnStatus,
                    out returnErrorMessage);

                if (returnStatus == false)
                {
                    return GridList;
                }

                //totalRows = scriptDataTable.Rows.Count;
                totalPages = 0;

                Math.DivRem(totalRows, pageSize, out result);
                if (result > 0)
                    totalPages = Convert.ToInt64(totalRows / pageSize) + 1;
                else
                    totalPages = Convert.ToInt64(totalRows / pageSize);

                currentRow = 0;

                for (int i = 0; i < scriptDataTable.Rows.Count; i++)
                {
                        currentRow++;

                        Players recList = new Players();

                        recList.Player_ID = scriptDataTable.Rows[i]["Player_ID"] != DBNull.Value ? Convert.ToInt64(scriptDataTable.Rows[i]["Player_ID"]) : 0;

                        recList.Nickname = scriptDataTable.Rows[i]["Nickname"] != DBNull.Value ? scriptDataTable.Rows[i]["Nickname"].ToString() : "";




                        recList.Battles = scriptDataTable.Rows[i]["Battles"] != DBNull.Value ? Convert.ToInt32(scriptDataTable.Rows[i]["Battles"]) : 0;


           
                        recList.Wn_State = scriptDataTable.Rows[i]["Wn_State"] != DBNull.Value ? Convert.ToInt32(scriptDataTable.Rows[i]["Wn_State"]) : 0;



                        recList.Damage = scriptDataTable.Rows[i]["Damage"] != DBNull.Value ? Convert.ToInt32(scriptDataTable.Rows[i]["Damage"]) : 0;



                        GridList.Add(recList);

                }
                
                pageRows = currentRow;

                returnErrorMessage = "";
                returnStatus = true;
                return GridList;

            }
            catch (Exception ex)
            {
                returnErrorMessage = ex.Message;
                returnStatus = false;
                totalPages = 0;
                totalRows = 0;
                pageRows = 0;

                List<Players> GridList = new List<Players>();
             
                return GridList;
            }

        }

        public List<Players> PlayersSearchCache(
           DataTable scriptDataTable,
          long pageSize,
          long totalRowsin,
          out long totalRows,
          out long totalPages,
          out long pageRows,
          out bool returnStatus,
          out string returnErrorMessage)
        {

            long currentRow;
            long result;

            try
            {
                totalPages = 0;
                totalRows = totalRowsin;
                pageRows = 0;

                List<Players> GridList = new List<Players>();
             
                //totalRows = scriptDataTable.Rows.Count;
                totalPages = 0;

                Math.DivRem(totalRows, pageSize, out result);
                if (result > 0)
                    totalPages = Convert.ToInt64(totalRows / pageSize) + 1;
                else
                    totalPages = Convert.ToInt64(totalRows / pageSize);

                currentRow = 0;
                //pageNumber = 1;

                for (int i = 0; i < scriptDataTable.Rows.Count; i++)
                {
                        currentRow++;

                        Players recList = new Players();

                        recList.Player_ID = scriptDataTable.Rows[i]["Player_ID"] != DBNull.Value ? Convert.ToInt64(scriptDataTable.Rows[i]["Player_ID"]) : 0;

                        recList.Nickname = scriptDataTable.Rows[i]["Nickname"] != DBNull.Value ? scriptDataTable.Rows[i]["Nickname"].ToString() : "";




                        recList.Battles = scriptDataTable.Rows[i]["Battles"] != DBNull.Value ? Convert.ToInt32(scriptDataTable.Rows[i]["Battles"]) : 0;


           
                        recList.Wn_State = scriptDataTable.Rows[i]["Wn_State"] != DBNull.Value ? Convert.ToInt32(scriptDataTable.Rows[i]["Wn_State"]) : 0;



                        recList.Damage = scriptDataTable.Rows[i]["Damage"] != DBNull.Value ? Convert.ToInt32(scriptDataTable.Rows[i]["Damage"]) : 0;



                        GridList.Add(recList);

                }
                
               pageRows = currentRow;

                returnErrorMessage = "";
                returnStatus = true;
                return GridList;

            }
            catch (Exception ex)
            {
                returnErrorMessage = ex.Message;
                returnStatus = false;
                totalPages = 0;
                totalRows = 0;
                pageRows = 0;

                List<Players> GridList = new List<Players>();
             
                return GridList;
            }

        }

        public DataTable GetPlayers(
            Players scriptSearchValues,
            long currentPageNumber,
            long pageSize,
            string sortBy,
            string sortAscendingDescending,
            out long TotalRecords,
            out bool returnStatus,
            out string returnErrorMessage)
        {

            SqlConnection connection;
            connection = new SqlConnection();

            try
            {
                long StartPoint;
                long EndPoint;
                String strfilter = "";
                bool GlobalSearchSQL = false;

                DataSet scriptData = new DataSet();

                String connectionString = scriptSearchValues.DBConnectString;

                connection.ConnectionString = connectionString;
                connection.Open();

                SqlCommand scriptCommand = new SqlCommand();
                scriptCommand.CommandType = CommandType.Text;
                scriptCommand.Connection = connection;


                String strFields = "Player_ID, Nickname, Battles, ";
                strFields = strFields + "Wn_State, Damage ";

                String strTable = "Players ";
               
                strfilter = " WHERE 1=1 ";


                String strWherePK = "WHERE Player_ID = @PKID ";
                SqlParameter parampk = new SqlParameter("@PKID", SqlDbType.BigInt);
                parampk.Value = scriptSearchValues.Player_ID;
                scriptCommand.Parameters.Add(parampk);


                String strsort = "";
                if (sortBy == "PlayersFirstCol")
                {
                    strsort = strsort + " ORDER BY Player_ID ";
                }
                else if (sortBy == "PlayersSecondCol")
                {
                    strsort = strsort + " ORDER BY Nickname ";
                }
                else if (sortBy == "PlayersThirdCol")
                {
                    strsort = strsort + " ORDER BY Battles ";
                }
                else if (sortBy == "PlayersFourthCol")
                {
                    strsort = strsort + " ORDER BY Wn_State ";
                }
                else if (sortBy == "PlayersFifthCol")
                {
                    strsort = strsort + " ORDER BY Damage ";
                }
                else if (sortBy == "PlayersSixthCol")
                {
                    //strsort = strsort + " ORDER BY Damage ";
                }
                else
                {
                    strsort = strsort + " ORDER BY Damage ";
                }

                if (sortAscendingDescending == "DESC")
                {
                    strsort = strsort + " DESC ";
                }
               
                

                if (currentPageNumber == 1)
                {
                    StartPoint = 1;
                }
                else
                {
                    StartPoint = ((currentPageNumber - 1) * pageSize) + 1;
                }
                EndPoint = currentPageNumber * pageSize;

                String strSQL = "";

                TotalRecords = 0;
                strSQL = "SELECT count(*) FROM " + strTable + strfilter;
                scriptCommand.CommandText = strSQL;
                TotalRecords = Convert.ToInt64(scriptCommand.ExecuteScalar());


                // pdf kayidi istenirse diye (tum kayitlari siler)
                if (pageSize == -1)
                {
                    EndPoint = TotalRecords;
                }


                // PK_ID var mi?? (ona gore yeni ve duzenle secenekleri acilacak)
                strSQL = "";
                if (scriptSearchValues.Player_ID != 0)
                {
                    strSQL = "SELECT  " + strFields + " FROM " + strTable + strWherePK;
                    strSQL = strSQL + " UNION ";
                    if (TotalRecords == 0)   // sadece bir kayit gosterdiginde
                    {
                        TotalRecords = 1;  // en azindan bir kayit oldugunu goster
                    }
                }

                strSQL = strSQL + "SELECT  " + strFields + " FROM ";
                strSQL = strSQL + " (SELECT TOP (@Endit) ROW_NUMBER() OVER (" + strsort + ") ";
                //strSQL = strSQL + " (SELECT TOP " + EndPoint + " ROW_NUMBER() OVER (" + strsort + ") ";
                strSQL = strSQL + " AS Row, " + strFields + " FROM " + strTable + strfilter + ") ";
                strSQL = strSQL + " AS LogWithRowNumbers ";
                strSQL = strSQL + " WHERE Row >= @Startit AND Row <= @Endit " + " ";
                //strSQL = strSQL + " WHERE Row >= " + StartPoint + " AND Row <= " + EndPoint + " ";
                strSQL = strSQL + strsort + " ";


                scriptCommand.CommandText = strSQL;

                scriptCommand.Parameters.AddWithValue("Startit", StartPoint);
                scriptCommand.Parameters.AddWithValue("Endit", EndPoint);

                SqlDataAdapter sqlAdapter = new SqlDataAdapter(scriptCommand);

                sqlAdapter.Fill(scriptData);

     
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }

                returnErrorMessage = "";
                returnStatus = true;

                return scriptData.Tables[0];
            }
            catch (Exception ex)
            {
                TotalRecords = 0;
                returnStatus = false;
                returnErrorMessage = ex.Message;

                DataTable scriptData = new DataTable();
                return scriptData;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
               
            }


        }



        public Players GetPlayersDetail(long PK_ID, string DBconnectString,
            out bool returnStatus,
            out string returnErrorMessage,
            out List<string> returnMessages)
        {
            SqlConnection connection;
            connection = new SqlConnection();

            try
            {

                //List<RiskLevelList> ptypeList = new List<RiskLevelList>();

                string sqlString = "SELECT * FROM Players WHERE Player_ID = @PK_ID";
               //string sqlString = "SELECT * FROM ~viewcombotable~ WHERE Player_ID = @PK_ID";     

                returnErrorMessage = "";

                //SqlConnection connection;                                                                                                      
                //connectionString = System.Configuration.ConfigurationManager.AppSettings["ScriptDatabase"];
                //String connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RMS-PROD"].ToString();
                //String connectionString = "Server=(localdb)\\mssqllocaldb;Database=AHIM;Trusted_Connection=True;";
                //String connectString = "Data Source=(localdb)\\mssqllocaldb;Database=AHIM;Trusted_Connection=True;MultipleActiveResultSets=true";

                String connectionString = DBconnectString;

                //connection = new SqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = sqlString;

                SqlParameter param1 = new SqlParameter("@PK_ID", SqlDbType.VarChar);
                param1.Value = PK_ID;
                //param1.Value = 312;
                sqlCommand.Parameters.Add(param1);

                SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand);

                DataSet scriptData = new DataSet();
                sqlAdapter.Fill(scriptData);

                //connection.Close();
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
               
                List<string> outputMessages = new List<string>();
                outputMessages.Add("Players Information Retrieved"); //(oyuncular - alinan bilgi)

                returnStatus = true;
                returnMessages = outputMessages;



                Players script = new Players();

                script.Player_ID = Convert.ToInt64(scriptData.Tables[0].Rows[0]["Player_ID"]);

                //script.Nickname = UtilitiesBLL.ConvertToString(scriptData.Tables[0].Rows[0]["Nickname"]);

                 script.Nickname = scriptData.Tables[0].Rows[0]["Nickname"] != DBNull.Value ? scriptData.Tables[0].Rows[0]["Nickname"].ToString() : "";




                //script.Battles = Convert.ToInt32(scriptData.Tables[0].Rows[0]["Battles"]);


                 script.Battles = scriptData.Tables[0].Rows[0]["Battles"] != DBNull.Value ? Convert.ToInt32(scriptData.Tables[0].Rows[0]["Battles"]) : 0;


                //script.Wn_State = Convert.ToInt32(scriptData.Tables[0].Rows[0]["Wn_State"]);


                 script.Wn_State = scriptData.Tables[0].Rows[0]["Wn_State"] != DBNull.Value ? Convert.ToInt32(scriptData.Tables[0].Rows[0]["Wn_State"]) : 0;


                //script.Damage = Convert.ToInt32(scriptData.Tables[0].Rows[0]["Damage"]);


                 script.Damage = scriptData.Tables[0].Rows[0]["Damage"] != DBNull.Value ? Convert.ToInt32(scriptData.Tables[0].Rows[0]["Damage"]) : 0;



                return script;

            }
            catch (Exception ex)
            {

                List<string> outputMessages = new List<string>();

                returnStatus = false;
                returnErrorMessage = ex.Message;
                returnMessages = outputMessages;

                Players script = new Players();

                return script;
            }
            finally
            {
                //connection.Close();
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
               
            }

        }



        /// <summary>
        /// Format Detail Data
        /// </summary>
        public void FormatScriptData(ref Players scriptInformation, 
            out bool returnStatus,                                    
            out string returnErrorMessage)
        {

            try
            {
                if (scriptInformation.Nickname == null) scriptInformation.Nickname = "";


                returnErrorMessage = "";
                returnStatus = true;

            }
            catch (Exception ex)
            {
                returnErrorMessage = ex.Message;
                returnStatus = false;
            }

        }

        // duzenlemeyi dogrula
        public bool ValidateScript(Players scriptInformation, 
            out List<string> Messages, 
            out bool returnStatus, 
            out string returnErrorMessage)
        {

            try
            {

                bool validPatient = true;

                List<string> outputMessages = new List<string>();

                if (scriptInformation.Nickname == null || scriptInformation.Nickname.Trim().Length == 0)
                {
                    outputMessages.Add("Nickname is required.~Nickname"); // nickname zorunludur
                    validPatient = false;
                }

                Messages = outputMessages;

                returnStatus = true;
                returnErrorMessage = "";

                return validPatient;
            }
            catch (Exception ex)
            {
                List<string> outputMessages = new List<string>();
                Messages = outputMessages;

                returnStatus = false;
                returnErrorMessage = ex.Message;
                
                return false;
            }

        }

        
        /// <summary>
        /// Ayni duzenlemeleri kontrol et
        /// </summary>
        public bool DuplicateVehicle(long vehicleID, 
            string vehicleName, 
            out bool returnStatus, 
            out string returnErrorMessage)
        {

           //UtilitiesBLL UtilitiesBLL = new UtilitiesBLL();
           //SqlConnection connection = UtilitiesBLL.CreateConnectionRMSPROD(out returnStatus, out returnErrorMessage);
            SqlConnection connection;
            connection = new SqlConnection();

            try
            {

                string sqlString = "SELECT Player_ID FROM Players ";
                sqlString = sqlString + " WHERE Nickname = @Name ";
 
                if (vehicleID > 0)
                {
                    sqlString = sqlString + " AND Player_ID <> @VEHICLE_ID";
                }

                String DBconnectString = "Data Source=(localdb)\\mssqllocaldb;Database=AHIM;Trusted_Connection=True;MultipleActiveResultSets=true";

                String connectionString = DBconnectString;

                //connection = new SqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = sqlString;

                SqlParameter param1 = new SqlParameter("@Name", SqlDbType.VarChar);
                param1.Value = vehicleName;
                sqlCommand.Parameters.Add(param1);

                if (vehicleID > 0)
                {
                    SqlParameter param3 = new SqlParameter("@VEHICLE_ID", SqlDbType.BigInt);
                    param3.Value = vehicleID;
                    sqlCommand.Parameters.Add(param3);
                }

                bool duplicatePatient = false;

                IDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.Read())
                {
                    duplicatePatient = true;
                }

                //connection.Close();
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
               
                returnStatus = true;
                returnErrorMessage = "";

                return duplicatePatient;

            }
            catch (Exception ex)
            {               
                returnStatus = false;
                returnErrorMessage = ex.Message;

                return false;
            }
            finally
            {
                //connection.Close();
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
               
            }

        }
     
        
         
        /// <summary>
        /// Duzenleme Ekleme
        /// </summary>
        public Players AddPlayers(Players scriptInformation, 
            out long returnPageNumber,
            out long returnRowNumber,
            out List<string>returnMessages, 
            out bool returnStatus,
            out string returnErrorMessage)
        {

            //UtilitiesBLL UtilitiesBLL = new UtilitiesBLL();
            //SqlConnection connection = UtilitiesBLL.CreateConnectionRMSPROD(out returnStatus, out returnErrorMessage);
            SqlConnection connection;
            connection = new SqlConnection();

            try
            {

                String connectionString = scriptInformation.DBConnectString;

                //connection = new SqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();


                returnPageNumber = -1;
                returnRowNumber = -2;
          
                //StringBuilder sqlBuilder = new StringBuilder();

                List<string> messages;

                FormatScriptData(ref scriptInformation, out returnStatus, out returnErrorMessage);

                bool validScript = ValidateScript(
                    scriptInformation,
                    out messages,
                    out returnStatus,
                    out returnErrorMessage);

                if (validScript == false)
                {
                    returnStatus = false;
                    returnMessages = messages;
                    scriptInformation.Player_ID = -1;  // dogrulamada hata varsa PK_ID -1 olmali.
                    return scriptInformation;
                }


                string sqlString = "INSERT INTO Players ( ";
                sqlString = sqlString + " Nickname, Battles, ";
                sqlString = sqlString + " Wn_State, Damage) VALUES ( ";
                sqlString = sqlString + " @Colum1, @Colum2, ";
                sqlString = sqlString + " @Colum3, @Colum4)";
                sqlString = sqlString + " select SCOPE_IDENTITY()";



                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = sqlString;

                SqlParameter param1 = new SqlParameter("@Colum1", SqlDbType.VarChar);
                param1.Value = scriptInformation.Nickname;
                sqlCommand.Parameters.Add(param1);






                SqlParameter param2 = new SqlParameter("@Colum2", SqlDbType.Int);
                param2.Value = scriptInformation.Battles;
                sqlCommand.Parameters.Add(param2);





                SqlParameter param3 = new SqlParameter("@Colum3", SqlDbType.Int);
                param3.Value = scriptInformation.Wn_State;
                sqlCommand.Parameters.Add(param3);





                SqlParameter param4 = new SqlParameter("@Colum4", SqlDbType.Int);
                param4.Value = scriptInformation.Damage;
                sqlCommand.Parameters.Add(param4);





                scriptInformation.Player_ID = Convert.ToInt64(sqlCommand.ExecuteScalar());

                //connection.Close();
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
               
                List<string> outputMessages = new List<string>();
                outputMessages.Add("Players has been added.");

                returnStatus = true;
                returnErrorMessage = "";
                returnMessages = outputMessages;

                return scriptInformation;
            }
            catch (Exception ex)
            {
                List<string> outputMessages = new List<string>();
                outputMessages.Add(ex.Message);
        
                returnPageNumber = -1;
                returnRowNumber = -2;
                returnStatus = false;
                returnErrorMessage = ex.Message;
                returnMessages = outputMessages;
                scriptInformation.Player_ID = -1;  // dogrulamada hata varsa pk_id -1 olmali
                //connection.Close();

                return scriptInformation;
            }
            finally
            {
                //connection.Close();
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
               
            }

        }

       


        /// <summary>
        /// Guncelleme (Duzenleme)
        /// </summary>
        public Players UpdatePlayers(Players scriptInformation, 
            out long returnPageNumber,
            out long returnRowNumber,
            out bool returnStatus,          
            out List<string> returnMessages)
        {

            string returnErrorMessage;

            //UtilitiesBLL UtilitiesBLL = new UtilitiesBLL();
            //SqlConnection connection = UtilitiesBLL.CreateConnectionRMSPROD(out returnStatus, out returnErrorMessage);
            SqlConnection connection;
            connection = new SqlConnection();

            try
            {

                //SqlConnection connection;                                                                                                       
                //connectionString = System.Configuration.ConfigurationManager.AppSettings["ScriptDatabase"];
                //String connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RMS-PROD"].ToString();                                                                                                                           //String connectionString = "Server=(localdb)\\mssqllocaldb;Database=AHIM;Trusted_Connection=True;";
                //String connectString = "Data Source=(localdb)\\mssqllocaldb;Database=AHIM;Trusted_Connection=True;MultipleActiveResultSets=true";

                String connectionString = scriptInformation.DBConnectString;

                //connection = new SqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();


                returnPageNumber = -1;  // Siralama degistirilebilir.
                returnRowNumber = -2;    // Siralama sonraki kod ile degistirilebilir.

                //StringBuilder sqlBuilder = new StringBuilder();

                List<string> messages;

                FormatScriptData(ref scriptInformation, out returnStatus, out returnErrorMessage);

                bool validPatient = ValidateScript(
                    scriptInformation,
                    out messages,
                    out returnStatus,
                    out returnErrorMessage);

                if (returnStatus == false)
                {
                    returnStatus = false;
                    messages.Add(returnErrorMessage);
                    returnMessages = messages;
                    return scriptInformation;
                }

                if (validPatient == false)
                {
                    returnStatus = false;                   
                    returnMessages = messages;
                    return scriptInformation;
                }

                string sqlString = "UPDATE Players SET ";
                sqlString = sqlString + " Nickname = @Colum1, ";
                sqlString = sqlString + " Battles = @Colum2, ";
                sqlString = sqlString + " Wn_State = @Colum3, ";
                sqlString = sqlString + " Damage = @Colum4 ";
                sqlString = sqlString + " WHERE Player_ID = @PK_ID ";


                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = sqlString;

                SqlParameter paramPatientID = new SqlParameter("@PK_ID", SqlDbType.BigInt);
                paramPatientID.Value = scriptInformation.Player_ID;
                sqlCommand.Parameters.Add(paramPatientID);

                SqlParameter param1 = new SqlParameter("@Colum1", SqlDbType.VarChar);
                param1.Value = scriptInformation.Nickname;
                sqlCommand.Parameters.Add(param1);






                SqlParameter param2 = new SqlParameter("@Colum2", SqlDbType.Int);
                param2.Value = scriptInformation.Battles;
                sqlCommand.Parameters.Add(param2);





                SqlParameter param3 = new SqlParameter("@Colum3", SqlDbType.Int);
                param3.Value = scriptInformation.Wn_State;
                sqlCommand.Parameters.Add(param3);





                SqlParameter param4 = new SqlParameter("@Colum4", SqlDbType.Int);
                param4.Value = scriptInformation.Damage;
                sqlCommand.Parameters.Add(param4);



                sqlCommand.ExecuteNonQuery();

                //connection.Close();
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
               
                List<string> outputMessages = new List<string>();
                outputMessages.Add("Players has been updated."); // oyuncular guncellendi duzenlendi

                returnStatus = true;
                returnErrorMessage = "";
                returnMessages = outputMessages;

                return scriptInformation;
            }
            catch (Exception ex)
            {
                List<string> outputMessages = new List<string>();

                returnPageNumber = -1;
                returnRowNumber = -2;

                returnStatus = false;
                outputMessages.Add(ex.Message);
                returnMessages = outputMessages;

                return scriptInformation;
            }
            finally
            {
                //connection.Close();
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
               
            }

        }


        /// <summary>
        /// Detaylari sil (Duzenleme kismi)
        /// </summary>
        public Players DelPlayers(Players scriptInformation,
            out long returnPageNumber,
            out long returnRowNumber,
            out bool returnStatus,
            out List<string> returnMessages)
        {

           string returnErrorMessage;

            SqlConnection connection;
            connection = new SqlConnection();

            try
            {

                String connectionString = scriptInformation.DBConnectString;

                //connection = new SqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();


                returnPageNumber = -1;  //   siralama degistir
                returnRowNumber = -2;   //siralama degistir

                string sqlString = "DELETE Players ";
                sqlString = sqlString + " WHERE Player_ID = @PK_ID ";


                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = sqlString;


                SqlParameter paramPatientID = new SqlParameter("@PK_ID", SqlDbType.BigInt);
                paramPatientID.Value = scriptInformation.Player_ID;
                sqlCommand.Parameters.Add(paramPatientID);

                sqlCommand.ExecuteNonQuery();




                //connection.Close();
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
               
                List<string> outputMessages = new List<string>();
                outputMessages.Add("Players has been deleted.");

                returnStatus = true;
                returnErrorMessage = "";
                returnMessages = outputMessages;

                return scriptInformation;
            }
            catch (Exception ex)
            {
                List<string> outputMessages = new List<string>();

                returnPageNumber = -1;
                returnRowNumber = -2;

                returnStatus = false;
                outputMessages.Add(ex.Message);
                returnMessages = outputMessages;

                return scriptInformation;
            }
            finally
            {
                //connection.Close();
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
               
            }

        }



        // coklu (secilen) sil (duzenleme kismi)
        public Players DelPlayersALL(Players scriptInformation,
            out long returnPageNumber,
            out long returnRowNumber,
            out bool returnStatus,
            out List<string> returnMessages)
        {

            string returnErrorMessage;

            SqlConnection connection;
            connection = new SqlConnection();

            try
            {

                String connectionString = scriptInformation.DBConnectString;

                connection.ConnectionString = connectionString;
                connection.Open();


                returnPageNumber = -1;  // sirlama degistiirilebilir
                returnRowNumber = -2;   //siralama degistirilebilir


                string sqlString = "";

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = sqlString;

                // BURADAKI DONGU TUM KAYITLARI DOLASIR VE SILER (DELETE - SECILENLERI SIL)
                string Chkstr;
                int counterk2 = 0;

                //foreach (var recList in scriptInformation.Chk)
                foreach (var recList in scriptInformation.PK_IDD)
                {
                    Chkstr = scriptInformation.CheckBoxx[counterk2];
                    if (Chkstr == "on")
                    {
                        
                        sqlString = sqlString + "DELETE Players ";
                        sqlString = sqlString + " WHERE Player_ID = @PK_IDDD ";

                        SqlParameter param1 = new SqlParameter("@PK_IDDD", SqlDbType.BigInt);
                        param1.Value = scriptInformation.PK_IDD[counterk2];
                        sqlCommand.Parameters.Add(param1);


                        sqlCommand.CommandText = sqlString;
                        sqlCommand.ExecuteNonQuery();
                        sqlCommand.Parameters.Remove(param1);

                        sqlString = "";

                    }

                    counterk2 = counterk2 + 1;
                }


                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
               
                List<string> outputMessages = new List<string>();
                outputMessages.Add("Players/s has been deleted."); // oyuncular silindi

                returnStatus = true;
                returnErrorMessage = "";
                returnMessages = outputMessages;

                return scriptInformation;
            }
            catch (Exception ex)
            {
                List<string> outputMessages = new List<string>();

                returnPageNumber = -1;
                returnRowNumber = -2;

                returnStatus = false;
                outputMessages.Add(ex.Message);
                returnMessages = outputMessages;

                return scriptInformation;
            }
            finally
            {
                //connection.Close();
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
               
            }

        }

        // Tablo gorunumunu COMBO YAP
        public List<Playersnormcombo> GetPlayersnormcombo(out bool returnStatus,
            out string returnErrorMessage)
        {

           UtilitiesBLL UtilitiesBLLget = new UtilitiesBLL();
           SqlConnection connection = UtilitiesBLLget.CreateConnectionRMSPROD(out returnStatus, out returnErrorMessage); //SQL Server
  
            try
            {

                string sqlString = "SELECT normcombopkid, normcombocol1 FROM normcombo ORDER BY normcombocol1 ";


                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = sqlString;

                Playersnormcombo vtype;

                List<Playersnormcombo> vtypeList = new List<Playersnormcombo>();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read() == true)
                //if (dataReader.Read())   // sadece ilk kayit icin
                {
                    vtype = new Playersnormcombo();

                    vtype.normcombopkid = dataReader["normcombopkid"] != DBNull.Value ? Convert.ToInt64(dataReader["normcombopkid"]) : 0;
                    vtype.normcombocol1 = dataReader["normcombocol1"] != DBNull.Value ? dataReader["normcombocol1"].ToString() : "";
                   
                    vtypeList.Add(vtype);

                }

                //connection.Close();
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
               
                returnStatus = true;
                returnErrorMessage = "";

                return vtypeList;

            }
            catch (Exception ex)
            {
                List<Playersnormcombo> vtypeList = new List<Playersnormcombo>();
                returnStatus = false;
                returnErrorMessage = ex.Message;

                return vtypeList;
            }
            finally
            {
                //connection.Close();
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
               
            }


        }


        public List<PlayersRiskLevelList> GetRiskLevels(out bool returnStatus,
            out string returnErrorMessage)
        {

           UtilitiesBLL UtilitiesBLLget = new UtilitiesBLL();
           SqlConnection connection = UtilitiesBLLget.CreateConnectionRMSPROD(out returnStatus, out returnErrorMessage); //SQL Server

            try
            {
                //StringBuilder sqlBuilder = new StringBuilder();

                //sqlBuilder.Append("SELECT Worker_ID, LastName FROM WORKER ORDER BY LastName");
                string sqlString = "SELECT Worker_ID, LastName FROM WORKER ORDER BY LastName";

                //string sqlString = sqlBuilder.ToString();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = sqlString;


                PlayersRiskLevelList vtype;

                List<PlayersRiskLevelList> vtypeList = new List<PlayersRiskLevelList>();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read() == true)
                {
                    vtype = new PlayersRiskLevelList();

                    vtype.RiskLevelID = Convert.ToInt64(dataReader["Worker_ID"]);
                    vtype.RiskLevelName = Convert.ToString(dataReader["LastName"]);

                    vtypeList.Add(vtype);

                }

                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
               
                returnStatus = true;
                returnErrorMessage = "";

                return vtypeList;

            }
            catch (Exception ex)
            {
                List<PlayersRiskLevelList> vtypeList = new List<PlayersRiskLevelList>();
                returnStatus = false;
                returnErrorMessage = ex.Message;

                return vtypeList;

            }
            finally
            {
                //connection.Close();
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
               
            }


        }




        /// GEREKSIZ KISIM BELKI XLS ALMAK ISTER
        public MemoryStream PlayersSearchXLS(
            Players SearchValues,
            string sortBy,
            string sortAscendingDescending,
            out bool returnStatus,
            out string returnErrorMessage)
        {

            long currentPageNumber = 1;
            long pageSize = -1;  // tum kayitlari export et (disa aktar XLS formatinda)

            try
            {
                long totalPages = 0;
                long totalRows = 0;
                long pageRows = 0;
                MemoryStream msout = new MemoryStream();
              

              List<Players> scripts = PlayersSearch(
                SearchValues,
                currentPageNumber,
                pageSize,
                sortBy,
                sortAscendingDescending,
                out totalRows,
                out totalPages,
                out pageRows,
                out returnStatus,
                out returnErrorMessage);

                if (returnStatus == false)
                {
                    return msout;
                }

                var scriptDataTable = CreateDataTable(scripts);

                UtilitiesBLL UtilitiesBLL = new UtilitiesBLL();

                // tabloya yaz XLS
                string[] ColOrderk = new string[5] { "Player_ID", "Nickname", "Battles", "Wn_State", "Damage" };   // sutun adlari
                string[] ColNamek = new string[5] { "Player_ID", "Nickname", "Battles", "Wn_State", "Damage" };
                msout = UtilitiesBLL.TableToXLSXms(scriptDataTable, ColOrderk, ColNamek, true, "c:/AP/PlayersList.xlsx"); 


        
                returnErrorMessage = "";
                returnStatus = true;
                return msout;

            }
            catch (Exception ex)
            {
                returnErrorMessage = ex.Message;
                returnStatus = false;
              
                MemoryStream mserr = new MemoryStream();
                return mserr;
            }

        }



        public MemoryStream PlayersSearchXLSX(
            Players SearchValues,
            string sortBy,
            string sortAscendingDescending,
            out bool returnStatus,
            out string returnErrorMessage)
        {

            long currentPageNumber = 1;
            long pageSize = -1; 

            try
            {
                long totalPages = 0;
                long totalRows = 0;
                long pageRows = 0;
                MemoryStream msout = new MemoryStream();
              

              List<Players> scripts = PlayersSearch(
                SearchValues,
                currentPageNumber,
                pageSize,
                sortBy,
                sortAscendingDescending,
                out totalRows,
                out totalPages,
                out pageRows,
                out returnStatus,
                out returnErrorMessage);

                if (returnStatus == false)
                {
                    return msout;
                }

                var scriptDataTable = CreateDataTable(scripts);

                UtilitiesBLL UtilitiesBLL = new UtilitiesBLL();

           
                string[] ColOrderk = new string[5] { "Player_ID", "Nickname", "Battles", "Wn_State", "Damage" };
                string[] ColNamek = new string[5] { "Player_ID", "Nickname", "Battles", "Wn_State", "Damage" };
                msout = UtilitiesBLL.TableToXLSXms(scriptDataTable, ColOrderk, ColNamek, true, "c:/AP/PlayersList.xlsx"); 


                returnErrorMessage = "";
                returnStatus = true;
                return msout;

            }
            catch (Exception ex)
            {
                returnErrorMessage = ex.Message;
                returnStatus = false;
              
                MemoryStream mserr = new MemoryStream();
                return mserr;
            }

        }


        public string PlayersSearchPDF(
            Players SearchValues,
            long currentPageNumber,
            long pageSize,
            string sortBy,
            string sortAscendingDescending,
            out long totalRows,
            out long totalPages,
            out bool returnStatus,
            out string returnErrorMessage)
        {

            long loopcount = -1;
            long pageSizeReal = pageSize;

            try
            {
                totalPages = 0;
                totalRows = 0;
                long pageRows = 0;
                string strTable = "";
                string trbgcolor = "#D3DCE5";
                string ImagePathSrc = SearchValues.Logoimg;   //goruntulenecek logo


              List<Players> scripts = PlayersSearch(
                SearchValues,
                currentPageNumber,
                pageSize,
                sortBy,
                sortAscendingDescending,
                out totalRows,
                out totalPages,
                out pageRows,
                out returnStatus,
                out returnErrorMessage);

                if (returnStatus == false)
                {
                    //return GridList;
                }

              var scriptDataTable = CreateDataTable(scripts); 

                if (totalRows == 0)
                {
                    strTable = strTable + " <div align='center' style='font-family: Arial; font-size: 12px; color: #0000FF; border: 1px solid #000000;'> ";
                    strTable = strTable + " No Data found."; // veri yok
                    strTable = strTable + " </div> ";
                }


                strTable = strTable + "<table border='0' align='center' style='width: 590px;'>";
        

                for (int i = 0; i < scriptDataTable.Rows.Count; i++)
                {

                    if (i % 2 == 0)
                    {
                        trbgcolor = "#D3DCE5";
                    }
                    else
                    {
                        trbgcolor = "#ebeff2";
                    }


                        Players recList = new Players();

                        recList.Player_ID = scriptDataTable.Rows[i]["Player_ID"] != DBNull.Value ? Convert.ToInt64(scriptDataTable.Rows[i]["Player_ID"]) : 0;

                        recList.Nickname = scriptDataTable.Rows[i]["Nickname"] != DBNull.Value ? scriptDataTable.Rows[i]["Nickname"].ToString() : "";
                     



                    
                        recList.Battles = scriptDataTable.Rows[i]["Battles"] != DBNull.Value ? Convert.ToInt32(scriptDataTable.Rows[i]["Battles"]) : 0;



                     
                        recList.Wn_State = scriptDataTable.Rows[i]["Wn_State"] != DBNull.Value ? Convert.ToInt32(scriptDataTable.Rows[i]["Wn_State"]) : 0;



                     
                        recList.Damage = scriptDataTable.Rows[i]["Damage"] != DBNull.Value ? Convert.ToInt32(scriptDataTable.Rows[i]["Damage"]) : 0;


                    loopcount = loopcount + 1;
                    if (loopcount == pageSizeReal)    //write out a Page of Data
                    {


                        loopcount = 0;  //reset count again
                    }


                        strTable = strTable + "<tr bgcolor='" + trbgcolor + "' >";

                        strTable = strTable + "<td align='left'> ";
                        //strTable = strTable + " <div align='left' style='font-weight: normal; font-family: Arial; font-size: 8px;'> ";
                        strTable = strTable + " <div align='left' style='font-size: 8px; width: 82px;'> ";
                        strTable = strTable + recList.Player_ID;
                        strTable = strTable + " </div> ";
                        strTable = strTable + "</td>";

                        strTable = strTable + "<td align='left'> ";
                        //strTable = strTable + " <div align='left' style='font-weight: normal; font-family: Arial; font-size: 8px;'> ";
                        strTable = strTable + " <div align='left' style='font-size: 8px; width: 154px;'> ";
                        strTable = strTable + recList.Nickname;
                        strTable = strTable + " </div> ";
                        strTable = strTable + "</td>";

                        strTable = strTable + "<td align='left'> ";
                        //strTable = strTable + " <div align='left' style='font-weight: normal; font-family: Arial; font-size: 8px;'> ";
                        strTable = strTable + " <div align='left' style='font-size: 8px; width: 154px;'> ";
                        strTable = strTable + recList.Battles;
                        strTable = strTable + " </div> ";
                        strTable = strTable + "</td>";

                        strTable = strTable + "<td align='center'> ";
                        //strTable = strTable + " <div align='center' style='font-weight: normal; font-family: Arial; font-size: 8px;'> ";
                        strTable = strTable + " <div align='center' style='font-size: 8px; width: 100px;'> ";
                        strTable = strTable + recList.Wn_State;
                        strTable = strTable + " </div> ";
                        strTable = strTable + "</td>";

                        strTable = strTable + "<td align='center'> ";
                        //strTable = strTable + " <div align='center' style='font-weight: normal; font-family: Arial; font-size: 8px;'> ";
                        strTable = strTable + " <div align='center' style='font-size: 8px; width: 100px;'> ";
                        strTable = strTable + recList.Damage;
                        strTable = strTable + " </div> ";
                        strTable = strTable + "</td>";

                        //END of data ROW
                        strTable = strTable + "</tr>";


                }
            
                strTable = strTable + "</table>";

                returnErrorMessage = "";
                returnStatus = true;
              
                return strTable;

            }
            catch (Exception ex)
            {
                returnErrorMessage = ex.Message;
                returnStatus = false;
                totalPages = 0;
                totalRows = 0;

                string errstr = "";
                errstr = errstr + " <div align='center' style='font-family: Arial; font-size: 12px; color: #0000FF; border: 1px solid #000000;'> ";
                errstr = errstr + " Error Found: " + returnErrorMessage;
                errstr = errstr + " </div> ";

                return errstr;

            }

        }



        private bool IsNumeric(object value)
        {
            bool Result = false;

            try
            {
                long i = Convert.ToInt64(value);
                Result = true;
            }
            catch
            {
                //  hata yok say
            }
            return Result;
        }


        private bool IsDouble(object value)
        {
            bool Result = false;

            try
            {
                double i = Convert.ToDouble(value);
                Result = true;
            }
            catch
            {

            }
            return Result;
        }


        private bool IsDecimal(object value)
        {
            bool Result = false;

            try
            {
                decimal i = Convert.ToDecimal(value);
                Result = true;
            }
            catch
            {
              

            }
            return Result;
        }



        public DataSet CreateDataSet<T>(List<T> list)
        {
            //liste hicbir sey icermiyor
            if (list == null || list.Count == 0) { return null; }

            //listedeki ilk objenin tipi
            var obj = list[0].GetType();

            //now grab all properties
            var properties = obj.GetProperties();

            // nesnelerin ozelliklei olmali (emin olmak icin)
            if (properties.Length == 0) { return null; }

            //tablo olusturur
            var dataSet = new DataSet();
            var dataTable = new DataTable();

            //sutun olustur
            var columns = new DataColumn[properties.Length];
            for (int i = 0; i < properties.Length; i++)
            {
                columns[i] = new DataColumn(properties[i].Name, properties[i].PropertyType);
            }

            //tabloya ekle kolonlari
            dataTable.Columns.AddRange(columns);

            // degerleri ekle
            foreach (var item in list)
            {
                // yeni tablo olustur
                var dataRow = dataTable.NewRow();

                // huclereleri yenileyip degerleri al
                var itemProperties = item.GetType().GetProperties();

                for (int i = 0; i < itemProperties.Length; i++)
                {
                    dataRow[i] = itemProperties[i].GetValue(item, null);
                }

                // tablo ekle
                dataTable.Rows.Add(dataRow);
            }

           
            dataSet.Tables.Add(dataTable);

            return dataSet;
        }

        public DataTable CreateDataTable<T>(List<T> list)
        {
            if (list == null || list.Count == 0) { return null; }

            var obj = list[0].GetType();

            var properties = obj.GetProperties();

            if (properties.Length == 0) { return null; }

            var dataSet = new DataSet();
            var dataTable = new DataTable();

            var columns = new DataColumn[properties.Length];
            for (int i = 0; i < properties.Length; i++)
            {
                columns[i] = new DataColumn(properties[i].Name, properties[i].PropertyType);
            }

            dataTable.Columns.AddRange(columns);

            foreach (var item in list)
            {
                var dataRow = dataTable.NewRow();

                var itemProperties = item.GetType().GetProperties();

                for (int i = 0; i < itemProperties.Length; i++)
                {
                    dataRow[i] = itemProperties[i].GetValue(item, null);
                }

                dataTable.Rows.Add(dataRow);
            }


            return dataTable;
        }






    }

}
