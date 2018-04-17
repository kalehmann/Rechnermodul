using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RechnermodulBibliothek
{
    [Serializable()]
    public class NutzerEingabeFehler : Exception
    {
        public NutzerEingabeFehler() : base() { }
        public NutzerEingabeFehler(string message) : base(message) {  }
    }

 
   /// <summary>
   ///  Dieses Callback wird verwendet um eine Nutzereingabe auf ihre Richtigkeit zu überprüfen.
   ///   
   ///  Als Argument nimmt es die Nutzereingabe (string), überprüft diese und gibt eine Fehlermeldung
   ///  (string) zurück, wenn die Eingabe nicht angenommen wird, ansonsten null
   /// </summary>
   /// <param name="input">Die Eingabe des Nutzers</param>
   /// <returns>Eine Fehlermeldung falls die Eingabe nicht angenommen wird, sonst null</returns>
    public delegate string Validator(string input);


    /// <summary>
    ///  Das Interface für den Ersteller der Benutzeroberfläche
    ///  Der Ersteller kann benutzt werden, um Eingabefelder zur Benutzeroberfläche hinzuzufügen.
    /// </summary>
    public class UIBuilder {

        private List<UIElement> elements = new List<UIElement>();


        /// <summary>
        ///  Diese Methode dient dazu, ein Eingabefeld für einen einzelnen Wert hinzuzufügen. 
        /// </summary>
        /// <param name="key">Der Schlüssel, unter welchem der eingegebene Wert später abgerufen werden kann</param>
        /// <param name="description">Die Beschreibung für das Eingabefeld, welche dem Nutzer angezeigt wird</param>
        /// <param name="mc">Die Modifier, welche auf die Eingabe angewandt werden sollen</param>
        public void addStringInput(string key, string description, Validator v)
        {
            UIElement element = new UIElement(UIElement.TYPE_SINGLE, key, description, v);

            this.elements.Add(element);
        }

        /// <summary>
        ///  Diese Methode dient dazu, ein Eingabefeld für mehrere Werte hinzuzufügen
        /// </summary>
        /// <param name="key">Der Schlüssel, unter welchem die eingegebenen Weret später abgerufen werden können</param>
        /// <param name="description">Die Beschreibung für das Eingabefeld, welche dem Nutzer angezeigt wird</param>
        /// <param name="validator">Die Modifier, welche auf jeden eiinzelnen Wert angewandt werden sollen</param>
        public void addStringArrayInput(string key, string description, Validator v)
        {
            UIElement element = new UIElement(UIElement.TYPE_ARRAY, key, description, v);

            this.elements.Add(element);
        }

        public UIElement[] getUIElements()
        {
            return elements.ToArray<UIElement>();
        }
    }

    public class UIElement
    {
        public const int TYPE_SINGLE = 0;
        public const int TYPE_ARRAY = 1;

        private int type;
        private string key;
        private string description;
        private Validator v;

        public UIElement(int type, string key, string description, Validator v)
        {
            this.type = type;
            this.key = key;
            this.description = description;
            this.v = v;
        }

        public int getType()
        {
            return this.type;
        }

        public string getKey()
        {
            return this.key;
        }

        public string getDescription()
        {
            return this.description;
        }
    }

    /// <summary>
    ///  Dieses Interface kann dazu genutzt werden, Nutzereingaben auszulesen
    /// </summary>
    public interface UserDataInterface {
        /// <summary>
        ///  Diese Methode dient dazu, einen einzelnen Wert, welchen der Nutzer eingegeben hat auszulesen
        /// </summary>
        /// <param name="key">Der Schlüssel, unter welchem der Wert gespeichert wurde</param>
        /// <returns>Der vom Nutzer eingegebene Wert</returns>
        string getStringValue(string key);

        /// <summary>
        ///  Diese Methode dient dazu, eine Sammlung von Werten, welche der Nutzer eingegeben hat auszulesen.
        /// </summary>
        /// <param name="key">Der Schlüssel, unter welchem die Werte gespeichert wurden</param>
        /// <returns>Eine List mit den vom Nutzer eingegebenen Werten</returns>
        string[] getStringArray(string key);
    }

    /// <summary>
    ///  Dieses Interface repräsentiert eine Funktion eines Moduls
    /// </summary>
    public abstract class AbstractFunction {
        private string name;
        private string description;

        public AbstractFunction(string name, string description)
        {
            this.name = name;
            this.description = description;
        }


        public string getName()
        {

            return this.name;
        }

        public string getDescription()
        {

            return this.description;
        }
        /// <summary>
        ///  Diese Methode dient dazu, die Benutzeroberfläche für die Eingabe der Daten, welche die
        ///  Funktion benötigt vorzubereiten
        /// </summary>
        /// <param name="builder">Der Ersteller für die Benutzeroberfläche</param>
        public abstract void buildUI(UIBuilder builder);

        /// <summary>
        ///  Diese Methode verarbeitet die vom Nutzer eingegebenen Daten und gibt das Ergebnis als Zeichenkette zurück
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public abstract string calculate(UserDataInterface data);
    }

    /// <summary>
    ///  Diese Klasse repräsentiert ein Modul des Rechners mit verschiedenen Funktionen
    /// </summary>
    public abstract class AbstractModule {

        private string module_name;
        private string module_description;
        private List<AbstractFunction> module_functions = new List<AbstractFunction>();

        public string name
        {
            get { return this.module_name; }
        }

        public string description
        {
            get { return this.description; }
        }

        public AbstractFunction[] functions
        {
           get { return this.module_functions.ToArray<AbstractFunction>(); }
        }

        /// <summary>
        ///  Diese Methode setzt den Namen des Moduls
        /// </summary>
        /// <param name="name">Der Name des Moduls</param>
        protected void setName(string name)
        {
            this.module_name = name;
        }

        /// <summary>
        ///  Diese Methode setzt die BEschreibung des Moduls
        /// </summary>
        /// <param name="description">Die Beschreibung des Moduls</param>
        protected void setDescription(string description) {
            this.module_description = description;
        }

        /// <summary>
        ///  Diese Methode fügt eine Funktion zu dem Modul hinzu
        /// </summary>
        /// <param name="name">Der Name der Funktion</param>
        /// <param name="description">Die Beschreibung der Funktion</param>
        /// <param name="function">Die Funktion selbst</param>
        protected void addFunction(AbstractFunction function) {
            this.module_functions.Add(function);
        }

        public void run()
        {
            FunktionsSelektor fnSelektor = new FunktionsSelektor();
            fnSelektor.set_funktionen(this);
            fnSelektor.ShowDialog();

            AbstractFunction f = fnSelektor.selected_function;

            if (f == null)
            {
                return;
            }

            UIBuilder b = new UIBuilder();

            f.buildUI(b);



        }
    }
}
