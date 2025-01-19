using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transa
{
    public class LData
    {
        public enum EIdentificationColumnsTransition
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
        // segnala che la struttura dei conti è ok
        public bool ContiOk = false;
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
        /// Lista dei conti Entrate
        /// </summary>
        public List<string> contiEntrate = new List<string>();
        /// <summary>
        /// Lista dei conti Entrate
        /// </summary>
        public List<string> contiUscite = new List<string>();
        /// <summary>
        /// Lista dei conti Passivita
        /// </summary>
        public List<string> contiPassivita = new List<string>();
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
            "Entrate",
            "Uscite",
            "Passivita"
        };
        /// <summary>
        /// Gruppo SottoConti
        /// </summary>
        public enum EGruppoSottoconti 
        {
            BG,
            CCat,
            FA,
            GG,
            LC
        };
        /// <summary>
        /// Gruppo SottoConti
        /// </summary>
        public string[] sGruppoSottoconti =
        {
            EGruppoSottoconti.BG.ToString(),
            EGruppoSottoconti.CCat.ToString(),
            EGruppoSottoconti.FA.ToString(),
            EGruppoSottoconti.GG.ToString(),
            EGruppoSottoconti.LC.ToString()
        };
        // =====================================================================================
        // ====== Tipo sottoconti
        // =====================================================================================
        /// <summary>
        /// Tipo Sottoconti
        /// </summary>
        public enum ETipoSottoconti
        {
            Single,
            Cnt,
            Dep,
            All
        };
        /// <summary>
        /// Tipo Sottoconti
        /// </summary>
        public string[] TipoSottoconti =
        {
            ETipoSottoconti.Single.ToString(),
            ETipoSottoconti.Cnt.ToString(),
            ETipoSottoconti.Dep.ToString(),
            ETipoSottoconti.All.ToString(),
        };
        // =====================================================================================
        // ====== Tipo operazione
        // =====================================================================================
        /// <summary>
        /// Tipo Operazione
        /// </summary>
        public enum ETipoOperazione 
        {
            Transition,
            Open,
            Close,
            Split,
            Zip,
            ZipSplit,
            TitoloAcquisto,
            TitoloRimborso
        };
        /// <summary>
        /// Tipo Operazione
        /// </summary>
        public string[] TipoOperazione =
        {
            ETipoOperazione.Transition.ToString(),
            ETipoOperazione.Open.ToString(),
            ETipoOperazione.Close.ToString(),
            ETipoOperazione.Split.ToString(),
            ETipoOperazione.Zip.ToString(),
            ETipoOperazione.ZipSplit.ToString(),
            ETipoOperazione.TitoloAcquisto.ToString(),
            ETipoOperazione.TitoloRimborso.ToString()
        };
        /// tipo di operazione in una transizione Zip o Split
        /// </summary>
        public enum ETipoOperazioneComplessa
        {
            Boh,
            TOTALE,
            SPLIT,
            ZIP
        };

        // =====================================================================================
        // ====== Codice errore
        // =====================================================================================
        public enum ETransaErrore
        {
            E0000_OK = 0,
            E0001_NOK = 1,
            E0002_ValoreNonRichiesto,

            // Errori relativi alla gestione di una tabelle
            E1000_TabellaInesistente,
            E1001_ColonnaTabellaFuoriLimiti,
            E1002_RigaTabellaFuoriLimiti,
            E1003_CellaTabellaFuoriLimiti,
            E1004_IndiceColonnaTabellaFuoriLimiti,
            E1005_IndiceRigaTabellaFuoriLimiti,
            E1006_IndiceCellaTabellaFuoriLimiti,
            E1007_LaDimensioniDelleTabelleSorgenteEDestinazioneSonoDiverse ,

            // Stato dei conti
            E1100_IContiNonSonoBilanciati,
            E1101_ISottoContiAttiviSonoDiversi,
            E1102_IContiBaseSonoDiversi,
            E1103_StrutturaDeiContiNonDisponibile,

            // Operazioni
            E1200_UnaOperazioneInCorso,

            // Errori relativi ad un tipo di dato
            //10 sbyte System.SByte
            //20 byte System.Byte
            //30 short System.Int16
            //40 ushort System.UInt16
            //50 int System.Int32
            //60 uint System.UInt32
            //70 long System.Int64
            //80 ulong System.UInt64
            //90 char System.Char
            //100 float System.Single

            E2100_double_LaStringaNonContieneUnValoreDouble,
            // 110 bool System.Boolean
            // 120 decimal System.Decimal


        }





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
        /// <summary>
        /// Esamina una stringa e sostituisce:
        /// - La lettera maiuscola con spazio + lettera maiuscola
        /// - il cratttere '_' con spazio
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public string RestultToSting(ETransaErrore error)
        {
            string errore = error.ToString();
            string messaggioErrore = "";

            // sostituisci tutte le lettere maiuscole con spazio-lettera
            bool maiuscola = true;
            for (int i = 0; i < errore.Length; i++)
            {
                               
                if (Char.IsUpper(errore[i]) && i > 0)
                {
                    messaggioErrore += " ";
                    if (maiuscola)
                    {
                        messaggioErrore += errore[i];
                        maiuscola = false;
                    }
                    else
                        messaggioErrore += Char.ToLower(errore[i]);
                }
                else if (errore[i] == '_')
                {
                    messaggioErrore += ":";
                    messaggioErrore += " ";
                    maiuscola = true;
                }
                else
                    messaggioErrore += errore[i];
            }

            return messaggioErrore;
        }
        /// <summary>
        /// Stampa un messaggio di errore
        /// </summary>
        /// <param name="result"></param>
        /// <param name="messaggio2"></param>
        /// <param name="stampaMessaggio"></param>
        /// <returns></returns>
        public bool StampaMessaggioErrore(LData.ETransaErrore esito, string messaggio2 = "", bool stampaMessaggio = true, bool continuo = true)
        {
            // controlla l'esito del risultatao
            if (esito != ETransaErrore.E0000_OK)
            {
                if (stampaMessaggio)
                {
                    // compone il messaggio da stampare
                    string titolo = "Errore!";
                    string messaggio = "Problema: \n" + messaggio2 + "\n\n" +
                                       "ha generato l'errore: \n\n" +
                                       RestultToSting(esito);

                    // Chiede la conferma per continuare                    
                    if (continuo)
                    {
                        messaggio += "\n\n" + "Continuo?";

                        //  stampa il messaggio con l'esito
                        var result3 = MessageBox.Show(messaggio, titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (result3 == DialogResult.Yes)
                            return true;
                        else
                            return false;
                    }

                    // Rende sempre FALSE
                    if (!continuo)
                    {
                        //  stampa il messaggio con l'esito
                        var result3 = MessageBox.Show(messaggio, titolo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    return false;
                }
                else
                    return false;
            }

            return true;
        }
    }
}
