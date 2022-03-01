using System;

namespace behaviac
{
	// Token: 0x020022F6 RID: 8950
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node11 : Condition
	{
		// Token: 0x06012F65 RID: 77669 RVA: 0x0059A9EC File Offset: 0x00598DEC
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node11()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06012F66 RID: 77670 RVA: 0x0059AA00 File Offset: 0x00598E00
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C97C RID: 51580
		private float opl_p0;
	}
}
