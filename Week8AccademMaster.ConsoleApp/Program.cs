// See https://aka.ms/new-console-template for more information
using Week8AccademMaster.Core.BusinessLayer;
using Week8AccademMaster.Core.Entities;
using Week8AccademMaster.Core.InterfaceRepository;
using Week8AccademMaster.RepositoryEF;
using Week8AccademMaster.RepositoryMock;

Console.WriteLine("Hello, World!");

 IBusinessLayer bl = new MainBusinessLayer(new RepositoryCorsoMock(),new RepositoryStudenteMock(), new RepositoryDocenteMock() ,new RepositoryLezioneMock());
// stiamo creando un oggetto di tipo MainBusinnesLayer , passandogli repository Corsi mock(oggettto che eredita da  Irepository)c'è ibusinesslayer per generalizzare
//seguendo c'è il costruttore
//riga serve per far parlaree i progetti

bool continua = true;
while (continua)
{
    int scelta = SchermoMenu();
    continua = AnalizzaScelta(scelta);
}


int SchermoMenu()
{
    Console.WriteLine("************Menu***********");
    Console.WriteLine("\nFunzionalità Corsi");
    Console.WriteLine("1.Visualizza Corsi");
    Console.WriteLine("2.Inserire nuovo corso");
    Console.WriteLine("3.Modificare un corso");
    Console.WriteLine("4.Eliminare un corso");
    Console.WriteLine("\nFunzionalità Studenti");
    Console.WriteLine("5.Visualizza elenco completo degli Studenti");
    Console.WriteLine("6.Inserire nuovo Studente");
    Console.WriteLine("7.Modicare email di uno studente");
    Console.WriteLine("8.Eliminare uno studente");
    Console.WriteLine("9.Visualizzare l'elenco degli studenti iscritti ad un corso");
    Console.WriteLine("\nFunzionalità Docenti");
    Console.WriteLine("10.Visualizza Docenti");
    Console.WriteLine("12.Inserire nuovo docente");
    Console.WriteLine("13.Modificare un docente");
    Console.WriteLine("14.Eliminare un docente");
    Console.WriteLine("\n0 Exit");
    Console.WriteLine("************************");

    int scelta;
    Console.WriteLine("Inserisci la tua scelta:");
    while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta <= 9))
            {

    Console.WriteLine("SCELTA ERRATA.INSERISCI UN SCELTA");

     
    }
return scelta;
}
bool AnalizzaScelta(int scelta)
{
    switch (scelta)
    {
        case 1:
            VisualizzaCorsi();
            break;
        case 2:
            InserisciCorso();
            break;
        case 3:
            ModificaCorso();
            break;
        case 4:
            EliminaCorso();
            break;
        case 5:
            VisualizzaStudenti();
            break;
        case 6:
            InserisciStudente();
            break;
        case 7:
            ModificaStudente();
            break;
        case 8:
           EliminaStudente();
            break;
        case 9:
            VisualizzaStudentiCorso();
            break;
        case 10:
            VisualizzareDocenti();
            break;
        case 11:
            InserisciDocente();
            break;
        case 12:
           ModificaDocente();
            break;
        case 13:
            EliminaDocente();
            break;
        case 14:
            VisualizzaLezione();
            break;
        case 15:
            InserisciLezione();
            break;
        case 16:
            ModificaLezione();
            break;
        case 17:
            EliminaLezione();
            break;
        case 0:
            return false;
            //default:
            //    break;


    }
    return true;
}

void EliminaLezione()
{
    Console.WriteLine("ecco l'elenco delle lezioni disponibili:");
    VisualizzaLezione();
    Console.WriteLine("quale lezione intendi eliminare ?Inserisci il codice: ");
    int Lezioneid = int.Parse(Console.ReadLine());
    Esito esito = bl.RimuoviLezione(Lezioneid);
    Console.WriteLine(esito.Messaggio);
}

void ModificaLezione()
{
    Console.WriteLine("ecco l'elenco delle lezioni disponibili:");
    VisualizzaLezione();
    Console.WriteLine("quale lezione intendi modificare?Inserisci il codice: ");
    int LezioneId = int.Parse(Console.ReadLine());

    Console.WriteLine("Inserisci l'aula  della nuova lezione:");
    string aula = Console.ReadLine();
    

    Esito esito = bl.ModificaLezione(LezioneId, aula);
    Console.WriteLine(esito.Messaggio);

}

