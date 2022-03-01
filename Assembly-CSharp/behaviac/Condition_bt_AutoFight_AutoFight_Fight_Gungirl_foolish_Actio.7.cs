using System;

namespace behaviac
{
	// Token: 0x02001F9B RID: 8091
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node17 : Condition
	{
		// Token: 0x060128D5 RID: 75989 RVA: 0x0056F29E File Offset: 0x0056D69E
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node17()
		{
			this.opl_p0 = 0.25f;
		}

		// Token: 0x060128D6 RID: 75990 RVA: 0x0056F2B4 File Offset: 0x0056D6B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2C7 RID: 49863
		private float opl_p0;
	}
}
