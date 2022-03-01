using System;
using System.Text;
using Network;

namespace Protocol
{
	// Token: 0x02000B72 RID: 2930
	public static class MsgTools
	{
		// Token: 0x06007C97 RID: 31895 RVA: 0x001635BC File Offset: 0x001619BC
		public static void decode(this IProtocolStream stream, byte[] buffer)
		{
			int num = 0;
			stream.decode(buffer, ref num);
		}

		// Token: 0x06007C98 RID: 31896 RVA: 0x001635D4 File Offset: 0x001619D4
		public static T decode<T>(this MsgDATA msg) where T : IProtocolStream, new()
		{
			T t = Activator.CreateInstance<T>();
			t.decode(msg.bytes);
			return t;
		}

		// Token: 0x06007C99 RID: 31897 RVA: 0x001635FC File Offset: 0x001619FC
		public static void encode(this IProtocolStream stream, byte[] buffer)
		{
			int num = 0;
			stream.encode(buffer, ref num);
		}

		// Token: 0x06007C9A RID: 31898 RVA: 0x00163614 File Offset: 0x00161A14
		public static string toString(this SockAddr addr)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder = stringBuilder.AppendFormat("Server IP:{0},Port:{1}", addr.ip, addr.port);
			return stringBuilder.ToString();
		}
	}
}
