using System;

namespace behaviac
{
	// Token: 0x02003593 RID: 13715
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Longren_leihuanxiusi_Longren_leihuanxiusi_Event_leihuanxiusi_Hundun_node4 : Condition
	{
		// Token: 0x06015356 RID: 86870 RVA: 0x0066478E File Offset: 0x00662B8E
		public Condition_bt_Monster_AI_Longren_leihuanxiusi_Longren_leihuanxiusi_Event_leihuanxiusi_Hundun_node4()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06015357 RID: 86871 RVA: 0x006647A4 File Offset: 0x00662BA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED1C RID: 60700
		private float opl_p0;
	}
}
