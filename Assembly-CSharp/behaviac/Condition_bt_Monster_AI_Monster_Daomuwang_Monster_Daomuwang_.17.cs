using System;

namespace behaviac
{
	// Token: 0x02003631 RID: 13873
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node23 : Condition
	{
		// Token: 0x06015486 RID: 87174 RVA: 0x0066A791 File Offset: 0x00668B91
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node23()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06015487 RID: 87175 RVA: 0x0066A7A4 File Offset: 0x00668BA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE41 RID: 60993
		private float opl_p0;
	}
}
