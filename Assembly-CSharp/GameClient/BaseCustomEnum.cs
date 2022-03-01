using System;

namespace GameClient
{
	// Token: 0x02000E32 RID: 3634
	public class BaseCustomEnum<T> : ICustomEnumResult<T> where T : IComparable
	{
		// Token: 0x06009122 RID: 37154 RVA: 0x00047DF2 File Offset: 0x000461F2
		public T GetResult()
		{
			return this.mResult;
		}

		// Token: 0x06009123 RID: 37155 RVA: 0x00047DFA File Offset: 0x000461FA
		public void SetResult(T res)
		{
			this.mResult = res;
		}

		// Token: 0x04004874 RID: 18548
		protected T mResult = default(T);
	}
}
