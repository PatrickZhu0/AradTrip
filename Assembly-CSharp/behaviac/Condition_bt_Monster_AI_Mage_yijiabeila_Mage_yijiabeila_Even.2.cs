using System;

namespace behaviac
{
	// Token: 0x020035B6 RID: 13750
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node3 : Condition
	{
		// Token: 0x06015399 RID: 86937 RVA: 0x00665CC5 File Offset: 0x006640C5
		public Condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node3()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.SKILL;
		}

		// Token: 0x0601539A RID: 86938 RVA: 0x00665CE4 File Offset: 0x006640E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED65 RID: 60773
		private BE_Target opl_p0;

		// Token: 0x0400ED66 RID: 60774
		private BE_Equal opl_p1;

		// Token: 0x0400ED67 RID: 60775
		private BE_State opl_p2;
	}
}
