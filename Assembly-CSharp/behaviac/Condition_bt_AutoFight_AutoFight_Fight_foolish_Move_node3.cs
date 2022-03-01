using System;

namespace behaviac
{
	// Token: 0x02001F72 RID: 8050
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_foolish_Move_node3 : Condition
	{
		// Token: 0x06012885 RID: 75909 RVA: 0x0056D6AD File Offset: 0x0056BAAD
		public Condition_bt_AutoFight_AutoFight_Fight_foolish_Move_node3()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06012886 RID: 75910 RVA: 0x0056D6C0 File Offset: 0x0056BAC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C27C RID: 49788
		private float opl_p0;
	}
}
