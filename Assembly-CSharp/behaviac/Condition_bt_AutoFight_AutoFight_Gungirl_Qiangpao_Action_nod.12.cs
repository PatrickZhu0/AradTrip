using System;

namespace behaviac
{
	// Token: 0x02002522 RID: 9506
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node44 : Condition
	{
		// Token: 0x0601338D RID: 78733 RVA: 0x005B6187 File Offset: 0x005B4587
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node44()
		{
			this.opl_p0 = 2610;
		}

		// Token: 0x0601338E RID: 78734 RVA: 0x005B619C File Offset: 0x005B459C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDB0 RID: 52656
		private int opl_p0;
	}
}
