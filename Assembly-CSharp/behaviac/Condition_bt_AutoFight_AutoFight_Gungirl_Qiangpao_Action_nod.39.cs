using System;

namespace behaviac
{
	// Token: 0x02002546 RID: 9542
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node78 : Condition
	{
		// Token: 0x060133D5 RID: 78805 RVA: 0x005B713B File Offset: 0x005B553B
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node78()
		{
			this.opl_p0 = 2506;
		}

		// Token: 0x060133D6 RID: 78806 RVA: 0x005B7150 File Offset: 0x005B5550
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDFC RID: 52732
		private int opl_p0;
	}
}
