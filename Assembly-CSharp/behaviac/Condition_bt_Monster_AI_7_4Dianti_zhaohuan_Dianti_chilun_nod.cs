using System;

namespace behaviac
{
	// Token: 0x02002F27 RID: 12071
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node2 : Condition
	{
		// Token: 0x06014722 RID: 83746 RVA: 0x00626B46 File Offset: 0x00624F46
		public Condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node2()
		{
			this.opl_p0 = 70550011;
		}

		// Token: 0x06014723 RID: 83747 RVA: 0x00626B5C File Offset: 0x00624F5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsHaveMonster(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E097 RID: 57495
		private int opl_p0;
	}
}
