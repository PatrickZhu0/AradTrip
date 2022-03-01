using System;

namespace behaviac
{
	// Token: 0x02003E80 RID: 16000
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node13 : Condition
	{
		// Token: 0x06016481 RID: 91265 RVA: 0x006BCB22 File Offset: 0x006BAF22
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node13()
		{
			this.opl_p0 = 8000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06016482 RID: 91266 RVA: 0x006BCB58 File Offset: 0x006BAF58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCB8 RID: 64696
		private int opl_p0;

		// Token: 0x0400FCB9 RID: 64697
		private int opl_p1;

		// Token: 0x0400FCBA RID: 64698
		private int opl_p2;

		// Token: 0x0400FCBB RID: 64699
		private int opl_p3;
	}
}
