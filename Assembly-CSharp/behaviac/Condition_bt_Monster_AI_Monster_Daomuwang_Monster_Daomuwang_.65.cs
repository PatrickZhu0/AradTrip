using System;

namespace behaviac
{
	// Token: 0x02003674 RID: 13940
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node8 : Condition
	{
		// Token: 0x06015509 RID: 87305 RVA: 0x0066D98D File Offset: 0x0066BD8D
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node8()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601550A RID: 87306 RVA: 0x0066D9A0 File Offset: 0x0066BDA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEC1 RID: 61121
		private float opl_p0;
	}
}
