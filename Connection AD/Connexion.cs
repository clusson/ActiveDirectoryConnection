using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection_AD
{
    class Connexion
    {
        public DirectoryEntry createDirectoryEntry()
        {
            // création de la connexion LDAP
            DirectoryEntry ldapConnection = new DirectoryEntry("LDAP://172.16.2.10", "Administrateur", "pa$$w0rd");
            //ldapConnection.Path ="LDAP://DC=lusson,DC=ad,DC=nantes,DC=epsi,DC=fr";
            ldapConnection.AuthenticationType = AuthenticationTypes.Secure;

            return ldapConnection;
        }
    }
}
