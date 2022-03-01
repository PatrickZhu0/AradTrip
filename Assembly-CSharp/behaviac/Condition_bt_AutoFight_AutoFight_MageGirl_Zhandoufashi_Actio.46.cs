using System;

namespace behaviac
{
	// Token: 0x0200273D RID: 10045
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node70 : Condition
	{
		// Token: 0x060137BC RID: 79804 RVA: 0x005CD96D File Offset: 0x005CBD6D
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node70()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060137BD RID: 79805 RVA: 0x005CD980 File Offset: 0x005CBD80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D217 RID: 53783
		private float opl_p0;
	}
}
