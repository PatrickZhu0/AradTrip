using System;

namespace behaviac
{
	// Token: 0x020022C4 RID: 8900
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node34 : Condition
	{
		// Token: 0x06012F03 RID: 77571 RVA: 0x00597161 File Offset: 0x00595561
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node34()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06012F04 RID: 77572 RVA: 0x00597174 File Offset: 0x00595574
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C917 RID: 51479
		private float opl_p0;
	}
}
