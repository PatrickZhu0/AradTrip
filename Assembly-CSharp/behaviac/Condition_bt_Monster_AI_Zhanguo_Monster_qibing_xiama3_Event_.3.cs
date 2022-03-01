using System;

namespace behaviac
{
	// Token: 0x02003EEF RID: 16111
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Monster_qibing_xiama3_Event_node2 : Condition
	{
		// Token: 0x06016557 RID: 91479 RVA: 0x006C1C87 File Offset: 0x006C0087
		public Condition_bt_Monster_AI_Zhanguo_Monster_qibing_xiama3_Event_node2()
		{
			this.opl_p0 = 7327;
		}

		// Token: 0x06016558 RID: 91480 RVA: 0x006C1C9C File Offset: 0x006C009C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD80 RID: 64896
		private int opl_p0;
	}
}
