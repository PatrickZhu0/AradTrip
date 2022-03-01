using System;

namespace behaviac
{
	// Token: 0x02002F0D RID: 12045
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node11 : Condition
	{
		// Token: 0x060146F1 RID: 83697 RVA: 0x00625866 File Offset: 0x00623C66
		public Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node11()
		{
			this.opl_p0 = 21615;
		}

		// Token: 0x060146F2 RID: 83698 RVA: 0x0062587C File Offset: 0x00623C7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E068 RID: 57448
		private int opl_p0;
	}
}
