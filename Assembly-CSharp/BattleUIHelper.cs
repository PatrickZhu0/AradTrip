using System;
using GameClient;

// Token: 0x020010ED RID: 4333
public class BattleUIHelper
{
	// Token: 0x0600A449 RID: 42057 RVA: 0x0021C84C File Offset: 0x0021AC4C
	public static IClientFrame GetBattleUIFrame<T>() where T : class, IClientFrame
	{
		IClientFrame frame = Singleton<ClientSystemManager>.instance.GetFrame(typeof(T));
		if (frame != null)
		{
			return frame;
		}
		return Singleton<ClientSystemManager>.instance.OpenFrame<T>(FrameLayer.Bottom, null, string.Empty);
	}
}
