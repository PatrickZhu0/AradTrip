using System;

namespace behaviac
{
	// Token: 0x02002E5F RID: 11871
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node247 : Condition
	{
		// Token: 0x0601459B RID: 83355 RVA: 0x0061BA31 File Offset: 0x00619E31
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node247()
		{
			this.opl_p0 = 21639;
		}

		// Token: 0x0601459C RID: 83356 RVA: 0x0061BA44 File Offset: 0x00619E44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF29 RID: 57129
		private int opl_p0;
	}
}
