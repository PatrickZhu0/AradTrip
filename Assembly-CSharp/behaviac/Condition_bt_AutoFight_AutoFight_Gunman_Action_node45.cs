using System;

namespace behaviac
{
	// Token: 0x0200258A RID: 9610
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Action_node45 : Condition
	{
		// Token: 0x0601345C RID: 78940 RVA: 0x005BA912 File Offset: 0x005B8D12
		public Condition_bt_AutoFight_AutoFight_Gunman_Action_node45()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x0601345D RID: 78941 RVA: 0x005BA928 File Offset: 0x005B8D28
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE85 RID: 52869
		private float opl_p0;
	}
}
