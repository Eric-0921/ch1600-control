using System;

namespace ZedGraph;

public interface IPointList : ICloneable
{
	PointPair this[int index] { get; }

	int Count { get; }
}
