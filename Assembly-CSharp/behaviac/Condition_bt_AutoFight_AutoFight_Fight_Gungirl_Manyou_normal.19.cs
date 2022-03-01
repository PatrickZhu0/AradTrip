using System;

namespace behaviac
{
	// Token: 0x0200205E RID: 8286
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node47 : Condition
	{
		// Token: 0x06012A56 RID: 76374 RVA: 0x00577FD6 File Offset: 0x005763D6
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node47()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06012A57 RID: 76375 RVA: 0x00577FEC File Offset: 0x005763EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C449 RID: 50249
		private float opl_p0;
	}
}
