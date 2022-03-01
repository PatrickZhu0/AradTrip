using System;

namespace behaviac
{
	// Token: 0x020040B4 RID: 16564
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yijiabeila_Action_node28 : Condition
	{
		// Token: 0x060168C1 RID: 92353 RVA: 0x006D3B2B File Offset: 0x006D1F2B
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yijiabeila_Action_node28()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 1200;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060168C2 RID: 92354 RVA: 0x006D3B60 File Offset: 0x006D1F60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010107 RID: 65799
		private int opl_p0;

		// Token: 0x04010108 RID: 65800
		private int opl_p1;

		// Token: 0x04010109 RID: 65801
		private int opl_p2;

		// Token: 0x0401010A RID: 65802
		private int opl_p3;
	}
}
