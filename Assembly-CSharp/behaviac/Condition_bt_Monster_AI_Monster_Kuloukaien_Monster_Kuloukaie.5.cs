using System;

namespace behaviac
{
	// Token: 0x020036B0 RID: 14000
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Kuloukaien_Monster_Kuloukaien_Action_node13 : Condition
	{
		// Token: 0x0601557A RID: 87418 RVA: 0x006701D5 File Offset: 0x0066E5D5
		public Condition_bt_Monster_AI_Monster_Kuloukaien_Monster_Kuloukaien_Action_node13()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601557B RID: 87419 RVA: 0x006701E8 File Offset: 0x0066E5E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF50 RID: 61264
		private float opl_p0;
	}
}
