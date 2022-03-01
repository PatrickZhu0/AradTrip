using System;

namespace behaviac
{
	// Token: 0x02002F16 RID: 12054
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node18 : Condition
	{
		// Token: 0x06014703 RID: 83715 RVA: 0x00625C7E File Offset: 0x0062407E
		public Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node18()
		{
			this.opl_p0 = 21611;
		}

		// Token: 0x06014704 RID: 83716 RVA: 0x00625C94 File Offset: 0x00624094
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E07B RID: 57467
		private int opl_p0;
	}
}
