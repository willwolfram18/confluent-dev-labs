// ------------------------------------------------------------------------------
// <auto-generated>
//    Generated by avrogen, version 1.7.7.5
//    Changes to this file may cause incorrect behavior and will be lost if code
//    is regenerated
// </auto-generated>
// ------------------------------------------------------------------------------
namespace solution.model
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using global::Avro;
	using global::Avro.Specific;
	
	public partial class PositionValue : ISpecificRecord
	{
		public static Schema _SCHEMA = Schema.Parse(@"{""type"":""record"",""name"":""PositionValue"",""namespace"":""solution.model"",""fields"":[{""name"":""desi"",""type"":""string""},{""name"":""dir"",""type"":""string""},{""name"":""oper"",""type"":""int""},{""name"":""veh"",""type"":""int""},{""name"":""tst"",""type"":""string""},{""name"":""tsi"",""type"":""long""},{""name"":""spd"",""type"":[""null"",""double""]},{""name"":""hdg"",""type"":[""null"",""int""]},{""name"":""lat"",""type"":[""null"",""double""]},{""name"":""long"",""type"":[""null"",""double""]},{""name"":""acc"",""type"":[""null"",""double""]},{""name"":""dl"",""type"":""int""},{""name"":""odo"",""type"":""int""},{""name"":""drst"",""type"":""int""},{""name"":""oday"",""type"":""string""},{""name"":""jrn"",""type"":""int""},{""name"":""line"",""type"":""int""},{""name"":""start"",""type"":""string""},{""name"":""loc"",""type"":""string""},{""name"":""stop"",""type"":[""null"",""string""]},{""name"":""route"",""type"":""string""},{""name"":""occu"",""type"":""int""},{""name"":""seq"",""type"":""int""}]}");
		private string _desi;
		private string _dir;
		private int _oper;
		private int _veh;
		private string _tst;
		private long _tsi;
		private System.Nullable<double> _spd;
		private System.Nullable<int> _hdg;
		private System.Nullable<double> _lat;
		private System.Nullable<double> _long;
		private System.Nullable<double> _acc;
		private int _dl;
		private int _odo;
		private int _drst;
		private string _oday;
		private int _jrn;
		private int _line;
		private string _start;
		private string _loc;
		private string _stop;
		private string _route;
		private int _occu;
		private int _seq;
		public virtual Schema Schema
		{
			get
			{
				return PositionValue._SCHEMA;
			}
		}
		public string desi
		{
			get
			{
				return this._desi;
			}
			set
			{
				this._desi = value;
			}
		}
		public string dir
		{
			get
			{
				return this._dir;
			}
			set
			{
				this._dir = value;
			}
		}
		public int oper
		{
			get
			{
				return this._oper;
			}
			set
			{
				this._oper = value;
			}
		}
		public int veh
		{
			get
			{
				return this._veh;
			}
			set
			{
				this._veh = value;
			}
		}
		public string tst
		{
			get
			{
				return this._tst;
			}
			set
			{
				this._tst = value;
			}
		}
		public long tsi
		{
			get
			{
				return this._tsi;
			}
			set
			{
				this._tsi = value;
			}
		}
		public System.Nullable<double> spd
		{
			get
			{
				return this._spd;
			}
			set
			{
				this._spd = value;
			}
		}
		public System.Nullable<int> hdg
		{
			get
			{
				return this._hdg;
			}
			set
			{
				this._hdg = value;
			}
		}
		public System.Nullable<double> lat
		{
			get
			{
				return this._lat;
			}
			set
			{
				this._lat = value;
			}
		}
		public System.Nullable<double> @long
		{
			get
			{
				return this._long;
			}
			set
			{
				this._long = value;
			}
		}
		public System.Nullable<double> acc
		{
			get
			{
				return this._acc;
			}
			set
			{
				this._acc = value;
			}
		}
		public int dl
		{
			get
			{
				return this._dl;
			}
			set
			{
				this._dl = value;
			}
		}
		public int odo
		{
			get
			{
				return this._odo;
			}
			set
			{
				this._odo = value;
			}
		}
		public int drst
		{
			get
			{
				return this._drst;
			}
			set
			{
				this._drst = value;
			}
		}
		public string oday
		{
			get
			{
				return this._oday;
			}
			set
			{
				this._oday = value;
			}
		}
		public int jrn
		{
			get
			{
				return this._jrn;
			}
			set
			{
				this._jrn = value;
			}
		}
		public int line
		{
			get
			{
				return this._line;
			}
			set
			{
				this._line = value;
			}
		}
		public string start
		{
			get
			{
				return this._start;
			}
			set
			{
				this._start = value;
			}
		}
		public string loc
		{
			get
			{
				return this._loc;
			}
			set
			{
				this._loc = value;
			}
		}
		public string stop
		{
			get
			{
				return this._stop;
			}
			set
			{
				this._stop = value;
			}
		}
		public string route
		{
			get
			{
				return this._route;
			}
			set
			{
				this._route = value;
			}
		}
		public int occu
		{
			get
			{
				return this._occu;
			}
			set
			{
				this._occu = value;
			}
		}
		public int seq
		{
			get
			{
				return this._seq;
			}
			set
			{
				this._seq = value;
			}
		}
		public virtual object Get(int fieldPos)
		{
			switch (fieldPos)
			{
			case 0: return this.desi;
			case 1: return this.dir;
			case 2: return this.oper;
			case 3: return this.veh;
			case 4: return this.tst;
			case 5: return this.tsi;
			case 6: return this.spd;
			case 7: return this.hdg;
			case 8: return this.lat;
			case 9: return this.@long;
			case 10: return this.acc;
			case 11: return this.dl;
			case 12: return this.odo;
			case 13: return this.drst;
			case 14: return this.oday;
			case 15: return this.jrn;
			case 16: return this.line;
			case 17: return this.start;
			case 18: return this.loc;
			case 19: return this.stop;
			case 20: return this.route;
			case 21: return this.occu;
			case 22: return this.seq;
			default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Get()");
			};
		}
		public virtual void Put(int fieldPos, object fieldValue)
		{
			switch (fieldPos)
			{
			case 0: this.desi = (System.String)fieldValue; break;
			case 1: this.dir = (System.String)fieldValue; break;
			case 2: this.oper = (System.Int32)fieldValue; break;
			case 3: this.veh = (System.Int32)fieldValue; break;
			case 4: this.tst = (System.String)fieldValue; break;
			case 5: this.tsi = (System.Int64)fieldValue; break;
			case 6: this.spd = (System.Nullable<double>)fieldValue; break;
			case 7: this.hdg = (System.Nullable<int>)fieldValue; break;
			case 8: this.lat = (System.Nullable<double>)fieldValue; break;
			case 9: this.@long = (System.Nullable<double>)fieldValue; break;
			case 10: this.acc = (System.Nullable<double>)fieldValue; break;
			case 11: this.dl = (System.Int32)fieldValue; break;
			case 12: this.odo = (System.Int32)fieldValue; break;
			case 13: this.drst = (System.Int32)fieldValue; break;
			case 14: this.oday = (System.String)fieldValue; break;
			case 15: this.jrn = (System.Int32)fieldValue; break;
			case 16: this.line = (System.Int32)fieldValue; break;
			case 17: this.start = (System.String)fieldValue; break;
			case 18: this.loc = (System.String)fieldValue; break;
			case 19: this.stop = (System.String)fieldValue; break;
			case 20: this.route = (System.String)fieldValue; break;
			case 21: this.occu = (System.Int32)fieldValue; break;
			case 22: this.seq = (System.Int32)fieldValue; break;
			default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Put()");
			};
		}
	}
}
