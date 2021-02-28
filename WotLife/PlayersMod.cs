using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace appMODEL
{

    public class Players
    {

        public string DBConnectString { get; set; }

        public long Player_ID { get; set; }

        public string Nickname { get; set; }

        public int Battles { get; set; }

        public int Wn_State { get; set; }

        public int Damage { get; set; }

        public string GlobalSearchString { get; set; }
        public double TimeDiff { get; set; }                   // Offset date icin dunyanin herhangi bir yerinde saati almak icin

        public string Nickname_Str { get; set; }
        public string Battles_Str { get; set; }
        public string Wn_State_Str { get; set; }
        public string Damage_Str { get; set; }


        public string Date_Bought_From { get; set; }
        public string Date_Bought_To { get; set; }
        public string Created_By { get; set; }

        public List<long> PK_IDD { get; set; }
        public List<string> CheckBoxx { get; set; }

        public string Logoimg { get; set; }

        //-----------------------------------------------------------------------------
        // normcombo ya gerek yok / tablo / view gorunumu degisti
        //-----------------------------------------------------------------------------
        public long normcombopkid { get; set; }    
        public string normcombocol1 { get; set; }   //formda gosterilir
        public List<Playersnormcombo> PlayersnormcomboList { get; set; }  
        //-----------------------------------------------------------------------------
        public List<PlayersType> PlayersTypes { get; set; }   

        public long Document_ID { get; set; }  
        public string Risk_Level { get; set; }
        public long Risk_Level_ID { get; set; }
        public List<PlayersRiskLevelList> RiskTypess { get; set; }



        public int Private_Cover { get; set; }


        public string Sex { get; set; }

    }


    public class Playersnormcombo
    {
        public long normcombopkid { get; set; } 
        public string normcombocol1 { get; set; }  
    }

    public class PlayersType
    {
        public long Players_Type_ID { get; set; }
        public string PlayersTypeName { get; set; }
    }


    public class PlayersRiskLevelList
    {
        public long RiskLevelID { get; set; }
        public string RiskLevelName { get; set; }
    }



}
