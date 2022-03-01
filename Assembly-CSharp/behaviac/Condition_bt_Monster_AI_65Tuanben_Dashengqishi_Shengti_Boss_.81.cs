using System;

namespace behaviac
{
	// Token: 0x02002E57 RID: 11863
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node196 : Condition
	{
		// Token: 0x0601458B RID: 83339 RVA: 0x0061B7A5 File Offset: 0x00619BA5
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node196()
		{
			this.opl_p0 = 21625;
		}

		// Token: 0x0601458C RID: 83340 RVA: 0x0061B7B8 File Offset: 0x00619BB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF20 RID: 57120
		private int opl_p0;
	}
}
