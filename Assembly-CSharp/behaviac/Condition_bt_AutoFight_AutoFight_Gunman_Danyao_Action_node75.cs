using System;

namespace behaviac
{
	// Token: 0x020025DA RID: 9690
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node75 : Condition
	{
		// Token: 0x060134FB RID: 79099 RVA: 0x005BD8CD File Offset: 0x005BBCCD
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node75()
		{
			this.opl_p0 = 0.15f;
		}

		// Token: 0x060134FC RID: 79100 RVA: 0x005BD8E0 File Offset: 0x005BBCE0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF41 RID: 53057
		private float opl_p0;
	}
}
