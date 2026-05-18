using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class RollingPointPairList : ISerializable, IPointListEdit, IPointList, ICloneable
{
	public const int schema = 10;

	protected PointPair[] _mBuffer;

	protected int _headIdx;

	protected int _tailIdx;

	public int Capacity => _mBuffer.Length;

	public int Count
	{
		get
		{
			if (_headIdx == -1)
			{
				return 0;
			}
			if (_headIdx > _tailIdx)
			{
				return _headIdx - _tailIdx + 1;
			}
			if (_tailIdx > _headIdx)
			{
				return _mBuffer.Length - _tailIdx + _headIdx + 1;
			}
			return 1;
		}
	}

	public bool IsEmpty => _headIdx == -1;

	public PointPair this[int index]
	{
		get
		{
			if (index >= Count || index < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			index += _tailIdx;
			if (index >= _mBuffer.Length)
			{
				index -= _mBuffer.Length;
			}
			return _mBuffer[index];
		}
		set
		{
			if (index >= Count || index < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			index += _tailIdx;
			if (index >= _mBuffer.Length)
			{
				index -= _mBuffer.Length;
			}
			_mBuffer[index] = value;
		}
	}

	public RollingPointPairList(int capacity)
		: this(capacity, preLoad: false)
	{
		_mBuffer = new PointPair[capacity];
		_headIdx = (_tailIdx = -1);
	}

	public RollingPointPairList(int capacity, bool preLoad)
	{
		_mBuffer = new PointPair[capacity];
		_headIdx = (_tailIdx = -1);
		if (preLoad)
		{
			for (int i = 0; i < capacity; i++)
			{
				_mBuffer[i] = new PointPair();
			}
		}
	}

	public RollingPointPairList(IPointList rhs)
	{
		_mBuffer = new PointPair[rhs.Count];
		for (int i = 0; i < rhs.Count; i++)
		{
			_mBuffer[i] = new PointPair(rhs[i]);
		}
		_headIdx = rhs.Count - 1;
		_tailIdx = 0;
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public RollingPointPairList Clone()
	{
		return new RollingPointPairList(this);
	}

	public void Clear()
	{
		_headIdx = (_tailIdx = -1);
	}

	private int GetNextIndex()
	{
		if (_headIdx == -1)
		{
			_headIdx = (_tailIdx = 0);
		}
		else
		{
			if (++_headIdx == _mBuffer.Length)
			{
				_headIdx = 0;
			}
			if (_headIdx == _tailIdx && ++_tailIdx == _mBuffer.Length)
			{
				_tailIdx = 0;
			}
		}
		return _headIdx;
	}

	public void Add(PointPair item)
	{
		_mBuffer[GetNextIndex()] = item;
	}

	public void Add(IPointList pointList)
	{
		for (int i = 0; i < pointList.Count; i++)
		{
			Add(pointList[i]);
		}
	}

	public PointPair Remove()
	{
		if (_tailIdx == -1)
		{
			throw new InvalidOperationException("buffer is empty.");
		}
		PointPair result = _mBuffer[_tailIdx];
		if (_tailIdx == _headIdx)
		{
			_headIdx = (_tailIdx = -1);
			return result;
		}
		if (++_tailIdx == _mBuffer.Length)
		{
			_tailIdx = 0;
		}
		return result;
	}

	public void RemoveAt(int index)
	{
		int count = Count;
		if (index >= count || index < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		int num;
		for (num = index + _tailIdx; num < _tailIdx + count - 1; num++)
		{
			num = ((num < _mBuffer.Length) ? num : 0);
			int num2 = num + 1;
			num2 = ((num2 < _mBuffer.Length) ? num2 : 0);
			_mBuffer[num] = _mBuffer[num2];
		}
		Pop();
	}

	public void RemoveRange(int index, int count)
	{
		int count2 = Count;
		if (index >= count2 || index < 0 || count < 0 || count > count2)
		{
			throw new ArgumentOutOfRangeException();
		}
		for (int i = 0; i < count; i++)
		{
			RemoveAt(index);
		}
	}

	public PointPair Pop()
	{
		if (_tailIdx == -1)
		{
			throw new InvalidOperationException("buffer is empty.");
		}
		PointPair result = _mBuffer[_headIdx];
		if (_tailIdx == _headIdx)
		{
			_headIdx = (_tailIdx = -1);
			return result;
		}
		if (--_headIdx == -1)
		{
			_headIdx = _mBuffer.Length - 1;
		}
		return result;
	}

	public PointPair Peek()
	{
		if (_headIdx == -1)
		{
			throw new InvalidOperationException("buffer is empty.");
		}
		return _mBuffer[_headIdx];
	}

	public void Add(double x, double y, double z, object tag)
	{
		GetNextIndex();
		if (_mBuffer[_headIdx] == null)
		{
			_mBuffer[_headIdx] = new PointPair(x, y, z, tag);
			return;
		}
		_mBuffer[_headIdx].X = x;
		_mBuffer[_headIdx].Y = y;
		_mBuffer[_headIdx].Z = z;
		_mBuffer[_headIdx].Tag = tag;
	}

	public void Add(double x, double y)
	{
		Add(x, y, double.MaxValue, null);
	}

	public void Add(double x, double y, object tag)
	{
		Add(x, y, double.MaxValue, tag);
	}

	public void Add(double x, double y, double z)
	{
		Add(x, y, z, null);
	}

	public void Add(double[] x, double[] y)
	{
		int num = 0;
		if (x != null)
		{
			num = x.Length;
		}
		if (y != null && y.Length > num)
		{
			num = y.Length;
		}
		for (int i = 0; i < num; i++)
		{
			PointPair pointPair = new PointPair(0.0, 0.0, 0.0);
			if (x == null)
			{
				pointPair.X = (double)i + 1.0;
			}
			else if (i < x.Length)
			{
				pointPair.X = x[i];
			}
			else
			{
				pointPair.X = double.MaxValue;
			}
			if (y == null)
			{
				pointPair.Y = (double)i + 1.0;
			}
			else if (i < y.Length)
			{
				pointPair.Y = y[i];
			}
			else
			{
				pointPair.Y = double.MaxValue;
			}
			Add(pointPair);
		}
	}

	public void Add(double[] x, double[] y, double[] z)
	{
		int num = 0;
		if (x != null)
		{
			num = x.Length;
		}
		if (y != null && y.Length > num)
		{
			num = y.Length;
		}
		if (z != null && z.Length > num)
		{
			num = z.Length;
		}
		for (int i = 0; i < num; i++)
		{
			PointPair pointPair = new PointPair();
			if (x == null)
			{
				pointPair.X = (double)i + 1.0;
			}
			else if (i < x.Length)
			{
				pointPair.X = x[i];
			}
			else
			{
				pointPair.X = double.MaxValue;
			}
			if (y == null)
			{
				pointPair.Y = (double)i + 1.0;
			}
			else if (i < y.Length)
			{
				pointPair.Y = y[i];
			}
			else
			{
				pointPair.Y = double.MaxValue;
			}
			if (z == null)
			{
				pointPair.Z = (double)i + 1.0;
			}
			else if (i < z.Length)
			{
				pointPair.Z = z[i];
			}
			else
			{
				pointPair.Z = double.MaxValue;
			}
			Add(pointPair);
		}
	}

	protected RollingPointPairList(SerializationInfo info, StreamingContext context)
	{
		info.GetInt32("schema");
		_headIdx = info.GetInt32("headIdx");
		_tailIdx = info.GetInt32("tailIdx");
		_mBuffer = (PointPair[])info.GetValue("mBuffer", typeof(PointPair[]));
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("schema", 10);
		info.AddValue("headIdx", _headIdx);
		info.AddValue("tailIdx", _tailIdx);
		info.AddValue("mBuffer", _mBuffer);
	}
}
