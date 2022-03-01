using System;
using System.IO;
using SharpJson;

namespace Spine
{
	// Token: 0x020049C6 RID: 18886
	public static class Json
	{
		// Token: 0x0601B30A RID: 111370 RVA: 0x0085A880 File Offset: 0x00858C80
		public static object Deserialize(TextReader text)
		{
			return new JsonDecoder
			{
				parseNumbersAsFloat = true
			}.Decode(text.ReadToEnd());
		}
	}
}
