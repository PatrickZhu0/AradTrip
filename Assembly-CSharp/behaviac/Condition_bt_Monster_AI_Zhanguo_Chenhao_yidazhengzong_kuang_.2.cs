using System;

namespace behaviac
{
	// Token: 0x02003EE3 RID: 16099
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node23 : Condition
	{
		// Token: 0x06016541 RID: 91457 RVA: 0x006C14F1 File Offset: 0x006BF8F1
		public Condition_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node23()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06016542 RID: 91458 RVA: 0x006C1504 File Offset: 0x006BF904
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD73 RID: 64883
		private float opl_p0;
	}
}
