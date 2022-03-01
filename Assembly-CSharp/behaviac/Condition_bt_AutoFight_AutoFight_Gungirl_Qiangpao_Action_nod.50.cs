using System;

namespace behaviac
{
	// Token: 0x02002555 RID: 9557
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node93 : Condition
	{
		// Token: 0x060133F3 RID: 78835 RVA: 0x005B77C5 File Offset: 0x005B5BC5
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node93()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060133F4 RID: 78836 RVA: 0x005B77D8 File Offset: 0x005B5BD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE1B RID: 52763
		private float opl_p0;
	}
}
