using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class Link : ISerializable, ICloneable
{
	public const int schema = 10;

	internal string _title;

	internal string _url;

	internal string _target;

	internal bool _isEnabled;

	public object Tag;

	public string Title
	{
		get
		{
			return _title;
		}
		set
		{
			_title = value;
		}
	}

	public string Url
	{
		get
		{
			return _url;
		}
		set
		{
			_url = value;
		}
	}

	public string Target
	{
		get
		{
			if (!(_target != string.Empty))
			{
				return "_self";
			}
			return _target;
		}
		set
		{
			_target = value;
		}
	}

	public bool IsEnabled
	{
		get
		{
			return _isEnabled;
		}
		set
		{
			_isEnabled = value;
		}
	}

	public bool IsActive
	{
		get
		{
			if (_isEnabled)
			{
				if (_url == null)
				{
					return _title != null;
				}
				return true;
			}
			return false;
		}
	}

	public Link()
	{
		_title = string.Empty;
		_url = string.Empty;
		_target = string.Empty;
		Tag = null;
		_isEnabled = false;
	}

	public Link(string title, string url, string target)
	{
		_title = title;
		_url = url;
		_target = target;
		Tag = null;
		_isEnabled = true;
	}

	public Link(Link rhs)
	{
		_title = rhs._title;
		_url = rhs._url;
		_target = rhs._target;
		_isEnabled = false;
		if (rhs.Tag is ICloneable)
		{
			Tag = ((ICloneable)rhs.Tag).Clone();
		}
		else
		{
			Tag = rhs.Tag;
		}
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public Link Clone()
	{
		return new Link(this);
	}

	public virtual string MakeCurveItemUrl(GraphPane pane, CurveItem curve, int index)
	{
		string url = _url;
		url = ((url.IndexOf('?') < 0) ? (url + "?index=" + index) : (url + "&index=" + index));
		Axis xAxis = curve.GetXAxis(pane);
		if (xAxis.Type == AxisType.Text && index >= 0 && xAxis.Scale.TextLabels != null && index <= xAxis.Scale.TextLabels.Length)
		{
			url = url + "&xtext=" + xAxis.Scale.TextLabels[index];
		}
		Axis yAxis = curve.GetYAxis(pane);
		if (yAxis != null && yAxis.Type == AxisType.Text && index >= 0 && yAxis.Scale.TextLabels != null && index <= yAxis.Scale.TextLabels.Length)
		{
			url = url + "&ytext=" + yAxis.Scale.TextLabels[index];
		}
		return url;
	}

	protected Link(SerializationInfo info, StreamingContext context)
	{
		info.GetInt32("schema");
		_title = info.GetString("title");
		_url = info.GetString("url");
		_target = info.GetString("target");
		_isEnabled = info.GetBoolean("isEnabled");
		Tag = info.GetValue("Tag", typeof(object));
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("schema", 10);
		info.AddValue("title", _title);
		info.AddValue("url", _url);
		info.AddValue("target", _target);
		info.AddValue("isEnabled", _isEnabled);
		info.AddValue("Tag", Tag);
	}
}
