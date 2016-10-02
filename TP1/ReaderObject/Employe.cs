using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderObject
{
    class Employe
    {
        public Int16 Numemp { get; set; }
        public String Nomemp { get; set; }
        public String Prenomemp { get; set; }
        public String Poste { get; set; }
        public Single Salaire { get; set; }
        public Single? Prime { get; set; } // nullable
        public String CodeProjet { get; set; }
        public Int16? Superieur { get; set; } // nullable
        /*
        public Employe(short numemp, string nomemp, string prenomemp, string poste, float salaire, float? prime, string codeProjet, short? superieur)
        {
            Numemp = numemp;
            Nomemp = nomemp;
            Prenomemp = prenomemp;
            Poste = poste;
            Salaire = salaire;
            Prime = prime;
            CodeProjet = codeProjet;
            Superieur = superieur;
        }
        */
        public Employe(short numemp, string nomemp, string prenomemp, string poste, float salaire, float? prime)
        {
            Numemp = numemp;
            Nomemp = nomemp;
            Prenomemp = prenomemp;
            Poste = poste;
            Salaire = salaire;
            Prime = prime;
        }

        public override string ToString()
        {
            return Numemp + " - " + Nomemp + " - " + Prenomemp + " - " + Poste + " - " + Salaire + " - " + Prime + " - " + CodeProjet + " - " + Superieur;
        }
    }

}
