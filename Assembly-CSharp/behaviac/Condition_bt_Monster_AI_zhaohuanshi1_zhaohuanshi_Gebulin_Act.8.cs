using System;

namespace behaviac
{
	// Token: 0x0200403F RID: 16447
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node16 : Condition
	{
		// Token: 0x060167DD RID: 92125 RVA: 0x006CEC23 File Offset: 0x006CD023
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node16()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060167DE RID: 92126 RVA: 0x006CEC58 File Offset: 0x006CD058
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010027 RID: 65575
		private int opl_p0;

		// Token: 0x04010028 RID: 65576
		private int opl_p1;

		// Token: 0x04010029 RID: 65577
		private int opl_p2;

		// Token: 0x0401002A RID: 65578
		private int opl_p3;
	}
}
