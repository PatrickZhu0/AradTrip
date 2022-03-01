using System;

namespace behaviac
{
	// Token: 0x02002F2D RID: 12077
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_zhaohuan_node0 : Condition
	{
		// Token: 0x0601472D RID: 83757 RVA: 0x00626F85 File Offset: 0x00625385
		public Condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_zhaohuan_node0()
		{
			this.opl_p0 = 2580011;
		}

		// Token: 0x0601472E RID: 83758 RVA: 0x00626F98 File Offset: 0x00625398
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsHaveMonster(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E09E RID: 57502
		private int opl_p0;
	}
}
