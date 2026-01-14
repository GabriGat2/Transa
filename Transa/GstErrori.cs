using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transa
{
    public static class GstErrori
    {
        // =====================================================================================
        // ====== Codice errore
        // =====================================================================================
        public enum EErrore
        {
            E0000_OK = 0,
            E0001_NOK = 1,
            E0002_ValoreNonRichiesto,
            E0003_FinestraDeiMessaggiNonDefinita,
            E0004_QuestaFunzioneNonPuoEssereChiamataFareOverride,
            E0005_Exception,


            // Errori relativi alla gestione di una tabelle
            E1000_TabellaInesistente,
            E1001_ColonnaTabellaFuoriLimiti,
            E1002_RigaTabellaFuoriLimiti,
            E1003_CellaTabellaFuoriLimiti,
            E1004_IndiceColonnaTabellaFuoriLimiti,
            E1005_IndiceRigaTabellaFuoriLimiti,
            E1006_IndiceCellaTabellaFuoriLimiti,
            E1007_LaDimensioniDelleTabelleSorgenteEDestinazioneSonoDiverse,

            // Stato dei conti
            E1100_IContiNonSonoBilanciati,
            E1101_ISottoContiAttiviSonoDiversi,
            E1102_IContiBaseSonoDiversi,
            E1103_StrutturaDeiContiNonDisponibile,


            // Operazioni
            E1200_UnaOperazioneInCorso,

            // Gestione directory
            E1300_NomeArchivioErrato,

            E1310_PathArchivioErrato,
            E1311_PathAreaArchivioErrata,
            E1312_PathEscursioneErrato,
            E1313_PathTracciaErrato,

            E1320_PathArchivioNonEsiste,
            E1321_PathAreaArchivioNonEsiste,
            E1322_PathEscursioneNonEsiste,
            E1323_PathTracciaNonEsiste,

            E1330_PathArchivioEsiste,
            E1331_PathAreaArchivioEsiste,
            E1332_PathEscursioneEsiste,
            E1333_PathTracciaEsiste,

            E1330_PathArchivioCreazioneFallita,
            E1331_PathAreaArchivioCreazioneFallita,
            E1332_PathEscursioneCreazioneFallita,
            E1333_PathTracciaCreazioneFallita,
            E1334_DirectoryCreazioneFallita,

            E1340_NonEsiste,
            E1341_Esiste,
            E1342_AreaArchivioNonEsiste,
            E1343_AreaArchivioEsiste,
            E1344_EscursioneNonEsiste,
            E1345_Escursionesiste,
            E1346_TracciaNonEsiste,
            E1347_TracciaEsiste,

            E1350_FileNonEsiste,
            E1351_FileEsiste,
            E1355_FileNonSpostato,
            E1356_FileSpostato,
            E1357_FileNonCopiato,
            E1358_FileCopiato,
            E1359_FileNonCancellato,
            E1360_FileCancellato,

            E1360_IstruzioneErrata,
            E1360_IstruzioneSconosciuta,

            E1370_IdentitaOK,
            E1371_IdentitaNOK,
            E1372_IdentitaEsiste,
            E1373_IdentitaNonEsiste,
            E1374_IdentitaGenitore,
            E1375_IdentitaParente,


            //E1310_PathArchivioNonEsiste,
            //E1310_PathAreaArchivioNonEsiste,
            //E1310_PathEscursioneNonEsiste,
            //E1310_PathTracciaNonEsiste,


            //E1301_CreazioneDirectoryFallita,
            //E1302_CreazioneArchivioFallita,

            //E1303_PathAreaArchivioErrata,
            //E1304_PathArchivioEscursioneErrato,
            //E1305_PathArchivioTracciaErrato,
            //E1306_ArchivioEsiste,



            E1324_EscursionePresente,


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



        /// <summary>
        /// Costruttore
        /// </summary>
        //public GstErrori()
        //{

        //}
        /// <summary>
        /// Esamina una stringa e sostituisce:
        /// - La lettera maiuscola con spazio + lettera maiuscola
        /// - il cratttere '_' con spazio
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static string RestultToSting(EErrore error)
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
        public static bool StampaMessaggioErrore(GstErrori.EErrore esito, string messaggio2 = "", bool stampaMessaggio = true, bool continuo = true)
        {
            // controlla l'esito del risultatao
            if (esito != EErrore.E0000_OK)
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
        /// <summary>
        /// Stampa un avviso
        /// </summary>
        /// <param name="esito"></param>
        /// <param name="messaggio2"></param>
        /// <param name="stampaMessaggio"></param>
        /// <param name="continuo"></param>
        /// <returns></returns>
        public static bool StampaMessaggioAvviso(GstErrori.EErrore esito, string messaggio2 = "", bool stampaMessaggio = true, bool continuo = true)
        {
            // controlla l'esito del risultatao
            if (esito != EErrore.E0000_OK)
            {
                if (stampaMessaggio)
                {
                    // compone il messaggio da stampare
                    string titolo = "Attenzione";
                    string messaggio = "Problema: \n" + messaggio2 + "\n\n" +
                                       "ha generato l'avviso: \n\n" +
                                       RestultToSting(esito);

                    // Chiede la conferma per continuare                    
                    if (continuo)
                    {
                        messaggio += "\n\n" + "Continuo?";

                        //  stampa il messaggio con l'esito
                        var result3 = MessageBox.Show(messaggio, titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result3 == DialogResult.Yes)
                            return true;
                        else
                            return false;
                    }

                    // Rende sempre FALSE
                    if (!continuo)
                    {
                        //  stampa il messaggio con l'esito
                        var result3 = MessageBox.Show(messaggio, titolo, MessageBoxButtons.OK, MessageBoxIcon.Question);
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
