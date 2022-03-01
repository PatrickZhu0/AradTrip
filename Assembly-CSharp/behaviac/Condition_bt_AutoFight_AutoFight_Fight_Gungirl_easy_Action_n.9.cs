using System;

namespace behaviac
{
	// Token: 0x02001F81 RID: 8065
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node9 : Condition
	{
		// Token: 0x060128A2 RID: 75938 RVA: 0x0056DE0D File Offset: 0x0056C20D
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node9()
		{
			this.opl_p0 = 2513;
		}

		// Token: 0x060128A3 RID: 75939 RVA: 0x0056DE20 File Offset: 0x0056C220
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C295 RID: 49813
		private int opl_p0;
	}
}
