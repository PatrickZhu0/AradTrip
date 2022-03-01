using System;

namespace behaviac
{
	// Token: 0x020029E4 RID: 10724
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_BOSS_BOSS20_4_Action_node4 : Condition
	{
		// Token: 0x06013CFB RID: 81147 RVA: 0x005EE093 File Offset: 0x005EC493
		public Condition_bt_BOSS_BOSS20_4_Action_node4()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06013CFC RID: 81148 RVA: 0x005EE0A8 File Offset: 0x005EC4A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D770 RID: 55152
		private float opl_p0;
	}
}
