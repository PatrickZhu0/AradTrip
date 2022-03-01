using System;

namespace behaviac
{
	// Token: 0x0200273A RID: 10042
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node19 : Condition
	{
		// Token: 0x060137B6 RID: 79798 RVA: 0x005CD7FF File Offset: 0x005CBBFF
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node19()
		{
			this.opl_p0 = 2009;
		}

		// Token: 0x060137B7 RID: 79799 RVA: 0x005CD814 File Offset: 0x005CBC14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D210 RID: 53776
		private int opl_p0;
	}
}
