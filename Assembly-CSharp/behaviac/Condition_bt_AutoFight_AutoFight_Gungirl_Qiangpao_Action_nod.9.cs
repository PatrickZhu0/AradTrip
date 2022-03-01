using System;

namespace behaviac
{
	// Token: 0x0200251E RID: 9502
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node111 : Condition
	{
		// Token: 0x06013385 RID: 78725 RVA: 0x005B5FD3 File Offset: 0x005B43D3
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node111()
		{
			this.opl_p0 = 2611;
		}

		// Token: 0x06013386 RID: 78726 RVA: 0x005B5FE8 File Offset: 0x005B43E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDA8 RID: 52648
		private int opl_p0;
	}
}
