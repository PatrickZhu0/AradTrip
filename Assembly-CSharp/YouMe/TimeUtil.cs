using System;

namespace YouMe
{
	// Token: 0x02004AC3 RID: 19139
	public static class TimeUtil
	{
		// Token: 0x0601BC6D RID: 113773 RVA: 0x008837A8 File Offset: 0x00881BA8
		public static uint ConvertToTimestamp(DateTime value)
		{
			return Convert.ToUInt32((value.ToUniversalTime() - TimeUtil.Epoch).TotalSeconds);
		}

		// Token: 0x040135D0 RID: 79312
		private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
	}
}
