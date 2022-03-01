using System;

// Token: 0x0200420C RID: 16908
public class BeDelay : BeAction
{
	// Token: 0x0601769C RID: 95900 RVA: 0x00731BF8 File Offset: 0x0072FFF8
	public static BeDelay Create(int duration)
	{
		return new BeDelay
		{
			duration = duration
		};
	}
}
