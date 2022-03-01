using System;

namespace behaviac
{
	// Token: 0x0200286B RID: 10347
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Action_node2 : Condition
	{
		// Token: 0x06013A13 RID: 80403 RVA: 0x005DC52A File Offset: 0x005DA92A
		public Condition_bt_AutoFight_AutoFight_Swordman_Action_node2()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013A14 RID: 80404 RVA: 0x005DC540 File Offset: 0x005DA940
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D46B RID: 54379
		private float opl_p0;
	}
}
