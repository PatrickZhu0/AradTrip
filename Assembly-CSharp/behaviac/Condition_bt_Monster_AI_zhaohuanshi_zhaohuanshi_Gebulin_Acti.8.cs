using System;

namespace behaviac
{
	// Token: 0x02003F96 RID: 16278
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node16 : Condition
	{
		// Token: 0x06016696 RID: 91798 RVA: 0x006C7A47 File Offset: 0x006C5E47
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node16()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06016697 RID: 91799 RVA: 0x006C7A7C File Offset: 0x006C5E7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEE8 RID: 65256
		private int opl_p0;

		// Token: 0x0400FEE9 RID: 65257
		private int opl_p1;

		// Token: 0x0400FEEA RID: 65258
		private int opl_p2;

		// Token: 0x0400FEEB RID: 65259
		private int opl_p3;
	}
}
