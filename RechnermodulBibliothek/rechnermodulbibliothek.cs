﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RechnermodulBibliothek
{
    /// <summary>
    ///  Ein Interface für die Beschreibung einer Funktion eines Modules
    /// </summary>
    public interface FunctionDescriptionInterface {
        int getId();
        string getName();
        string getDescription();
    }

    /// <summary>
    ///  Die Beschreibung einer Funktion eines Modules
    /// </summary>
    public class FunctionDescription : FunctionDescriptionInterface {

        private int id;
        private string name;
        private string description;

        public FunctionDescription(int id, string name, string description) {
            this.id = id;
            this.name = name;
            this.description = description;
        }

        public int getId() {

            return this.id;
        }


        public string getName() {

            return this.name;
        }

        public string getDescription() {

            return this.description;
        }
    }

    /// <summary>
    ///  Das Interface eines Modules
    /// </summary>
    public interface ModulInterface {
        string getFriendlyName();

        string getModuleDescription();

        FunctionDescriptionInterface[] getFunctions();


    }

 
   /// <summary>
   ///  Dieses Callback wird verwendet um eine Nutzereingabe auf ihre Richtigkeit zu überprüfen.
   ///   
   ///  Als Argument nimmt es die Nutzereingabe (string), überprüft diese und gibt eine Fehlermeldung
   ///  (string) zurück, wenn die Eingabe nicht angenommen wird, ansonsten null
   /// </summary>
   /// <param name="inputToCheck">Die Eingabe des Nutzers</param>
   /// <returns>Eine Fehlermeldung falls die Eingabe nicht angenommen wird, sonst null</returns>
    public delegate string CheckCallback(string inputToCheck);


    /// <summary>
    ///  Das Interface für den Ersteller der Benutzeroberfläche
    ///  Der Ersteller kann benutzt werden, um Eingabefelder zur Benutzeroberfläche hinzuzufügen.
    /// </summary>
    public interface UIBuilderInterface {
     
        /// <summary>
        ///  Diese Methode dient dazu, ein Eingabefeld für einen einzelnen Wert hinzuzufügen. 
        /// </summary>
        /// <param name="key">Der Schlüssel, unter welchem der eingegebene Wert später abgerufen werden kann</param>
        /// <param name="description">Die Beschreibung für das Eingabefeld, welche dem Nutzer angezeigt wird</param>
        /// <param name="validator">Ein Callback welches entscheidet, ob die Eingabe angenommen wird</param>
        void addStringInput(string key, string description, CheckCallback validator);

        /// <summary>
        ///  Diese Methode dient dazu, ein Eingabefeld für mehrere Werte hinzuzufügen
        /// </summary>
        /// <param name="key">Der Schlüssel, unter welchem die eingegebenen Weret später abgerufen werden können</param>
        /// <param name="description">Die Beschreibung für das Eingabefeld, welche dem Nutzer angezeigt wird</param>
        /// <param name="validator">Ein Callback, welches für jeden einzelnen eingebenen Wert entscheidet, ob er angenommen wird</param>
        void addStringArrayInput(string key, string description, CheckCallback validator);
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
    ///  Diese Klasse repräsentiert eine Funktion eines Moduls
    /// </summary>
    public abstract class AbstractFunction {
        /// <summary>
        ///  Diese Methode dient dazu, die Benutzeroberfläche für die Eingabe der Daten, welche die
        ///  Funktion benötigt vorzubereiten
        /// </summary>
        /// <param name="builder">Der Ersteller für die Benutzeroberfläche</param>
        public abstract void buildUI(UIBuilderInterface builder);

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
    public abstract class AbstractModule : ModulInterface {

        private string name;
        private string description;
        private List<AbstractFunction> functions = new List<AbstractFunction>();
        private List<FunctionDescription> functionDescs = new List<FunctionDescription>();

        string RechnermodulBibliothek.ModulInterface.getFriendlyName()
        {
            return this.name;
        }

        string RechnermodulBibliothek.ModulInterface.getModuleDescription()
        {
            return this.description;
        }

        FunctionDescriptionInterface[] RechnermodulBibliothek.ModulInterface.getFunctions()
        {
            return this.functionDescs.ToArray();
        }

        /// <summary>
        ///  Diese Methode setzt den Namen des Moduls
        /// </summary>
        /// <param name="name">Der Name des Moduls</param>
        protected void setName(string name)
        {
            this.name = name;
        }

        /// <summary>
        ///  Diese Methode setzt die BEschreibung des Moduls
        /// </summary>
        /// <param name="description">Die Beschreibung des Moduls</param>
        protected void setDescription(string description) {
            this.description = description;
        }

        /// <summary>
        ///  Diese Methode fügt eine Funktion zu dem Modul hinzu
        /// </summary>
        /// <param name="name">Der Name der Funktion</param>
        /// <param name="description">Die Beschreibung der Funktion</param>
        /// <param name="function">Die Funktion selbst</param>
        protected void addFunction(string name, string description, AbstractFunction function) {
            this.functions.Add(function);

            FunctionDescription desc = new FunctionDescription(this.functionDescs.Count, name, description);
            this.functionDescs.Add(desc);
        }
    }
}