using System;

namespace behaviac
{
	// Token: 0x02003678 RID: 13944
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node18 : Condition
	{
		// Token: 0x06015511 RID: 87313 RVA: 0x0066DB41 File Offset: 0x0066BF41
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node18()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06015512 RID: 87314 RVA: 0x0066DB54 File Offset: 0x0066BF54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEC9 RID: 61129
		private float opl_p0;
	}
}
