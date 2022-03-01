using System;

namespace DG.Tweening
{
	// Token: 0x020048C3 RID: 18627
	public static class DOTweenAnimationExtensions
	{
		// Token: 0x0601ACD5 RID: 109781 RVA: 0x0083E676 File Offset: 0x0083CA76
		public static bool IsSameOrSubclassOf(this Type t, Type tBase)
		{
			return t.IsSubclassOf(tBase) || t == tBase;
		}
	}
}
