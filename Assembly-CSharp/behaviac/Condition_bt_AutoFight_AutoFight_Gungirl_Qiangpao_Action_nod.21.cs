using System;

namespace behaviac
{
	// Token: 0x0200252E RID: 9518
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node74 : Condition
	{
		// Token: 0x060133A5 RID: 78757 RVA: 0x005B66A3 File Offset: 0x005B4AA3
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node74()
		{
			this.opl_p0 = 2612;
		}

		// Token: 0x060133A6 RID: 78758 RVA: 0x005B66B8 File Offset: 0x005B4AB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDC8 RID: 52680
		private int opl_p0;
	}
}
