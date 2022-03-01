using System;

namespace behaviac
{
	// Token: 0x02002C13 RID: 11283
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node122 : Condition
	{
		// Token: 0x06014125 RID: 82213 RVA: 0x00606007 File Offset: 0x00604407
		public Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node122()
		{
			this.opl_p0 = 21833;
		}

		// Token: 0x06014126 RID: 82214 RVA: 0x0060601C File Offset: 0x0060441C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DAFD RID: 56061
		private int opl_p0;
	}
}
