using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace MyUtilities
{
    [Serializable]
    public class Car : ISerializable
    {
        private readonly string _make;
        private readonly string _model;
        private readonly int _year;
        private Owner _owner = null; //this is variable and can change

        private Car() {} //default ctor not valid - we want to enforce initializing our data
        public Car( string make, string model, int year )
        {
            _make = make;
            _model = model;
            _year = year;
        }

        public Owner Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }
        public string Make
        {
            get { return _make; }
        }
        public string Model
        {
            get { return _model; }
        }
        public int Year
        {
            get { return _year; }
        }

        //note: this is private to control access; the serializer can still access this constructor
        private Car( SerializationInfo info, StreamingContext ctxt )
        {
            this._make = info.GetString("Make");
            this._model = info.GetString("Model");
            this._year = info.GetInt32("Year");
            this._owner = (Owner)info.GetValue("Owner", typeof(Owner));
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public void GetObjectData( SerializationInfo info, StreamingContext ctxt )
        {
            info.AddValue("Make", this._make);
            info.AddValue("Model", this._model);
            info.AddValue("Year", this._year);
            info.AddValue("Owner", this._owner, typeof(Owner));
        }
    }

}
