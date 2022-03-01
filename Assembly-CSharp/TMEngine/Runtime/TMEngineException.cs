using System;
using System.Runtime.Serialization;

namespace TMEngine.Runtime
{
	// Token: 0x02004707 RID: 18183
	[Serializable]
	public class TMEngineException : Exception
	{
		// Token: 0x0601A150 RID: 106832 RVA: 0x0081EDA6 File Offset: 0x0081D1A6
		public TMEngineException()
		{
		}

		// Token: 0x0601A151 RID: 106833 RVA: 0x0081EDAE File Offset: 0x0081D1AE
		public TMEngineException(string message) : base(message)
		{
		}

		// Token: 0x0601A152 RID: 106834 RVA: 0x0081EDB7 File Offset: 0x0081D1B7
		public TMEngineException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x0601A153 RID: 106835 RVA: 0x0081EDC1 File Offset: 0x0081D1C1
		public TMEngineException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
