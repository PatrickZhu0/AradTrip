using System;

namespace behaviac
{
	// Token: 0x02003EE9 RID: 16105
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Monster_qibing_xiama2_Event_node2 : Condition
	{
		// Token: 0x0601654C RID: 91468 RVA: 0x006C196B File Offset: 0x006BFD6B
		public Condition_bt_Monster_AI_Zhanguo_Monster_qibing_xiama2_Event_node2()
		{
			this.opl_p0 = 7326;
		}

		// Token: 0x0601654D RID: 91469 RVA: 0x006C1980 File Offset: 0x006BFD80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD7A RID: 64890
		private int opl_p0;
	}
}
