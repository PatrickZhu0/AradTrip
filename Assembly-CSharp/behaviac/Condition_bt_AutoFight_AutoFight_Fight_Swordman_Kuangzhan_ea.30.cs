using System;

namespace behaviac
{
	// Token: 0x0200232D RID: 9005
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node57 : Condition
	{
		// Token: 0x06012FCD RID: 77773 RVA: 0x0059CDAF File Offset: 0x0059B1AF
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node57()
		{
			this.opl_p0 = 1511;
		}

		// Token: 0x06012FCE RID: 77774 RVA: 0x0059CDC4 File Offset: 0x0059B1C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9E7 RID: 51687
		private int opl_p0;
	}
}
