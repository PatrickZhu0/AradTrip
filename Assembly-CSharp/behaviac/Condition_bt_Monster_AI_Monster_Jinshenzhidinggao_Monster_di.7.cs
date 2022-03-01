using System;

namespace behaviac
{
	// Token: 0x0200368F RID: 13967
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node9 : Condition
	{
		// Token: 0x0601553C RID: 87356 RVA: 0x0066ECB3 File Offset: 0x0066D0B3
		public Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node9()
		{
			this.opl_p0 = 5630;
		}

		// Token: 0x0601553D RID: 87357 RVA: 0x0066ECC8 File Offset: 0x0066D0C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEFF RID: 61183
		private int opl_p0;
	}
}
