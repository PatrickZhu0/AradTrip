using System;

namespace behaviac
{
	// Token: 0x02003EBA RID: 16058
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node23 : Condition
	{
		// Token: 0x060164F2 RID: 91378 RVA: 0x006BF181 File Offset: 0x006BD581
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node23()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060164F3 RID: 91379 RVA: 0x006BF194 File Offset: 0x006BD594
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD27 RID: 64807
		private float opl_p0;
	}
}
