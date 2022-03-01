using System;

namespace behaviac
{
	// Token: 0x02002689 RID: 9865
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node12 : Condition
	{
		// Token: 0x06013656 RID: 79446 RVA: 0x005C6825 File Offset: 0x005C4C25
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node12()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013657 RID: 79447 RVA: 0x005C6838 File Offset: 0x005C4C38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0AB RID: 53419
		private float opl_p0;
	}
}
