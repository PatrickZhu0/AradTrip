using System;

namespace behaviac
{
	// Token: 0x02003E88 RID: 16008
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node30 : Condition
	{
		// Token: 0x06016491 RID: 91281 RVA: 0x006BCF42 File Offset: 0x006BB342
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node30()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1000;
		}

		// Token: 0x06016492 RID: 91282 RVA: 0x006BCF78 File Offset: 0x006BB378
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCC8 RID: 64712
		private int opl_p0;

		// Token: 0x0400FCC9 RID: 64713
		private int opl_p1;

		// Token: 0x0400FCCA RID: 64714
		private int opl_p2;

		// Token: 0x0400FCCB RID: 64715
		private int opl_p3;
	}
}
