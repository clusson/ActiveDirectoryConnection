using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection_AD
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Connexion connection = new Connexion();
                var myLdapConnexion = connection.createDirectoryEntry();
                DirectorySearcher search = new DirectorySearcher(myLdapConnexion);

  
                search.Filter = "(sn=" + "Reinold" + ")";
                SearchResult result = search.FindOne();
                if (result != null)
                {
                    // le user existe, on va lister les champs LDAP (cn, telephonenumber, etc.)
                    ResultPropertyCollection fields = result.Properties;

                    foreach (String ldapField in fields.PropertyNames)
                    {
                        // Il peut y avoir plusieurs objets dans chaque champs (ex: appartenance à des groupes)
                        foreach (Object myCollection in fields[ldapField])
                            Console.WriteLine(String.Format("{0,-20} : {1}", ldapField, myCollection.ToString()));
                    }
                }
                else
                {
                    // le user n’existe pas
                    Console.WriteLine("Utilisateur non trouvé!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception :\n\n" + e.ToString());
            }
            Console.Read();
        }






    }
}
