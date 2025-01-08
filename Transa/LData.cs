using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transa
{
    public class LData
    {
        public enum IdentificationColumnsTransition
        {
            Data,                   // 0                       
            IDTransazione,          // 1               
            Numero,                 // 2   
            Descrizione,            // 3
            Note,                   // 4
            CommodityValuta,        // 5
            MotivoAnnullamento,     // 6
            Operazione,             // 7
            Promemoria,             // 8
            NomeCompletoDelConto,   // 9
            NomeDelConto,           // 10
            ImportoConSimb,         // 11
            ImportoNum,             // 12
            ValoreConSimb,          // 13
            ValoreNum,              // 14
            Riconcilia,             // 15
            DataDiDiconciliazione,  // 16
            TassoPrezzo             // 17
        };
        /// <summary>
        /// Nome delle colonne di una transizione
        /// </summary>
        public string[] NameColumnsTransition =
        {
            "Data",                         // 0
            "ID transazione",               // 1
            "Numero",                       // 2
            "Descrizione",                  // 3
            "Note",                         // 4
            "Commodity/Valuta",             // 5
            "Motivo annullamento",          // 6
            "Operazione",                   // 7
            "Promemoria",                   // 8
            "Nome completo del conto",      // 9
            "Nome del conto",               // 10
            "Importo con Simb",             // 11    
            "Importo Num.",                 // 12
            "Valore con Simb",              // 13
            "Valore Num.",                  // 14
            "Riconcilia",                   // 15
            "Data di riconciliazione",      // 16
            "Tasso/Prezzo"                  // 17
        };
        /// <summary>
        /// Carattere di incaplulazione di un campo transizione
        /// </summary>
        public Char[] EncapsulationCharacterOfATransitionField =
        {
            '\0',           //  0 "Data",
            '\0',           //  1 "ID transazione",
            '\0',           //  2 "Numero",
            '"',            //  3 "Descrizione",
            '\0',           //  4 "Note",
            '\0',           //  5 "Commodity/Valuta",
            '\0',           //  6 "Motivo annullamento",
            '\0',           //  7 "Operazione",
            '"',           //  8 "Promemoria",
            '\0',           //  9 "Nome completo del conto",
            '\0',           // 10 "Nome del conto",
            '"',            // 11 "Importo con Simb",
            '"',            // 12 "Importo Num.",
            '"',            // 13 "Valore con Simb",
            '"',            // 14 "Valore Num.",
            '\0',           // 15 "Riconcilia",
            '\0',           // 16 "Data di riconciliazione",
            '"'             // 17 "Tasso/Prezzo"
        };
        /// <summary>
        /// Celle della riga trasizione da filtatre
        /// </summary>
        public bool[] transitionColumnsToFilter =
        {
            false,          //  0 "Data",
            true,           //  1 "ID transazione",
            true,           //  2 "Numero",
            false,          //  3 "Descrizione",
            true,           //  4 "Note",
            true,          //  5 "Commodity/Valuta",
            true,           //  6 "Motivo annullamento",
            true,           //  7 "Operazione",
            false,          //  8 "Promemoria",
            false,          //  9 "Nome completo del conto",
            false,          // 10 "Nome del conto",
            true,          // 11 "Importo con Simb",
            false,          // 12 "Importo Num.",
            true,          // 13 "Valore con Simb",
            true,          // 14 "Valore Num.",
            true,          // 15 "Riconcilia",
            true,          // 16 "Data di riconciliazione",
            true           // 17 "Tasso/Prezzo"
        };
        /// <summary>
        /// Voli delle celle filtare
        /// </summary>
        public string[] FilteredCellValuesOfTheTrasizioneLine =
         {
            "",             //  0 "Data",
            "",             //  1 "ID transazione",
            "",             //  2 "Numero",
            "",             //  3 "Descrizione",
            "",             //  4 "Note",
            "CURRENCY::EUR",//  5 "Commodity/Valuta",
            "",             //  6 "Motivo annullamento",
            "",             //  7 "Operazione",
            "",             //  8 "Promemoria",
            "",             //  9 "Nome completo del conto",
            "",             // 10 "Nome del conto",
            "",             // 11 "Importo con Simb",
            "",             // 12 "Importo Num.",
            "",             // 13 "Valore con Simb",
            "",             // 14 "Valore Num.",
            "n",            // 15 "Riconcilia",
            "",             // 16 "Data di riconciliazione",
            "1,0000",       // 17 "Tasso/Prezzo"
        };

        /// <summary>
        /// Nome del file da cui è stata prelevata la struttura dei conti
        /// </summary>
        public string fileNameConti = "";
        /// <summary>
        /// Lista dei conti
        /// </summary>
        public List<string> conti = new List<string>();
        /// <summary>
        /// Lista dei conti Attività
        /// </summary>
        public List<string> contiAttivita = new List<string>();
        /// <summary>
        /// Lista dei conti Attività base
        /// </summary>
        public List<string> contiAttivitaBase = new List<string>();
        /// <summary>
        /// Lista dei conti Capitali
        /// </summary>
        public List<string> contiCapitali = new List<string>();
        /// <summary>
        /// Lista dei conti Capitali base
        /// </summary>
        public List<string> contiCapitaliBase = new List<string>();
        /// <summary>
        /// Lista dei conti Capitali base iniziale
        /// </summary>
        public List<string> contiCapitaliBaseIniziale = new List<string>();
        /// <summary>
        /// Lista dei conti Capitali base Finale
        /// </summary>
        public List<string> contiCapitaliBaseFinale = new List<string>();
        /// <summary>
        /// Selezione dei conti
        /// </summary>
        public string[] TipoConti =
        {
            "All",
            "Attivita",
            "AttivitaBase",
            "Capitali",
            "CapitaliBase",
            "CapitaliBaseIniziale",
            "CapitaliBaseFinale",
        };
        /// <summary>
        /// Sotto conti
        /// </summary>
        public string[] ContiMultipli =
        {
            "BG",
            "CCat",
            "FA",
            "GG",
            "LC",
        };
        /// <summary>
        /// Tipo Sottoconti
        /// </summary>
        public string[] TipoSottoconti =
        {
            "Single",
            "Cnt",
            "Dep",
            "All"
        };
        /// <summary>
        /// Tipo Operazione
        /// </summary>
        public string[] TipoOperazione = 
        {
            "Transition",
            "Open",
            "Close",
            "Split",
            "Zip"
        };

        //=======================================================================================================
        //====== DEBUG
        //=======================================================================================================

        public double DEBUG_ValoreDefaultSorgente = 1;
        public double DEBUG_ValoreDefaultDestinazione = 1;



        /// <summary>
        /// Costruttore
        /// </summary>
        public LData()
        {

        }
    }
}
