using System;

namespace behaviac
{
	// Token: 0x02003D5D RID: 15709
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node8 : Condition
	{
		// Token: 0x06016250 RID: 90704 RVA: 0x006B11A7 File Offset: 0x006AF5A7
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node8()
		{
			this.opl_p0 = 80710011;
		}

		// Token: 0x06016251 RID: 90705 RVA: 0x006B11BC File Offset: 0x006AF5BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsHaveMonster(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAAB RID: 64171
		private int opl_p0;
	}
}
