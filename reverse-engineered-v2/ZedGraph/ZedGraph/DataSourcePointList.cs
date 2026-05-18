using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace ZedGraph;

[Serializable]
public class DataSourcePointList : IPointList, ICloneable
{
	private BindingSource _bindingSource;

	private string _xDataMember;

	private string _yDataMember;

	private string _zDataMember;

	private string _tagDataMember;

	public PointPair this[int index]
	{
		get
		{
			if (index < 0 || index >= _bindingSource.Count)
			{
				throw new ArgumentOutOfRangeException("Error: Index out of range");
			}
			object row = _bindingSource[index];
			double x = GetDouble(row, _xDataMember, index);
			double y = GetDouble(row, _yDataMember, index);
			double z = GetDouble(row, _zDataMember, index);
			object tag = GetObject(row, _tagDataMember);
			PointPair pointPair = new PointPair(x, y, z);
			pointPair.Tag = tag;
			return pointPair;
		}
	}

	public int Count
	{
		get
		{
			if (_bindingSource != null)
			{
				return _bindingSource.Count;
			}
			return 0;
		}
	}

	public BindingSource BindingSource => _bindingSource;

	public object DataSource
	{
		get
		{
			return _bindingSource.DataSource;
		}
		set
		{
			_bindingSource.DataSource = value;
		}
	}

	public string XDataMember
	{
		get
		{
			return _xDataMember;
		}
		set
		{
			_xDataMember = value;
		}
	}

	public string YDataMember
	{
		get
		{
			return _yDataMember;
		}
		set
		{
			_yDataMember = value;
		}
	}

	public string ZDataMember
	{
		get
		{
			return _zDataMember;
		}
		set
		{
			_zDataMember = value;
		}
	}

	public string TagDataMember
	{
		get
		{
			return _tagDataMember;
		}
		set
		{
			_tagDataMember = value;
		}
	}

	public DataSourcePointList()
	{
		_bindingSource = new BindingSource();
		_xDataMember = string.Empty;
		_yDataMember = string.Empty;
		_zDataMember = string.Empty;
		_tagDataMember = string.Empty;
	}

	public DataSourcePointList(DataSourcePointList rhs)
		: this()
	{
		_bindingSource.DataSource = rhs._bindingSource.DataSource;
		if (rhs._xDataMember != null)
		{
			_xDataMember = (string)rhs._xDataMember.Clone();
		}
		if (rhs._yDataMember != null)
		{
			_yDataMember = (string)rhs._yDataMember.Clone();
		}
		if (rhs._zDataMember != null)
		{
			_zDataMember = (string)rhs._zDataMember.Clone();
		}
		if (rhs._tagDataMember != null)
		{
			_tagDataMember = (string)rhs._tagDataMember.Clone();
		}
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public DataSourcePointList Clone()
	{
		return new DataSourcePointList(this);
	}

	private double GetDouble(object row, string dataMember, int index)
	{
		if (dataMember == null || dataMember == string.Empty)
		{
			return index + 1;
		}
		DataRowView dataRowView = row as DataRowView;
		PropertyInfo propertyInfo = null;
		if (dataRowView == null)
		{
			propertyInfo = row.GetType().GetProperty(dataMember);
		}
		object obj = null;
		if (propertyInfo != null)
		{
			obj = propertyInfo.GetValue(row, null);
		}
		else if (dataRowView != null)
		{
			obj = dataRowView[dataMember];
		}
		else if (propertyInfo == null)
		{
			throw new Exception("Can't find DataMember '" + dataMember + "' in DataSource");
		}
		if (obj == null || obj == DBNull.Value)
		{
			return double.MaxValue;
		}
		if (obj.GetType() == typeof(DateTime))
		{
			return ((DateTime)obj).ToOADate();
		}
		if (obj.GetType() == typeof(string))
		{
			return index + 1;
		}
		return Convert.ToDouble(obj);
	}

	private object GetObject(object row, string dataMember)
	{
		if (dataMember == null || dataMember == string.Empty)
		{
			return null;
		}
		PropertyInfo property = row.GetType().GetProperty(dataMember);
		DataRowView dataRowView = row as DataRowView;
		object obj = null;
		if (property != null)
		{
			obj = property.GetValue(row, null);
		}
		else if (dataRowView != null)
		{
			obj = dataRowView[dataMember];
		}
		if (obj == null)
		{
			throw new Exception("Can't find DataMember '" + dataMember + "' in DataSource");
		}
		return obj;
	}
}
