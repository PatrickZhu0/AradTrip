using System;

namespace behaviac
{
	// Token: 0x0200292F RID: 10543
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node2 : Condition
	{
		// Token: 0x06013B94 RID: 80788 RVA: 0x005E4D8D File Offset: 0x005E318D
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node2()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06013B95 RID: 80789 RVA: 0x005E4DA0 File Offset: 0x005E31A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5FB RID: 54779
		private float opl_p0;
	}
}
