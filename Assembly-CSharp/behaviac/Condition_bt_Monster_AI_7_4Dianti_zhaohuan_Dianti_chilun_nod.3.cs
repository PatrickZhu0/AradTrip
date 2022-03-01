using System;

namespace behaviac
{
	// Token: 0x02002F2A RID: 12074
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node9 : Condition
	{
		// Token: 0x06014728 RID: 83752 RVA: 0x00626CAB File Offset: 0x006250AB
		public Condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node9()
		{
			this.opl_p0 = 2580012;
		}

		// Token: 0x06014729 RID: 83753 RVA: 0x00626CC0 File Offset: 0x006250C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsHaveMonster(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E09B RID: 57499
		private int opl_p0;
	}
}
