using System;

namespace behaviac
{
	// Token: 0x02003EAA RID: 16042
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node6 : Condition
	{
		// Token: 0x060164D2 RID: 91346 RVA: 0x006BE940 File Offset: 0x006BCD40
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node6()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060164D3 RID: 91347 RVA: 0x006BE954 File Offset: 0x006BCD54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD07 RID: 64775
		private float opl_p0;
	}
}