void InserisciLezione()
{
    Console.WriteLine("Inserisci il codice della nuova Lezione:");
    int LezioneId = int.Parse(Console.ReadLine());
    
    Console.WriteLine("Inserisci l'orario d'inizio del nuovo docente:");
    DateTime orarioInizio =DateTime.Parse( Console.ReadLine());
    Console.WriteLine("Inserisci la durata d'inizio del nuovo docente:");
    int durata =int.Parse( Console.ReadLine());
    Console.WriteLine("Inserisci l'aula del nuovo docente:");
    string aula = Console.ReadLine();

    
    Lezione nuovalezione= new Lezione();
    nuovalezione.OrarioInizio = orarioInizio;
    nuovalezione.Durata = durata;
    nuovalezione.Aula = aula;
    

    // aggiungerlo e far visualizzare un messaggio di buon aggiunta

    Esito esito = bl.AddNuovoLezione(nuovalezione);
    Console.WriteLine(esito.Messaggio);
}

void VisualizzaLezione()
{
    List<Lezione> listaLezione = bl.GetAllLezione();// deve essere popolata con 


    //stampa lista e controlli che non sia vuota aggiungendo if

    if (listaLezione.Count == 0)
    {
        Console.WriteLine("Lista vuota");

    }
    else
    {
        foreach (var item in listaLezione)
        {
            Console.WriteLine(item);
        }
    }
}

void EliminaDocente()
{
    Console.WriteLine("ecco l'elenco dei docenti disponibili:");
    VisualizzareDocenti();
    Console.WriteLine("quale docente intendi eliminare ?Inserisci il codice: ");
    int id = int.Parse(Console.ReadLine());
    Esito esito = bl.RimuoviDocente(id);
    Console.WriteLine(esito.Messaggio);
}

void ModificaDocente()
{
    Console.WriteLine("ecco l'elenco dei docenti disponibili:");
    VisualizzareDocenti();
    Console.WriteLine("quale studente intendi modificare?Inserisci il codice: ");
    int id = int.Parse(Console.ReadLine());

    Console.WriteLine("Inserisci l'email  del nuovo docente:");
    string email = Console.ReadLine();
    Console.WriteLine("Inserisci il telefono  del nuovo docente:");
    string numeroTelefono = Console.ReadLine();

    Esito esito = bl.ModificaDocente(id, email,numeroTelefono);
    Console.WriteLine(esito.Messaggio);

}

void InserisciDocente()
{
    Console.WriteLine("Inserisci il codice del nuovo docente:");
    int DocenteID = int.Parse(Console.ReadLine());
    Console.WriteLine("Inserisci il nome del nuovo docente:");
    string nome = Console.ReadLine();
    Console.WriteLine("Inserisci il Cognome del nuovo docente:");
    string cognome = Console.ReadLine();
    
    Console.WriteLine("Inserisci l'email  del nuovo docente:");
    string email = Console.ReadLine();
    Console.WriteLine("Inserisci il telefono di studio del nuovo docente:");
    string numeroTelefono = Console.ReadLine();

    Docente nuovoDocente = new Docente();
    nuovoDocente.Nome = nome;
    nuovoDocente.Cognome = cognome;
    nuovoDocente.Email = email;
    nuovoDocente.Telefono = numeroTelefono;

    // aggiungerlo e far visualizzare un messaggio di buon aggiunta

    Esito esito = bl.AddNuovoDocente(nuovoDocente);
    Console.WriteLine(esito.Messaggio);
}

void VisualizzareDocenti()
{
    List<Docente> listaDocenti = bl.GetAllDocenti();// deve essere popolata con 


    //stampa lista e controlli che non sia vuota aggiungendo if

    if (listaDocenti.Count == 0)
    {
        Console.WriteLine("Lista vuota");

    }
    else
    {
        foreach (var item in listaDocenti)
        {
            Console.WriteLine(item);
        }
    }
}

void VisualizzaStudentiCorso()
{
    Console.WriteLine("ecco l'elenco dei corsi :");
    VisualizzaCorsi();
    Console.WriteLine("quale corso vuoi scegliere? inserisci il codice:");
    string codice = Console.ReadLine();

    List<Studente> listaStudenti = bl.GetStudentiByCorso(codice);
    if (listaStudenti.Count == 0)
    {
        Console.WriteLine("lista vuota");
    } else
    {
        foreach(var item in listaStudenti)
        {
            Console.WriteLine(item);
        }
    }
}

void EliminaStudente()
{
    Console.WriteLine("ecco l'elenco dei studenti disponibili:");
    VisualizzaStudenti();
    Console.WriteLine("quale studente intendi eliminare ?Inserisci il codice: ");
    int id = int.Parse(Console.ReadLine());
    Esito esito = bl.RimuoviStudente(id);
    Console.WriteLine(esito.Messaggio);
}

