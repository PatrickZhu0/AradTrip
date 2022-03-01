using System;

namespace behaviac
{
	// Token: 0x02003C49 RID: 15433
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node1 : Condition
	{
		// Token: 0x0601603C RID: 90172 RVA: 0x006A6EDD File Offset: 0x006A52DD
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node1()
		{
			this.opl_p0 = 21064;
		}

		// Token: 0x0601603D RID: 90173 RVA: 0x006A6EF0 File Offset: 0x006A52F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8B4 RID: 63668
		private int opl_p0;
	}
}
