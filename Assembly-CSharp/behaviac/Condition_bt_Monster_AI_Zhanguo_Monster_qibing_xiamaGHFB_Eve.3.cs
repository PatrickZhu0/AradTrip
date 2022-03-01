using System;

namespace behaviac
{
	// Token: 0x02003EF5 RID: 16117
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Monster_qibing_xiamaGHFB_Event_node1 : Condition
	{
		// Token: 0x06016562 RID: 91490 RVA: 0x006C1FA3 File Offset: 0x006C03A3
		public Condition_bt_Monster_AI_Zhanguo_Monster_qibing_xiamaGHFB_Event_node1()
		{
			this.opl_p0 = 20053;
		}

		// Token: 0x06016563 RID: 91491 RVA: 0x006C1FB8 File Offset: 0x006C03B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD86 RID: 64902
		private int opl_p0;
	}
}