void ModificaStudente()
{
    Console.WriteLine("ecco l'elenco dei srudenti disponibili:");
    VisualizzaStudenti();
    Console.WriteLine("quale studente intendi modificare?Inserisci il codice: ");
    int id = int.Parse(Console.ReadLine());
    
    Console.WriteLine("Inserisci l'email  del nuovo studente:");
    string email = Console.ReadLine();
    
    Esito esito = bl.ModificaStudente(id,email);
    Console.WriteLine(esito.Messaggio);
}

void InserisciStudente()
{
    Console.WriteLine("Inserisci il codice del nuovo studente:");
    int studenteID=int.Parse( Console.ReadLine());
    Console.WriteLine("Inserisci il nome del nuovo studente:");
    string nome = Console.ReadLine();
    Console.WriteLine("Inserisci il Cognome del nuovo studente:");
    string cognome = Console.ReadLine();
    Console.WriteLine("Inserisci la data di nascita del nuovo studente:");
    DateTime dataNascita = DateTime.Parse(Console.ReadLine());
    Console.WriteLine("Inserisci l'email  del nuovo studente:");
    string email = Console.ReadLine();
    Console.WriteLine("Inserisci il titolo di studio del nuovo studente:");
    string titoloStudio=Console.ReadLine();

    Studente nuovoStudente = new Studente();
    nuovoStudente.Nome = nome;
    nuovoStudente.Cognome = cognome;
    nuovoStudente.DataNascita = dataNascita;
    nuovoStudente.Email = email;
    nuovoStudente.TitoloStudio = titoloStudio;

    // aggiungerlo e far visualizzare un messaggio di buon aggiunta

    Esito esito = bl.AddNuovoStudente(nuovoStudente);
    Console.WriteLine(esito.Messaggio);

}

void VisualizzaStudenti()
{

    List<Studente> listaStudenti = bl.GetAllStudenti();// deve essere popolata con 


    //stampa lista e controlli che non sia vuota aggiungendo if

    if (listaStudenti.Count == 0)
    {
        Console.WriteLine("Lista vuota");

    }
    else
    {
        foreach (var item in listaStudenti)
        {
            Console.WriteLine(item);
        }
    }
}

void EliminaCorso()
{
    Console.WriteLine("ecco l'elenco dei corsi disponibili:");
    VisualizzaCorsi();
    Console.WriteLine("quale corso intendi eliminare ?Inserisci il codice: ");
    string codice = Console.ReadLine();
    Esito esito =bl.RimuoviCorso(codice);
    Console.WriteLine(esito.Messaggio);
}

void ModificaCorso()
{
    Console.WriteLine("ecco l'elenco dei corsi disponibili:");
    VisualizzaCorsi();
    Console.WriteLine("quale corso intendi modificare?Inserisci il codice: ");
    string codice = Console.ReadLine();
    Console.WriteLine("Inserisci il nuovo nome del corso:");
    string nuovoNome = Console.ReadLine();
    Console.WriteLine("Inserisci la nuova descrizione:");
    string nuovaDescrizione= Console.ReadLine();

    Esito esito=bl.ModicaCorso(codice, nuovoNome, nuovaDescrizione);
   Console.WriteLine(esito.Messaggio);
        }


void InserisciCorso()
{
    // chiedo all'utente i dati per aggiungere il nuovon corso;
    Console.WriteLine("Inserisci il codice del nuovo corso:");
    string codice=Console.ReadLine();
    Console.WriteLine("Inserisci il nome del nuovo corso:");
    string nome = Console.ReadLine();
    Console.WriteLine("Inserisci la descrizione del nuovo corso:");
    string descrizione = Console.ReadLine();

    Corso nuovocorso=new Corso();
    nuovocorso.CodiceCorso=codice;
    nuovocorso.Nome=nome;
    nuovocorso.Descrizione=descrizione;
    // aggiungerlo e far visualizzare un messaggio di buon aggiunta

    Esito esito=bl.AddNuovoCorso(nuovocorso);
    Console.WriteLine(esito.Messaggio);


}

void VisualizzaCorsi()
{
   // recupera la lista dei corsi;
   

    List<Corso> listaCorsi= bl.GetAllCorsi();// deve essere popolata con i corsi


    //stampa lista e controlli che non sia vuota aggiungendo if

    if (listaCorsi.Count == 0)
    {
        Console.WriteLine("Lista vuota");

    }
    else
    {
        foreach (var item in listaCorsi)
        {
            Console.WriteLine(item);
        }
    }
}