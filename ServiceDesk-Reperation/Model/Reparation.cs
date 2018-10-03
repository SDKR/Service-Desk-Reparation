using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk_Reperation.Model
{
    class Reparation
    {
        private string _navn;

        public string Navn
        {
            get { return _navn; }
            set { _navn = value; }
        }

        private string _adresse;

        public string Adresse
        {
            get { return _adresse; }
            set { _adresse = value; }
        }

        private string _postnr;

        public string Postnr
        {
            get { return _postnr; }
            set { _postnr = value; }
        }

        private string _telefon;

        public string Telefon
        {
            get { return _telefon; }
            set { _telefon = value; }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _beskrivelse;

        public string Beskrivelse
        {
            get { return _beskrivelse; }
            set { _beskrivelse = value; }
        }

        private string _producent;

        public string Producent
        {
            get { return _producent; }
            set { _producent = value; }
        }

        private string _model;

        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        private string _serieNr;

        public string SerieNr
        {
            get { return _serieNr; }
            set { _serieNr = value; }
        }

        private string _os;

        public string OS
        {
            get { return _os; }
            set { _os = value; }
        }

        private string _cpu;

        public string CPU
        {
            get { return _cpu; }
            set { _cpu = value; }
        }

        private string _ram;

        public string RAM
        {
            get { return _ram; }
            set { _ram = value; }
        }

        private string _hdd;

        public string HDD
        {
            get { return _hdd; }
            set { _hdd = value; }
        }

        private string _status;

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}
