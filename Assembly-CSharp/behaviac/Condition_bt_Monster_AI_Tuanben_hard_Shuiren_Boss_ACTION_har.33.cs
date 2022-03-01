using System;

namespace behaviac
{
	// Token: 0x02003D6D RID: 15725
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node55 : Condition
	{
		// Token: 0x06016270 RID: 90736 RVA: 0x006B180B File Offset: 0x006AFC0B
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node55()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 2500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1000;
		}

		// Token: 0x06016271 RID: 90737 RVA: 0x006B1840 File Offset: 0x006AFC40
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAC9 RID: 64201
		private int opl_p0;

		// Token: 0x0400FACA RID: 64202
		private int opl_p1;

		// Token: 0x0400FACB RID: 64203
		private int opl_p2;

		// Token: 0x0400FACC RID: 64204
		private int opl_p3;
	}
}
