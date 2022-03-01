using System;

namespace behaviac
{
	// Token: 0x020022A9 RID: 8873
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node27 : Condition
	{
		// Token: 0x06012ECE RID: 77518 RVA: 0x0059553E File Offset: 0x0059393E
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node27()
		{
			this.opl_p0 = 1510;
		}

		// Token: 0x06012ECF RID: 77519 RVA: 0x00595554 File Offset: 0x00593954
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8D9 RID: 51417
		private int opl_p0;
	}
}
