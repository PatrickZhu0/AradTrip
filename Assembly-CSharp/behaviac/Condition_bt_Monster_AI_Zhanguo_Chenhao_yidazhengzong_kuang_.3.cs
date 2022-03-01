using System;

namespace behaviac
{
	// Token: 0x02003EE4 RID: 16100
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node25 : Condition
	{
		// Token: 0x06016543 RID: 91459 RVA: 0x006C1537 File Offset: 0x006BF937
		public Condition_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node25()
		{
			this.opl_p0 = 7283;
		}

		// Token: 0x06016544 RID: 91460 RVA: 0x006C154C File Offset: 0x006BF94C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD74 RID: 64884
		private int opl_p0;
	}
}
