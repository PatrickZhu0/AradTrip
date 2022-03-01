using System;

namespace behaviac
{
	// Token: 0x020024FD RID: 9469
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node9 : Condition
	{
		// Token: 0x06013344 RID: 78660 RVA: 0x005B3882 File Offset: 0x005B1C82
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node9()
		{
			this.opl_p0 = 0.25f;
		}

		// Token: 0x06013345 RID: 78661 RVA: 0x005B3898 File Offset: 0x005B1C98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD64 RID: 52580
		private float opl_p0;
	}
}
