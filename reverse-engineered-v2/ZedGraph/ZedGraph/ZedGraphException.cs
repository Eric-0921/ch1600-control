using System;
using System.Runtime.Serialization;

namespace ZedGraph;

public class ZedGraphException : ApplicationException
{
	protected ZedGraphException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public ZedGraphException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public ZedGraphException(string message)
		: base(message)
	{
	}

	public ZedGraphException()
	{
	}
}
