using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Enum.Card
{
    /// <summary>
    /// Mint:carte qui ne comporte aucun défaut (emballage d'origine)
    /// NearMint : est une carte en quasi parfait état
    /// Excellent : une carte comportant des défauts visibles à l'oeil nul, à une distance de 20cm
    /// Good : une carte dont l'état général est moyen
    /// Played : est une carte abîmée sans qu'il n'y aît aucun doute
    /// Poor : très abimé 
    /// Exemple sur : <see cref=" https://www.magicbazar.fr/article/13-guide_des_etats_et_des_langues"/>
    /// </summary>
    public enum Conditions
    {
        Mint, 
        NearMint, 
        Excellent,
        Good,
        Played,
        Poor
    }
}
