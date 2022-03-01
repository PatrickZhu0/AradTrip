using System;

namespace behaviac
{
	// Token: 0x02002556 RID: 9558
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node94 : Condition
	{
		// Token: 0x060133F5 RID: 78837 RVA: 0x005B780B File Offset: 0x005B5C0B
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node94()
		{
			this.opl_p0 = 2513;
		}

		// Token: 0x060133F6 RID: 78838 RVA: 0x005B7820 File Offset: 0x005B5C20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE1C RID: 52764
		private int opl_p0;
	}
}
