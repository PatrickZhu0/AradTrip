using System;

namespace behaviac
{
	// Token: 0x02003EFF RID: 16127
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Monster_xiangpushou_boss_Event_node1 : Condition
	{
		// Token: 0x06016574 RID: 91508 RVA: 0x006C2544 File Offset: 0x006C0944
		public Condition_bt_Monster_AI_Zhanguo_Monster_xiangpushou_boss_Event_node1()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.3f;
		}

		// Token: 0x06016575 RID: 91509 RVA: 0x006C2568 File Offset: 0x006C0968
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD8F RID: 64911
		private HMType opl_p0;

		// Token: 0x0400FD90 RID: 64912
		private BE_Operation opl_p1;

		// Token: 0x0400FD91 RID: 64913
		private float opl_p2;
	}
}
