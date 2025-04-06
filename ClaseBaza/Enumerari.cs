using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseBaza
{
    public enum Culoare
    {
        Alb = 1,
        Negru = 2,
        Rosu = 3,
        Albastru = 4,
        Verde = 5,
        Gri = 6,
        Galben = 7,
        Portocaliu = 8
    }
    
    [Flags]
    public enum Optiuni
    {
        Nimic = 0,
        AerConditionat = 1,
        Navigatie = 2,
        CutieAutomata = 4,
        ScauneIncalzite = 8,
        SenzoriParcare = 16,
        Camere360 = 32,
        JanteAliaj = 64,
        PilotAutomat = 128
    }

}
