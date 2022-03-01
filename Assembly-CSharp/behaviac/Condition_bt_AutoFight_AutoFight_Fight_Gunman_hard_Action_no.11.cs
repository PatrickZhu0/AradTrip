using System;

namespace behaviac
{
	// Token: 0x020020FE RID: 8446
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node27 : Condition
	{
		// Token: 0x06012B90 RID: 76688 RVA: 0x0058009E File Offset: 0x0057E49E
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node27()
		{
			this.opl_p0 = 0.68f;
		}

		// Token: 0x06012B91 RID: 76689 RVA: 0x005800B4 File Offset: 0x0057E4B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C583 RID: 50563
		private float opl_p0;
	}
}
