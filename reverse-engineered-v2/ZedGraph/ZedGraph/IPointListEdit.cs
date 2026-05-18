using System;

namespace ZedGraph;

public interface IPointListEdit : IPointList, ICloneable
{
	new PointPair this[int index] { get; set; }

	void Add(PointPair point);

	void Add(double x, double y);

	void RemoveAt(int index);

	void Clear();
}
