using System;

namespace ZedGraph;

[Serializable]
public struct PointD(double x, double y)
{
	public double X = x;

	public double Y = y;
}
