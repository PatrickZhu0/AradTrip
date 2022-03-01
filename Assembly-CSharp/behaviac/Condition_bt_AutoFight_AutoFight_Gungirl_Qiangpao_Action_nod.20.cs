using System;

namespace behaviac
{
	// Token: 0x0200252D RID: 9517
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node73 : Condition
	{
		// Token: 0x060133A3 RID: 78755 RVA: 0x005B665D File Offset: 0x005B4A5D
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node73()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x060133A4 RID: 78756 RVA: 0x005B6670 File Offset: 0x005B4A70
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDC7 RID: 52679
		private float opl_p0;
	}
}
