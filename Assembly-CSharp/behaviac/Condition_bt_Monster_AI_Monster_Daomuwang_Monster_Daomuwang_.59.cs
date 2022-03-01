using System;

namespace behaviac
{
	// Token: 0x0200366C RID: 13932
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node3 : Condition
	{
		// Token: 0x060154F9 RID: 87289 RVA: 0x0066D625 File Offset: 0x0066BA25
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node3()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060154FA RID: 87290 RVA: 0x0066D638 File Offset: 0x0066BA38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEB1 RID: 61105
		private float opl_p0;
	}
}
