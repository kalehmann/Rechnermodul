using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rechnermodul
{
    class GrundrechenModul: RechnermodulBibliothek.AbstractModule
    {
        public GrundrechenModul()
        {
            this.setName("Grundrechner");
            this.setDescription("");
        
            this.addFunction( new GrundrechenFunction());
        }
    }

    public partial class GrundrechenFunction: RechnermodulBibliothek.AbstractFunction
    {
        public GrundrechenFunction() : base("Grundrechner", "")
        {
        }

        public override void buildUI(RechnermodulBibliothek.UIBuilder builder)
        {
            RechnermodulBibliothek.ModifierChain mc = new RechnermodulBibliothek.ModifierChain(RechnermodulBibliothek.Modifiers.NotEmptyModifier);
            builder.addStringInput("infix", "Eingabe", mc);

        }

        public override string calculate(RechnermodulBibliothek.UserDataInterface data)
        {
            return RechnermodulBibliothek.Grundrechner.calculate(data.getStringValue("infix"));

        }

    }
}
